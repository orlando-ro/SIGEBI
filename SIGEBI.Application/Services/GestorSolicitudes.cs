using SIGEBI.Application.DTOs;
using SIGEBI.Application.Interfaces;
using SIGEBI.Domain.Entities;
using SIGEBI.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using SIGEBI.Domain.Enums;

namespace SIGEBI.Application.Services
{
    public class GestorSolicitudes : IServicioSolicitud, IServicioPoliticaNegocio, IServiciosObtenerBibliotecario
    {
        private readonly IRepoSolicitud _repoSolicitud;
        private readonly IUsuarios _usuarios;
        private readonly IRepositorioLibro _repositorioLibro;
        private readonly IServicioAuditoria _servicioAuditoria;
        private readonly IRepositorioPrestamo _repositorioPrestamo;
        private readonly IRepositorioEjemplar _repositorioEjemplar;
        


        public GestorSolicitudes(IRepoSolicitud repoSolicitud, 
            IUsuarios usuarios, 
            IRepositorioLibro repositorioLibro, 
            IServicioAuditoria servicioAuditoria, 
            IRepositorioPrestamo repositorioPrestamo,
            IRepositorioEjemplar repositorioEjemplar
            )
        {

            _repoSolicitud = repoSolicitud;
            _usuarios = usuarios;
            _repositorioLibro = repositorioLibro;
            _servicioAuditoria = servicioAuditoria;
            _repositorioPrestamo = repositorioPrestamo;
            _repositorioEjemplar = repositorioEjemplar;
            
        }



        public async Task<SolicitudResponseDTO> CrearSolicitudAsync(SolicitudRequestDTO peticion)
        {
            if (peticion == null)
                throw new NegocioExeption("Los datos de la solicitud son obligatorios ");

            if (string.IsNullOrWhiteSpace(peticion.MatriculaONumeroEmpleado))
                throw new NegocioExeption("Debe ingresar la matricula o el numero del usuario");

            if (peticion.IsbnsLibros == null || !peticion.IsbnsLibros.Any())
                throw new NegocioExeption("Debe solicitar al menos un libro.");

            var usuario = await _usuarios.ObtenerPorMatriculaONumeroEmpleadoAsync(peticion.MatriculaONumeroEmpleado);

            if (usuario == null)
                throw new NegocioExeption("El usuario no está registrado en el sistema.");

            usuario.ValidarElegibilidadParaPrestamo();

            int LimiteDePrestamos = ObtenerLimitePrestamosPorTipoUsuario(usuario);

            if (LimiteDePrestamos <= 0)
               throw new NegocioExeption("Este usuario no puede solicitar prestamos ");

            var prestamosActivos =  await _repositorioPrestamo.ObtenerActivoPorUsuarioAsync(usuario.IdUsuario);

            int RecursosActivos = prestamosActivos.Count();

            var EjemplaresSolicitados = await ObtenerEjemplaresSolicitadosAsync(peticion.IsbnsLibros);
           

            if (RecursosActivos + EjemplaresSolicitados.Count > LimiteDePrestamos) {

                throw new NegocioExeption($"Exediste el limite de prestamos." +
                    $"Limite permitido{LimiteDePrestamos}" +
                    $"Recursos activos actuales {RecursosActivos}" +
                    $"Libros Solicitados{EjemplaresSolicitados}" 
                    );
            }

            var nuevaSolicitud = new Solicitud(usuario.IdUsuario, EjemplaresSolicitados);
           

            await _servicioAuditoria.RegistrarAccionAsync(
                idUsuario: usuario.IdUsuario,
                tipoAccion: "Solicitud para prestamos",
                entidadAfectada: "solicitud, prestamos",
                detalles: $"El usuario {usuario.IdUsuario} ha realizado una solicitud para los libros {EjemplaresSolicitados}"
                );

            return MapearSolicitudResponse(nuevaSolicitud, usuario);
        }



        public async Task RechasarSolicitudAsync(RechazoSolicitudRequestDTO peticion)
        {
            if (peticion.idSolicitud <= 0)
                throw new NegocioExeption("Debe indicar el identificador de la solicitud que va a rechazar");

            if (string.IsNullOrWhiteSpace(peticion.MotivoRechazo))
                throw new NegocioExeption("Debe especificar el motivo del rechazo");

            var Bibliotecario = await ObtenerBibliotecarioAsync(peticion.MatriculaONumeroEmpleado);

            if (Bibliotecario == null)
                throw new NegocioExeption("Lo sentimos pero no encontramos un bibliotecario con ese identificador");

            var solicitudARechazar = await _repoSolicitud.ObtenerSolicitudConDetallesAsync(peticion.idSolicitud);

            if (solicitudARechazar == null)
                throw new NegocioExeption(" no se encontro ninguna solicitud");

            solicitudARechazar.Rechazar();

            var rechazo = new Rechazo(
                Bibliotecario.IdUsuario,
                solicitudARechazar.IdSolicitud,
                peticion.MotivoRechazo
                );
            await _repoSolicitud.ActualizarAsync(solicitudARechazar);

            await _repoSolicitud.GuardarResolucionAsync(rechazo);

            await _servicioAuditoria.RegistrarAccionAsync(
                idUsuario: Bibliotecario.IdUsuario,
                tipoAccion: "Rechazar solicitud",
                entidadAfectada: "Solicitud",
                detalles: $"El bibliotecario {Bibliotecario.Nombre} rechazó la solicitud #{solicitudARechazar.IdSolicitud}. Motivo: {peticion.MotivoRechazo}."
            );
        }



