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

            var aprobacion = new Aprobacion(bibliotecario.IdUsuario, solicitud.IdSolicitud, nuevoPrestamo.IdUsuario);
            await _repoSolicitud.GuardarResolucionAsync(aprobacion);

            
            var titulosPrestados = string.Join(", ", MapeoExtensiones.ObtenerTitulosLibros(nuevoPrestamo.EjemplaresAprestar));

            await _servicioAuditoria.RegistrarAccionAsync(
                idResponsable: idBibliotecarioResponsable,
                tipoAccion: "Aprobar préstamo",
                entidadAfectada: "Préstamos y Devoluciones",
                detalles: $"El bibliotecario {bibliotecario.Nombre} aprobó el préstamo de los libros ({titulosPrestados}) para el usuario {usuarioSolicitante.Nombre}."
            );

            await _servicioNotificacion.EnviarNotificacionAsync(
                usuarioSolicitante.IdUsuario,
                $"Tu préstamo fue confirmado por el bibliotecario {bibliotecario.Nombre} el {DateTime.Now:dd/MM/yyyy}. " +
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

        public async Task<IEnumerable<PrestamoResponseDTO>> ConsultarHistorialPorUsuarioAsync(string identificador)
        {
            var usuario = await ResolucionUsuario.ObtenerPorIdentificadorAsync(_usuario, identificador);
            return await ConsultarYMapearAsync(
                () => _repoPrestamo.ObtenerHistorialPorUsuarioAsync(usuario.IdUsuario),
                "Este usuario no tiene ningún historial de préstamos.");
        }

        public async Task<IEnumerable<PrestamoResponseDTO>> ConsultarTodosAsync()
        {
            return await ConsultarYMapearAsync(
                 () => _repoPrestamo.ConsultarTodosAsync(),
                 "No hay préstamos activos registrados en el sistema actualmente."
             );
        }

        public async Task<IEnumerable<PrestamoResponseDTO>> ConsultarPrestamosActivosPorIdUsuarioAsync(int idUsuario)
        {
            return await ConsultarYMapearAsync(
                () => _repoPrestamo.ObtenerActivoPorUsuarioAsync(idUsuario),
                "No tienes préstamos activos en este momento.");
        }

        public async Task<IEnumerable<PrestamoResponseDTO>> ConsultarActivosPorFiltroAsync(string criterio, string valor)
        {
            return await ConsultarYMapearAsync(
                () => _repoPrestamo.ConsultarActivosPorFiltroAsync(criterio, valor),
                "No se encontraron préstamos activos con los criterios ingresados."
            );
        }

        public async Task<IEnumerable<PrestamoResponseDTO>> ConsultarHistorialCompletoAsync()
        {
            return await ConsultarYMapearAsync(
                 () => _repoPrestamo.ConsultarHistorialCompletoAsync(),
                 "No hay registros de préstamos en el historial del sistema."
             );
        }

        // NUEVO: Método Avanzado de Búsqueda
        public async Task<IEnumerable<PrestamoResponseDTO>> ConsultarHistorialAvanzadoAsync(string? terminoBusqueda, string? estado)
        {
            return await ConsultarYMapearAsync(
                () => _repoPrestamo.ConsultarHistorialAvanzadoAsync(terminoBusqueda, estado),
                "No se encontraron préstamos que coincidan con los criterios de búsqueda."
            );
        }

        private async Task<IEnumerable<PrestamoResponseDTO>> ConsultarYMapearAsync(
            Func<Task<IEnumerable<Prestamo>>> obtenerPrestamos,
            string mensajeSiVacio)
        {
            var prestamos = await obtenerPrestamos();

            if (prestamos == null || !prestamos.Any())
                return Enumerable.Empty<PrestamoResponseDTO>();

            return prestamos.Select(p => MapearPrestamoResponse(p, p.Usuario));
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
                NombreUsuario = prestamo.Usuario != null ? prestamo.Usuario.Nombre : string.Empty,
                TitulosLibros = MapeoExtensiones.ObtenerTitulosLibros(prestamo.EjemplaresAprestar),
                Matricula = MapeoExtensiones.ObtenerMatricula(usuario),
                NumeroEmpleado = usuario?.NumeroEmpleado
            };
        }


    }
}
