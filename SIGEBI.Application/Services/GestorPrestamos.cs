using SIGEBI.Application.Interfaces;
using SIGEBI.Application.DTOs;
using SIGEBI.Domain.Exceptions;
using SIGEBI.Domain.Entities;

namespace SIGEBI.Application.Services
{
    public class GestorPrestamos : IservicioPrestamo
    {
        private readonly IRepositorioPrestamo _repoPrestamo;
        private readonly IRepoSolicitud _repoSolicitud;
        private readonly IRepositorioLibro _repoLibro;
        private readonly IServicioPenalizacion _servicioPenalizacion;
        private readonly IServicioAuditoria _servicioAuditoria;

        public GestorPrestamos(
            IRepositorioPrestamo repoPrestamo,
            IRepoSolicitud repoSolicitud,
            IRepositorioLibro repoLibro,
            IServicioPenalizacion servicioPenalizacion,
            IServicioAuditoria servicioAuditoria)
        {
            _repoPrestamo = repoPrestamo;
            _repoSolicitud = repoSolicitud;
            _repoLibro = repoLibro;
            _servicioPenalizacion = servicioPenalizacion;
            _servicioAuditoria = servicioAuditoria;
        }

        public async Task AprobarYRegistrarPrestamoAsync(int idSolicitud, string idBibliotecario)
        {
           
            var solicitud = await _repoSolicitud.ObtenerSolicitudConDetallesAsync(idSolicitud);
            if (solicitud == null) throw new NegocioExeption("La solicitud no existe.");

            
            solicitud.Aprobar(); 

            
            var aprobacion = new Aprobacion
            {
                IdSolicitud = solicitud.IdSolicitud,
                IdBibliotecario = idBibliotecario,
                FechaResolucion = DateTime.Now
            };
            

            await _servicioAuditoria.RegistrarAccionAsync(
                idUsuario: idBibliotecario,
                tipoAccion: "Aprovacion",
                 entidadAfectada: "Prestamo",
                 detalles: $" Se registro el prestamo de la solicitud: ({idSolicitud})"
                );


            
            DateTime fechaInicio = DateTime.Now;
            DateTime fechaVencimiento = calcularFechaVencimiento(solicitud.IdUsuario, fechaInicio);

            var nuevoPrestamo = new Prestamo(
                solicitud.IdUsuario,
                fechaInicio,
                fechaVencimiento,
                new List<Libro>(solicitud.LibrosSolicitados)
            );

           
            foreach (var libro in solicitud.LibrosSolicitados)
            {
                libro.PrestarCopia();
                await _repoLibro.ActualizarAsync(libro); 
            }

            
            await _repoSolicitud.ActualizarAsync(solicitud);
            await _repoSolicitud.GuardarResolucionAsync(aprobacion);

            aprobacion.PrestamoGenerado = nuevoPrestamo; 
            await _repoPrestamo.AgregarAsync(nuevoPrestamo);

            

            await _servicioAuditoria.RegistrarAccionAsync(
                idUsuario: idBibliotecario,
                tipoAccion: "Registrar prestamo",
                 entidadAfectada: "Prestamo",
                 detalles: $" el bibliotecario con id: ({idBibliotecario}) registro el prestamo ({nuevoPrestamo})"
                );

        }

        public async Task ProcesarDevolucionAsync(int idPrestamo, string condicionLibro)
        {
           
            var prestamo = await _repoPrestamo.obtenerPrestamoConDetalleAsync(idPrestamo);
            if (prestamo == null) throw new NegocioExeption("El préstamo no fue encontrado.");

            
            int diasRetraso = prestamo.CalcularDiasRetraso();

           
            prestamo.RegistrarDevolucion();

           
            var devolucion = new Devolucion(idPrestamo, condicionLibro);

           
            if (diasRetraso > 0)
            {
                
                await _servicioPenalizacion.GenerarMultaPorRetrasoAsync(prestamo.IdUsuario, diasRetraso);
            }

           
            await _repoPrestamo.ActualizarAsync(prestamo);

            


        }

        public async Task<IEnumerable<PrestamoResponseDTO>> ConsultarPrestamosActivosPorUsuarioAsync(string idusuario) {

            var prestamos = await _repoPrestamo.ObtenerActivoPorUsuarioAsync(idusuario);
            return prestamos.Select(MapearPrestamoResponse);
        }

        public async Task<IEnumerable<PrestamoResponseDTO>> ConsultarPrestamosActivosPorRecursoAsync(string isbnLibro) {

            var prestamos = await _repoPrestamo.ObtenerActivosPorRecursoAsync(isbnLibro);
            return prestamos.Select(MapearPrestamoResponse);
        }

        public async Task<IEnumerable<PrestamoResponseDTO>> ConsultarHistorialPorRecursoAsync(string isbnLibro) {

            var prestamos = await _repoPrestamo.ObtenerHistorialPorRecurso(isbnLibro);
            return prestamos.Select(MapearPrestamoResponse);
        }

        public async Task<IEnumerable<PrestamoResponseDTO>> ConsultarHistorialPorUsuarioAsync(string idusuario) {

            var prestamos = await _repoPrestamo.ObtenerHistorialPorUsuarioAsync(idusuario);
            return prestamos.Select(MapearPrestamoResponse);
        }

        private PrestamoResponseDTO MapearPrestamoResponse(Prestamo prestamo)
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
                TitulosLibros = prestamo.Libros.Select(l => l.Titulo).ToList()
            };
        }

        private DateTime calcularFechaVencimiento(string idUsuario, DateTime fechaInicio) {

            return fechaInicio.AddDays(7);
        }
    }
}