        public async Task<SolicitudResponseDTO?> ObtenerPorIdAsync(int IdSolicitud)
        {
            if (IdSolicitud <= 0)
                throw new NegocioExeption("Debe ingresar el id del usuario para poder realizar la validacion");

            var solicitud = await _repoSolicitud.ObtenerSolicitudConDetallesAsync(IdSolicitud);

            if (solicitud == null)
                return null;

            return MapearSolicitudResponse(solicitud, solicitud.Usuario);

            
        }



        public async Task<IEnumerable<SolicitudResponseDTO>> ConsultarPendientesAsync()
        {
            var solicitudes = await _repoSolicitud.ObtenerPendientesAsync();

            return solicitudes.Select(s => MapearSolicitudResponse(s, s.Usuario));
        }

        public async Task<IEnumerable<SolicitudResponseDTO>> ConsultarPorUsuarioAsync(string MatriculaONUmeroEmpleado)
        {
            if (string.IsNullOrWhiteSpace(MatriculaONUmeroEmpleado))
                throw new NegocioExeption("Debe ingresar el identificador del usuario");

            var Usuarios = await _usuarios.ObtenerPorMatriculaONumeroEmpleadoAsync(MatriculaONUmeroEmpleado);

            if (Usuarios == null)
                throw new NegocioExeption("El usuario no se encuentra registrado ");

            var Solicitud = await _repoSolicitud.ObtenerPorUsuarioAsync(Usuarios.IdUsuario);

            return Solicitud.Select(s => MapearSolicitudResponse(s, Usuarios));

        }



        public int ObtenerLimitePrestamosPorTipoUsuario(Usuario usuario)
        {
            if (usuario is Estudiante)
                return 3;

            if (usuario is Docente)
                return 5;

            return 2;
        }



        private async Task<List<Ejemplar>> ObtenerEjemplaresSolicitadosAsync(List<string> Isbn)
        {

            var isbnNormalizados = Isbn
                .Where(i => !string.IsNullOrWhiteSpace(i))
                .Select(i => i.Trim())
                .Distinct()
                .ToList();

            if (!isbnNormalizados.Any())
                throw new NegocioExeption("Debe indicar al menos un libro");

            var EjemplaresSeleccionados= new List<Ejemplar>();

            foreach (var isbn in isbnNormalizados) {

                var EjemplaresSolicitados = (await _repositorioEjemplar.ObtenerEjemplaresPorIsbnAsync(isbn)).ToList();

                if (EjemplaresSolicitados == null || EjemplaresSolicitados.Any())
                    throw new NegocioExeption($" No se encontro ningun libro con {isbn}");

                var EjemplaresDisponibles = EjemplaresSolicitados.FirstOrDefault(e => e.Estado == EstadoEjemplar.Disponible);

                if (EjemplaresDisponibles == null)
                    throw new NegocioExeption("El libro no esta disponible, lo sentimos mucho selecciona otro de tu preferencia ");

                EjemplaresSeleccionados.Add(EjemplaresDisponibles);

            }
            return EjemplaresSeleccionados;


        }

        private static SolicitudResponseDTO MapearSolicitudResponse(Solicitud solicitud, Usuario? usuario)
        {
            return new SolicitudResponseDTO
            {
                IdSolicitud = solicitud.IdSolicitud,
                FechaSolicitud = solicitud.FechaSolicitud,
                Estado = solicitud.Estado,
                IdUsuario = solicitud.IdUsuario,
                NombreUsuarioSolicitante = usuario?.Nombre ?? string.Empty,
                Matricula = usuario is Estudiante estudiante ? estudiante.Matricula : null,
                NumeroEmpleado = usuario?.NumeroEmpleado,
                TitulosLibros = solicitud.EjemplaresSolicitados.Select(l => l.ISBN).ToList(),

            };


        }

      

        public async Task<Usuario> ObtenerBibliotecarioAsync(string matriculaONumeroEmpleadoBibliotecario)
        {
            var usuario = await _usuarios.ObtenerPorMatriculaONumeroEmpleadoAsync(matriculaONumeroEmpleadoBibliotecario);

            if (usuario is not PersonalBibliotecario)
                throw new NegocioExeption("Solo el personal bibliotecario puede aprobar, rechazar o registrar devoluciones.");

            return usuario;
        }
    }
}
