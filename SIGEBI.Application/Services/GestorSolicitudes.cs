using SIGEBI.Application.DTOs;
using SIGEBI.Application.Helpers;
using SIGEBI.Application.Interfaces;
using SIGEBI.Domain.Entities;
using SIGEBI.Domain.Enums;
using SIGEBI.Domain.Exceptions;

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
        private readonly IServiciosObtenerBibliotecario _servicioObtenerBibliotecario;

        public GestorSolicitudes(
            IRepoSolicitud repoSolicitud,
            IUsuarios usuarios,
            IRepositorioLibro repositorioLibro,
            IServicioAuditoria servicioAuditoria,
            IRepositorioPrestamo repositorioPrestamo,
            IServicioNotificacion servicioNotificacion,
            IServicioPoliticaNegocio servicioPoliticaNegocio,
            IRepositorioEjemplar repositorioEjemplar,
            IServiciosObtenerBibliotecario servicioObtenerBibliotecario)
        {
            _repoSolicitud = repoSolicitud;
            _usuarios = usuarios;
            _repositorioLibro = repositorioLibro;
            _servicioAuditoria = servicioAuditoria;
            _repositorioPrestamo = repositorioPrestamo;
            _repositorioEjemplar = repositorioEjemplar;
            _servicioPoliticaNegocio = servicioPoliticaNegocio;
            _servicioObtenerBibliotecario = servicioObtenerBibliotecario;
        }

        public async Task<SolicitudResponseDTO> CrearSolicitudAsync(SolicitudRequestDTO peticion, int idUsuarioSolicitante)
        {

            foreach (var isbn in peticion.IsbnsLibros) {

                bool TienesSolicitud = await _repoSolicitud.ExisteSolicitudPendienteAsync(idUsuarioSolicitante, isbn);

                if (TienesSolicitud) {

                    throw new NegocioExeption($"No puedes procesar esta solicitud porque ya tiene una peticion en proceso del ejemplar {isbn}");
                }
            }
            
            if (peticion == null)
                throw new NegocioExeption("Los datos de la solicitud son obligatorios.");

            if (peticion.IsbnsLibros == null || !peticion.IsbnsLibros.Any())
                throw new NegocioExeption("Debe solicitar al menos un libro.");

            var usuario = await _usuarios.ObtenerUsuarioConDetallesAsync(idUsuarioSolicitante);

            if (usuario == null)
                throw new NegocioExeption("El usuario no está registrado en el sistema.");

            var ejemplaresSolicitados = await ObtenerEjemplaresSolicitadosAsync(peticion.IsbnsLibros);
            var prestamosActivos = await _repositorioPrestamo.ObtenerActivoPorUsuarioAsync(usuario.IdUsuario);

            _servicioPoliticaNegocio.ValidarCapacidadPrestamo(
                usuario,
                ejemplaresSolicitados.Count,
                prestamosActivos,
                "solicitar");

            foreach (var ejemplar in ejemplaresSolicitados)
            {
                ejemplar.MarcarComoReservado();
                await _repositorioEjemplar.ActualizarAsync(ejemplar);
            }

            var nuevaSolicitud = new Solicitud(usuario.IdUsuario, ejemplaresSolicitados);

            await _repoSolicitud.AgregarAsync(nuevaSolicitud);

            var titulosLibros = string.Join(", ", MapeoExtensiones.ObtenerTitulosLibros(ejemplaresSolicitados));
            await _servicioAuditoria.RegistrarAccionAsync(
                idResponsable: usuario.IdUsuario,
                tipoAccion: "Solicitud de préstamo",
                entidadAfectada: "Solicitudes",
                detalles: $"El usuario {usuario.Nombre} solicitó el préstamo de los libros: {titulosLibros}."
            );

            return MapearSolicitudResponse(nuevaSolicitud, usuario);
        }

        public async Task RechasarSolicitudAsync(RechazoSolicitudRequestDTO peticion, int idBibliotecarioResponsable)
        {
            if (peticion.idSolicitud <= 0)
                throw new NegocioExeption("Debe indicar el identificador de la solicitud que va a rechazar");

            if (string.IsNullOrWhiteSpace(peticion.MotivoRechazo))
                throw new NegocioExeption("Debe especificar el motivo del rechazo");

            var bibliotecario = await _servicioObtenerBibliotecario.ObtenerBibliotecarioPorIdAsync(idBibliotecarioResponsable);

            var solicitudARechazar = await _repoSolicitud.ObtenerSolicitudConDetallesAsync(peticion.idSolicitud);

            if (solicitudARechazar == null)
                throw new NegocioExeption("No se encontró ninguna solicitud.");

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
                bibliotecario.IdUsuario,
                solicitudARechazar.IdSolicitud,
                peticion.MotivoRechazo
            );

            await _repoSolicitud.ActualizarAsync(solicitudARechazar);
            await _repoSolicitud.GuardarResolucionAsync(rechazo);

            string nombreSolicitante = solicitudARechazar.Usuario?.Nombre ?? "un usuario";
            await _servicioAuditoria.RegistrarAccionAsync(
                idResponsable: bibliotecario.IdUsuario,
                tipoAccion: "Rechazar solicitud",
                entidadAfectada: "Solicitudes",
                detalles: $"El bibliotecario {bibliotecario.Nombre} rechazó la solicitud de libros de {nombreSolicitante}. Motivo: {peticion.MotivoRechazo}."
            );
        }

        public async Task<IEnumerable<SolicitudResponseDTO>> ConsultarMisSolicitudesPendientesAsync(int idUsuario)
        {
            var usuario = await _usuarios.ObtenerUsuarioConDetallesAsync(idUsuario);
            var solicitudes = await _repoSolicitud.ObtenerPendientesPorUsuarioAsync(idUsuario);

            return solicitudes.Select(s => MapearSolicitudResponse(s, usuario));
        }

        public async Task<SolicitudResponseDTO?> ObtenerPorIdAsync(int IdSolicitud)
        {
            if (IdSolicitud <= 0)
                throw new NegocioExeption("Debe ingresar el id de la solicitud para poder realizar la validación.");

            var solicitud = await _repoSolicitud.ObtenerSolicitudConDetallesAsync(IdSolicitud);

            if (solicitud == null)
                throw new NegocioExeption($"No se encontró la solicitud con id {IdSolicitud}");

            return MapearSolicitudResponse(solicitud, solicitud.Usuario);
        }

        public async Task<IEnumerable<SolicitudResponseDTO>> ConsultarPendientesAsync()
        {
            var solicitudes = await _repoSolicitud.ObtenerPendientesAsync();
            return solicitudes.Select(s => MapearSolicitudResponse(s, s.Usuario));
        }

        public async Task<IEnumerable<SolicitudResponseDTO>> ConsultarPorUsuarioAsync(string MatriculaONUmeroEmpleado)
        {
            var usuario = await ResolucionUsuario.ObtenerPorIdentificadorAsync(_usuarios, MatriculaONUmeroEmpleado);

            var solicitudes = await _repoSolicitud.ObtenerPorUsuarioAsync(usuario.IdUsuario);

            return solicitudes.Select(s => MapearSolicitudResponse(s, usuario));
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
                    throw new NegocioExeption($"El libro con ISBN {isbn} no está disponible actualmente.");

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
                Matricula = MapeoExtensiones.ObtenerMatricula(usuario),
                NumeroEmpleado = usuario?.NumeroEmpleado,
                ISBNs = MapeoExtensiones.ObtenerIsbns(solicitud.EjemplaresSolicitados),
                TitulosLibros = MapeoExtensiones.ObtenerTitulosLibros(solicitud.EjemplaresSolicitados)
            };
        }
    }
}
