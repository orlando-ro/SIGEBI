using SIGEBI.Application.DTOs;
using SIGEBI.Application.Interfaces;
using SIGEBI.Domain.Entities;
using SIGEBI.Domain.Exceptions;

namespace SIGEBI.Application.Services
{
    public class GestorDevoluciones : IServicioDevolucion
    {
        private readonly IRepositorioPrestamo _repoPrestamo;
        private readonly IRepositorioDevolucion _repoDevolucion;
        private readonly IServicioPenalizacion _servicioPenalizacion;
        private readonly IServicioAuditoria _servicioAuditoria;

        public GestorDevoluciones(
            IRepositorioPrestamo repoPrestamo,
            IRepositorioDevolucion repoDevolucion,
            IServicioPenalizacion servicioPenalizacion,
            IServicioAuditoria servicioAuditoria)
        {
            _repoPrestamo = repoPrestamo;
            _repoDevolucion = repoDevolucion;
            _servicioPenalizacion = servicioPenalizacion;
            _servicioAuditoria = servicioAuditoria;
        }

        public async Task<IEnumerable<DevolucionResponseDTO>> ConsultarHistorialDevolucionesPorRecurso(string isbnLibro)
        {
            var devoluciones =  await _repoDevolucion.ConsultarHistorialPorRecurso(isbnLibro);

            return devoluciones.Select(MapearDevolucionesResponse);
        }

        public async Task<IEnumerable<DevolucionResponseDTO>> ConsultarHistorialDevolucionesPorUsuario(string IdUsuario)
        {
            var devoluciones = await _repoDevolucion.ConsultarHistorialPorUsuario(IdUsuario);

            return devoluciones.Select(MapearDevolucionesResponse);
        }

        public async Task ProcesarDevolucionAsync(DevolucionRequestDTO peticion, string idBibliotecario)
        {
            
            var prestamo = await _repoPrestamo.obtenerPrestamoConDetalleAsync(peticion.IdPrestamo);
            if (prestamo == null)
                throw new NegocioExeption("El préstamo indicado no existe.");

            if (prestamo.Estado != "Activo")
                throw new NegocioExeption(" El prestamo ya fue devuelto o no esta activo");

            
            int diasRetraso = prestamo.CalcularDiasRetraso();

            
            prestamo.RegistrarDevolucion();

            
            var devolucion = new Devolucion(peticion.IdPrestamo, peticion.CondicionLibro, peticion.Observaciones);

            bool generoPenalizacion = false;

            
            if (diasRetraso > 0)
            {
                await _servicioPenalizacion.GenerarMultaPorRetrasoAsync(prestamo.IdUsuario, diasRetraso);

                 generoPenalizacion = true;
            }

            if (devolucion.RequierePenalizacionPorDano())
            {
               
                double tarifaDano = 500.0;
                var nuevaMultaDano = new Penalizacion(prestamo.IdUsuario, tarifaDano, $"Recurso dañado o extraviado: {peticion.CondicionLibro}");

                generoPenalizacion = true;
            }

           
            await _repoDevolucion.AgregarAsync(devolucion);
            await _repoPrestamo.ActualizarAsync(prestamo);

            
            await _servicioAuditoria.RegistrarAccionAsync(
                idBibliotecario,
                "Devolucion",
                "prestamo",
                $"Devolución procesada para Préstamo {peticion.IdPrestamo}. Retraso: {diasRetraso} días. Condición: {peticion.CondicionLibro}"
            );
        }

        private DevolucionResponseDTO MapearDevolucionesResponse(Devolucion devolucion) {

            return new DevolucionResponseDTO
            {

                IdDevolucion = devolucion.IdDevolucion,
                IdPrestamo = devolucion.IdPrestamo,
                FechaDevolucion = devolucion.FechaDevolucion,
                CondicionLibro = devolucion.CondicionLibro,
                Observaciones = devolucion.Observaciones,
                idusuario = devolucion.Prestamo.IdUsuario,
                NombreUsuario = devolucion.Prestamo.Usuario != null ? devolucion.Prestamo.Usuario.Nombre : string.Empty,
                TitulosLibros = devolucion.Prestamo.Libros.Select(l => l.Titulo).ToList()
            };
        }
    }
}
