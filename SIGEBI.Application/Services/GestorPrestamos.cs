using SIGEBI.Application.DTOs;
using SIGEBI.Application.Helpers;
using SIGEBI.Application.Interfaces;
using SIGEBI.Domain.Entities;
using SIGEBI.Domain.Enums;
using SIGEBI.Domain.Exceptions;

namespace SIGEBI.Application.Services
{
    public class GestorPrestamos : IservicioPrestamo
    {
        private readonly IRepositorioPrestamo _repoPrestamo;
        private readonly IRepoSolicitud _repoSolicitud;
        private readonly IServicioAuditoria _servicioAuditoria;
        private readonly IUsuarios _usuario;
        private readonly IRepositorioEjemplar _repositorioEjemplar;
        private readonly IServicioNotificacion _servicioNotificacion;
        private readonly IServicioPoliticaNegocio _servicioPoliticaNegocio;
        private readonly IServiciosObtenerBibliotecario _servicioObtenerBibliotecario;

        public GestorPrestamos(
            IRepositorioPrestamo repoPrestamo,
            IRepoSolicitud repoSolicitud,
            IServicioAuditoria servicioAuditoria,
            IRepositorioEjemplar repositorioEjemplar,
            IServicioNotificacion servicioNotificacion,
            IServicioPoliticaNegocio servicioPoliticaNegocio,
            IServiciosObtenerBibliotecario servicioObtenerBibliotecario,
            IUsuarios usuario)
        {
            _repoPrestamo = repoPrestamo;
            _repoSolicitud = repoSolicitud;
            _servicioAuditoria = servicioAuditoria;
            _usuario = usuario;
            _repositorioEjemplar = repositorioEjemplar;
            _servicioNotificacion = servicioNotificacion;
            _servicioPoliticaNegocio = servicioPoliticaNegocio;
            _servicioObtenerBibliotecario = servicioObtenerBibliotecario;
        }

        public async Task<PrestamoResponseDTO> AprobarYRegistrarPrestamoAsync(PrestamoRequestDTO peticion, int idBibliotecarioResponsable)
        {
            if (peticion == null)
                throw new NegocioExeption("Los datos de aprobación son obligatorios.");

            var bibliotecario = await _servicioObtenerBibliotecario.ObtenerBibliotecarioPorIdAsync(idBibliotecarioResponsable);

            var solicitud = await _repoSolicitud.ObtenerSolicitudConDetallesAsync(peticion.IdSolicitud);

            if (solicitud == null)
                throw new NegocioExeption("La solicitud no existe.");

            if (solicitud.Estado != "Pendiente")
                throw new NegocioExeption($"La solicitud no puede aprobarse porque está en estado '{solicitud.Estado}'.");

            if (solicitud.EjemplaresSolicitados == null || !solicitud.EjemplaresSolicitados.Any())
                throw new NegocioExeption("La solicitud no contiene libros solicitados.");

            var usuarioSolicitante = await _usuario.ObtenerUsuarioConDetallesAsync(solicitud.IdUsuario);

            if (usuarioSolicitante == null)
                throw new NegocioExeption("La solicitud no tiene un usuario solicitante válido.");

            var prestamosActivos = await _repoPrestamo.ObtenerActivoPorUsuarioAsync(usuarioSolicitante.IdUsuario);

            _servicioPoliticaNegocio.ValidarCapacidadPrestamo(
                usuarioSolicitante,
                solicitud.EjemplaresSolicitados.Count,
                prestamosActivos,
                "aprobar");

            foreach (var ejemplar in solicitud.EjemplaresSolicitados)
            {
                if (ejemplar.Estado != EstadoEjemplar.Disponible && ejemplar.Estado != EstadoEjemplar.Reservado)
                    throw new NegocioExeption($"No se puede aprobar la solicitud porque el Ejemplar '{ejemplar.CodigoFisico}' ya no esta disponible.");
            }

            DateTime fechaInicio = DateTime.Now;
            DateTime fechaVencimiento = _servicioPoliticaNegocio.CalcularFechaVencimiento(usuarioSolicitante, fechaInicio);

            var ejemplaresPrestamo = solicitud.EjemplaresSolicitados.ToList();
            var nuevoPrestamo = new Prestamo(
                usuarioSolicitante.IdUsuario,
                fechaInicio,
                fechaVencimiento,
                ejemplaresPrestamo
            );

            foreach (var ejemplar in ejemplaresPrestamo)
            {
                ejemplar.AsignarAPrestamo();
                await _repositorioEjemplar.ActualizarAsync(ejemplar);
            }

            solicitud.Aprobar();

            await _repoSolicitud.ActualizarAsync(solicitud);
            await _repoPrestamo.AgregarAsync(nuevoPrestamo);

            var aprobacion = new Aprobacion(
                bibliotecario.IdUsuario,
                solicitud.IdSolicitud,
                nuevoPrestamo.IdUsuario
            );

            await _repoSolicitud.GuardarResolucionAsync(aprobacion);

            await _servicioAuditoria.RegistrarAccionAsync(
                idResponsable: idBibliotecarioResponsable,
                tipoAccion: "Aprobar préstamo",
                entidadAfectada: "Prestamo",
                detalles: $"El bibliotecario {bibliotecario.Nombre} aprobó la solicitud #{solicitud.IdSolicitud} y registró el préstamo #{nuevoPrestamo.IdPrestamo}."
            );

            var titulosPrestados = string.Join(", ", MapeoExtensiones.ObtenerTitulosLibros(nuevoPrestamo.EjemplaresAprestar));

            await _servicioNotificacion.EnviarNotificacionAsync(
                usuarioSolicitante.IdUsuario,
                $"Tu préstamo #{nuevoPrestamo.IdPrestamo} fue confirmado. " +
                $"Fecha límite de devolución: {nuevoPrestamo.FechaVencimiento:dd/MM/yyyy}. " +
                $"Recursos: {titulosPrestados}.",
                TipoNotificacion.PrestamoFormalizado
            );

            return MapearPrestamoResponse(nuevoPrestamo, usuarioSolicitante);
        }

