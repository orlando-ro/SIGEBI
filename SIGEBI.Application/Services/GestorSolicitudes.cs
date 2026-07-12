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
    public class GestorSolicitudes : IServicioSolicitud
    {
        private readonly IRepoSolicitud _repoSolicitud;
        private readonly IUsuarios _usuarios;
        private readonly IRepositorioLibro _repositorioLibro;
        private readonly IServicioAuditoria _servicioAuditoria;
        private readonly IRepositorioPrestamo _repositorioPrestamo;
        private readonly IRepositorioEjemplar _repositorioEjemplar;
        private readonly IServicioPoliticaNegocio _servicioPoliticaNegocio;
        private readonly IServiciosObtenerBibliotecario _serviciosObtenerBibliotecario;
       


        public GestorSolicitudes(IRepoSolicitud repoSolicitud, 
            IUsuarios usuarios, 
            IRepositorioLibro repositorioLibro, 
            IServicioAuditoria servicioAuditoria, 
            IRepositorioPrestamo repositorioPrestamo,
            IServicioNotificacion servicioNotificacion,
            IServicioPoliticaNegocio servicioPoliticaNegocio,
            IServiciosObtenerBibliotecario serviciosObtenerBibliotecario,
            IRepositorioEjemplar repositorioEjemplar
            )
        {

            _repoSolicitud = repoSolicitud;
            _usuarios = usuarios;
            _repositorioLibro = repositorioLibro;
            _servicioAuditoria = servicioAuditoria;
            _repositorioPrestamo = repositorioPrestamo;
            _repositorioEjemplar = repositorioEjemplar;
            _servicioPoliticaNegocio = servicioPoliticaNegocio;
            _serviciosObtenerBibliotecario = serviciosObtenerBibliotecario;
          
        }



        public async Task<SolicitudResponseDTO> CrearSolicitudAsync(SolicitudRequestDTO peticion)
        {
            if (peticion == null)
                throw new NegocioExeption("Los datos de la solicitud son obligatorios.");

            if (string.IsNullOrWhiteSpace(peticion.MatriculaONumeroEmpleado))
                throw new NegocioExeption("Debe ingresar la matrícula o el número del usuario.");

            if (peticion.IsbnsLibros == null || !peticion.IsbnsLibros.Any())
                throw new NegocioExeption("Debe solicitar al menos un libro.");

            var usuario = await _usuarios.ObtenerPorMatriculaONumeroEmpleadoAsync(
                peticion.MatriculaONumeroEmpleado);

            if (usuario == null)
                throw new NegocioExeption("El usuario no está registrado en el sistema.");

            usuario.ValidarElegibilidadParaPrestamo();

            int limiteDePrestamos =  _servicioPoliticaNegocio.ObtenerLimitePrestamosPorTipoUsuario(usuario);

            if (limiteDePrestamos <= 0)
                throw new NegocioExeption("Este usuario no puede solicitar préstamos.");

            var prestamosActivos = await _repositorioPrestamo
                .ObtenerActivoPorUsuarioAsync(usuario.IdUsuario);

            int recursosActivos = prestamosActivos
                .SelectMany(p => p.EjemplaresAprestar)
                .Count();

            var ejemplaresSolicitados = await ObtenerEjemplaresSolicitadosAsync(
                peticion.IsbnsLibros);

            if (recursosActivos + ejemplaresSolicitados.Count > limiteDePrestamos)
            {
                throw new NegocioExeption(
                    $"Excediste el límite de préstamos. " +
                    $"Límite permitido: {limiteDePrestamos}. " +
                    $"Recursos activos actuales: {recursosActivos}. " +
                    $"Libros solicitados: {ejemplaresSolicitados.Count}.");
            }

            foreach (var ejemplar in ejemplaresSolicitados)
            {
                ejemplar.MarcarComoReservado();
                await _repositorioEjemplar.ActualizarAsync(ejemplar);
            }

            var nuevaSolicitud = new Solicitud(usuario.IdUsuario, ejemplaresSolicitados);

            await _repoSolicitud.AgregarAsync(nuevaSolicitud);

            await _servicioAuditoria.RegistrarAccionAsync(
                idUsuario: usuario.IdUsuario,
                tipoAccion: "Solicitud de préstamo",
                entidadAfectada: "Solicitud",
                detalles: $"El usuario {usuario.IdUsuario} realizó la solicitud #{nuevaSolicitud.IdSolicitud}."
            );

            return MapearSolicitudResponse(nuevaSolicitud, usuario);
        }



        public async Task RechasarSolicitudAsync(RechazoSolicitudRequestDTO peticion)
        {
            if (peticion.idSolicitud <= 0)
                throw new NegocioExeption("Debe indicar el identificador de la solicitud que va a rechazar");

            if (string.IsNullOrWhiteSpace(peticion.MotivoRechazo))
                throw new NegocioExeption("Debe especificar el motivo del rechazo");

            var Bibliotecario = await _serviciosObtenerBibliotecario.ObtenerBibliotecarioAsync(peticion.MatriculaONumeroEmpleado);

            if (Bibliotecario == null)
                throw new NegocioExeption("Lo sentimos pero no encontramos un bibliotecario con ese identificador");

            var solicitudARechazar = await _repoSolicitud.ObtenerSolicitudConDetallesAsync(peticion.idSolicitud);

            if (solicitudARechazar == null)
                throw new NegocioExeption(" no se encontro ninguna solicitud");

            solicitudARechazar.Rechazar();

            foreach (var ejemplar in solicitudARechazar.EjemplaresSolicitados)
            {
                if (ejemplar.Estado == EstadoEjemplar.Reservado)
                {
                    ejemplar.HabilitarParaPrestamo();
                    await _repositorioEjemplar.ActualizarAsync(ejemplar);
                }
            }

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
                throw new NegocioExeption($"No se encontro la solicitud con id {IdSolicitud}");

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



        private async Task<List<Ejemplar>> ObtenerEjemplaresSolicitadosAsync(List<string> Isbn)
        {

            var isbnNormalizados = Isbn
        .Where(i => !string.IsNullOrWhiteSpace(i))
        .Select(i => i.Trim())
        .Distinct()
        .ToList();

            if (!isbnNormalizados.Any())
                throw new NegocioExeption("Debe indicar al menos un libro.");

            var ejemplaresSeleccionados = new List<Ejemplar>();

            foreach (var isbn in isbnNormalizados)
            {
                var ejemplaresDelLibro = (await _repositorioEjemplar
                    .ObtenerEjemplaresPorIsbnAsync(isbn))
                    .ToList();

                if (!ejemplaresDelLibro.Any())
                    throw new NegocioExeption($"No se encontró ningún ejemplar del libro con ISBN {isbn}.");

                var ejemplarDisponible = ejemplaresDelLibro
                    .FirstOrDefault(e => e.Estado == EstadoEjemplar.Disponible);

                if (ejemplarDisponible == null)
                    throw new NegocioExeption(
                        $"El libro con ISBN {isbn} no está disponible actualmente.");

                ejemplaresSeleccionados.Add(ejemplarDisponible);
            }

            return ejemplaresSeleccionados;


        }

        private static SolicitudResponseDTO MapearSolicitudResponse(Solicitud solicitud, Usuario? usuario)
        {
            return new SolicitudResponseDTO
            {
                IdSolicitud = solicitud.IdSolicitud,
                FechaSolicitud = solicitud.FechaSolicitud,
                Estado = solicitud.Estado ?? string.Empty,
                IdUsuario = solicitud.IdUsuario,
                NombreUsuarioSolicitante = usuario?.Nombre ?? string.Empty,
                Matricula = usuario is Estudiante estudiante ? estudiante.Matricula : null,
                NumeroEmpleado = usuario?.NumeroEmpleado,

                ISBNs = solicitud.EjemplaresSolicitados
            .Select(e => e.ISBN)
            .ToList(),

                TitulosLibros = solicitud.EjemplaresSolicitados
            .Where(e => e.Libro != null)
            .Select(e => e.Libro!.Titulo)
            .ToList()
            };


        }

      

       
    }
}
