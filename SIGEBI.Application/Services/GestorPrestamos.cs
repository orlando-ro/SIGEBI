using SIGEBI.Application.Interfaces;
using SIGEBI.Application.DTOs;
using SIGEBI.Domain.Exceptions;
using SIGEBI.Domain.Entities;

namespace SIGEBI.Application.Services
{
    public class GestorPrestamos : IservicioPrestamo, IServicioPoliticaNegocio, IServiciosObtenerBibliotecario
    {
        private readonly IRepositorioPrestamo _repoPrestamo;
        private readonly IRepoSolicitud _repoSolicitud;
        private readonly IRepositorioLibro _repoLibro;
        private readonly IServicioPenalizacion _servicioPenalizacion;
        private readonly IServicioAuditoria _servicioAuditoria;
        private readonly IUsuarios _usuario;

        public GestorPrestamos(
            IRepositorioPrestamo repoPrestamo,
            IRepoSolicitud repoSolicitud,
            IRepositorioLibro repoLibro,
            IServicioPenalizacion servicioPenalizacion,
            IServicioAuditoria servicioAuditoria,
            IUsuarios usuario)
        {
            _repoPrestamo = repoPrestamo;
            _repoSolicitud = repoSolicitud;
            _repoLibro = repoLibro;
            _servicioPenalizacion = servicioPenalizacion;
            _servicioAuditoria = servicioAuditoria;
            _usuario = usuario;
        }

        public async Task<PrestamoResponseDTO> AprobarYRegistrarPrestamoAsync(PrestamoRequestDTO peticion)
        {

            if (peticion == null)
                throw new NegocioExeption("Los datos de aprobación son obligatorios.");

            var bibliotecario = await ObtenerBibliotecarioAsync(
                peticion.MatriculaOnumeroEmpleado
            );

            var solicitud = await _repoSolicitud.ObtenerSolicitudConDetallesAsync(peticion.IdSolicitud);

            if (solicitud == null)
                throw new NegocioExeption("La solicitud no existe.");

            if (solicitud.Estado != "Pendiente")
                throw new NegocioExeption($"La solicitud no puede aprobarse porque está en estado '{solicitud.Estado}'.");

            if (solicitud.LibrosSolicitados == null || !solicitud.LibrosSolicitados.Any())
                throw new NegocioExeption("La solicitud no contiene libros solicitados.");

            var usuarioSolicitante = await _usuario.ObtenerUsuarioConDetallesAsync(solicitud.IdUsuario);

            if (usuarioSolicitante == null)
                throw new NegocioExeption("La solicitud no tiene un usuario solicitante válido.");

            usuarioSolicitante.ValidarElegibilidadParaPrestamo();

            int limitePrestamos = ObtenerLimitePrestamosPorTipoUsuario(usuarioSolicitante);

            if (limitePrestamos <= 0)
                throw new NegocioExeption("Este tipo de usuario no está autorizado para recibir préstamos.");

            var recursosActivos = await _repoPrestamo
                .ObtenerActivoPorUsuarioAsync(usuarioSolicitante.IdUsuario);
            int recursos = recursosActivos.Count();

            if (recursos + solicitud.LibrosSolicitados.Count > limitePrestamos)
            {
                throw new NegocioExeption(
                    $"No se puede aprobar la solicitud. " +
                    $"Límite permitido: {limitePrestamos}. " +
                    $"Recursos activos actuales: {recursosActivos}. " +
                    $"Libros solicitados: {solicitud.LibrosSolicitados.Count}.");
            }

            foreach (var libro in solicitud.LibrosSolicitados)
            {
                if (!libro.EstaDisponible())
                    throw new NegocioExeption($"No se puede aprobar la solicitud porque el libro '{libro.Titulo}' ya no tiene copias disponibles.");
            }

            DateTime fechaInicio = DateTime.Now;
            DateTime fechaVencimiento = calcularFechaVencimiento(usuarioSolicitante, fechaInicio);

            var nuevoPrestamo = new Prestamo(
                usuarioSolicitante.IdUsuario,
                fechaInicio,
                fechaVencimiento,
                solicitud.LibrosSolicitados.ToList()
            );

            foreach (var libro in solicitud.LibrosSolicitados)
            {
                libro.PrestarCopia();
                await _repoLibro.ActualizarAsync(libro);
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
                idUsuario: bibliotecario.IdUsuario,
                tipoAccion: "Aprobar préstamo",
                entidadAfectada: "Prestamo",
                detalles: $"El bibliotecario {bibliotecario.Nombre} aprobó la solicitud #{solicitud.IdSolicitud} y registró el préstamo #{nuevoPrestamo.IdPrestamo}."
            );

            return MapearPrestamoResponse(nuevoPrestamo, usuarioSolicitante);
        }

        
        