        public async Task<IEnumerable<PrestamoResponseDTO>> ConsultarPrestamosActivosPorIdentificadorAsync(string identificador)
        {
            var usuario = await ResolucionUsuario.ObtenerPorIdentificadorAsync(_usuario, identificador);

            return await ConsultarYMapearAsync(
                () => _repoPrestamo.ObtenerActivoPorUsuarioAsync(usuario.IdUsuario),
                "Este usuario no tiene préstamos activos.");
        }

        public async Task<IEnumerable<PrestamoResponseDTO>> ConsultarPrestamosActivosPorRecursoAsync(string isbnLibro)
        {
            ValidarIsbn(isbnLibro);

            return await ConsultarYMapearAsync(
                () => _repoPrestamo.ObtenerActivosPorRecursoAsync(isbnLibro),
                "No se encontro el prestamo, revise el isbn ingrado");
        }

        public async Task<IEnumerable<PrestamoResponseDTO>> ConsultarHistorialPorRecursoAsync(string isbnLibro)
        {
            ValidarIsbn(isbnLibro);

            return await ConsultarYMapearAsync(
                () => _repoPrestamo.ObtenerHistorialPorRecurso(isbnLibro),
                "Este libro no pertenece a ningun prestamo");
        }

        public async Task<IEnumerable<PrestamoResponseDTO>> ConsultarHistorialPorUsuarioAsync(string identificador)
        {
            var usuario = await ResolucionUsuario.ObtenerPorIdentificadorAsync(_usuario, identificador);

            return await ConsultarYMapearAsync(
                () => _repoPrestamo.ObtenerHistorialPorUsuarioAsync(usuario.IdUsuario),
                "Este usuario no tiene ningun historial de prestamos ");
        }

        private async Task<IEnumerable<PrestamoResponseDTO>> ConsultarYMapearAsync(
            Func<Task<IEnumerable<Prestamo>>> obtenerPrestamos,
            string mensajeSiVacio)
        {
            var prestamos = await obtenerPrestamos();

            if (!prestamos.Any())
                throw new NegocioExeption(mensajeSiVacio);

            return prestamos.Select(p => MapearPrestamoResponse(p, p.Usuario));
        }

        private static void ValidarIsbn(string isbnLibro)
        {
            if (string.IsNullOrWhiteSpace(isbnLibro))
                throw new NegocioExeption("Debe ingresar el identificador (isbn) de algun libro");
        }

        private static PrestamoResponseDTO MapearPrestamoResponse(Prestamo prestamo, Usuario? usuario)
        {
            return new PrestamoResponseDTO
            {
                IdPrestamo = prestamo.IdPrestamo,
                FechaInicio = prestamo.FechaInicio,
                FechaVencimiento = prestamo.FechaVencimiento,
                Estado = prestamo.Estado ?? string.Empty,
                DiasRetraso = prestamo.CalcularDiasRetraso(),
                IdUsuario = prestamo.IdUsuario,
                NombreUsuario = prestamo.Usuario != null ? prestamo.Usuario.Nombre : string.Empty,
                TitulosLibros = MapeoExtensiones.ObtenerTitulosLibros(prestamo.EjemplaresAprestar),
                Matricula = MapeoExtensiones.ObtenerMatricula(usuario),
                NumeroEmpleado = usuario?.NumeroEmpleado,
                ISBNs = MapeoExtensiones.ObtenerIsbns(prestamo.EjemplaresAprestar)
            };
        }
    }
}