        public async Task<IEnumerable<PrestamoResponseDTO>> ConsultarPrestamosActivosPorIdentificadorAsync(string identificador) {


            var ObtenerUsuario = await _usuario.ObtenerPorMatriculaONumeroEmpleadoAsync(identificador);

            
            var prestamos = await _repoPrestamo.ObtenerActivoPorUsuarioAsync(ObtenerUsuario.IdUsuario);

            return prestamos.Select(p => MapearPrestamoResponse(p, p.Usuario));
        }

        public async Task<IEnumerable<PrestamoResponseDTO>> ConsultarPrestamosActivosPorRecursoAsync(string isbnLibro) {

            if (string.IsNullOrWhiteSpace(isbnLibro))
                throw new NegocioExeption("Debe ingresar el identificador (isbn) de algun libro");

            var prestamos = await _repoPrestamo.ObtenerActivosPorRecursoAsync(isbnLibro);


            return prestamos.Select(p => MapearPrestamoResponse(p, p.Usuario));
        }

        public async Task<IEnumerable<PrestamoResponseDTO>> ConsultarHistorialPorRecursoAsync(string isbnLibro) {

            if (string.IsNullOrWhiteSpace(isbnLibro))
                throw new NegocioExeption("Debe ingresar el identificador (isbn) de algun libro");

            var prestamos = await _repoPrestamo.ObtenerHistorialPorRecurso(isbnLibro);

            return prestamos.Select(p => MapearPrestamoResponse(p, p.Usuario));
        }

        public async Task<IEnumerable<PrestamoResponseDTO>> ConsultarHistorialPorUsuarioAsync(string identificador) {

            var ObtenerUsuario = await _usuario.ObtenerPorMatriculaONumeroEmpleadoAsync(identificador);

            var prestamos = await _repoPrestamo.ObtenerHistorialPorUsuarioAsync(ObtenerUsuario.IdUsuario);

            return prestamos.Select(p => MapearPrestamoResponse(p, p.Usuario));
        }

        

        private PrestamoResponseDTO MapearPrestamoResponse(Prestamo prestamo, Usuario usuario)
        {
            return new PrestamoResponseDTO
            {
                IdPrestamo = prestamo.IdPrestamo,
                FechaInicio = prestamo.FechaInicio,
                FechaVencimiento = prestamo.FechaVencimiento,
                Estado = prestamo.Estado,
                DiasRetraso = prestamo.CalcularDiasRetraso(),
                IdUsuario = prestamo.IdUsuario,
                NombreUsuario = prestamo.Usuario != null ? prestamo.Usuario.Nombre : string.Empty,
                TitulosLibros = prestamo.Libros.Select(l => l.Titulo).ToList(),
                Matricula = usuario is Estudiante estudiante ? estudiante.Matricula : null,
                NumeroEmpleado = usuario?.NumeroEmpleado,
                 ISBNs = prestamo.Libros.Select(l => l.ISBN).ToList()
            };
        }

        

        private DateTime calcularFechaVencimiento(Usuario usuario, DateTime fechaInicio) {

            if (usuario is Docente)
                return fechaInicio.AddDays(14);

            return fechaInicio.AddDays(7);
        }

        public int ObtenerLimitePrestamosPorTipoUsuario(Usuario usuario)
        {
            if (usuario is Docente)
                return 5;

            if (usuario is Estudiante)
                return 3;

            return 2;
                
        }

        public async Task<Usuario> ObtenerBibliotecarioAsync(string matriculaONumeroEmpleadoBibliotecario)
        {
            var usuario = await _usuario.ObtenerPorMatriculaONumeroEmpleadoAsync(matriculaONumeroEmpleadoBibliotecario);

            if (usuario is not PersonalBibliotecario)
                throw new NegocioExeption("Solo el personal bibliotecario puede aprobar, rechazar o registrar devoluciones.");

            return usuario;
        }
    }
}
