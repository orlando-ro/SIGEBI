using SIGEBI.Application.DTOs;
using SIGEBI.Application.Interfaces;
using SIGEBI.Domain.Entities;
using SIGEBI.Domain.Enums;
using SIGEBI.Domain.Exceptions;

namespace SIGEBI.Application.Services
{
    public class GestorDevoluciones : IServicioDevolucion, IServiciosObtenerBibliotecario
    {
        private readonly IRepositorioPrestamo _repoPrestamo;
        private readonly IRepositorioDevolucion _repoDevolucion;
        private readonly IServicioPenalizacion _servicioPenalizacion;
        private readonly IServicioAuditoria _servicioAuditoria;
        private readonly IUsuarios _usuarios;

        public GestorDevoluciones(
            IRepositorioPrestamo repoPrestamo,
            IRepositorioDevolucion repoDevolucion,
            IServicioPenalizacion servicioPenalizacion,
            IServicioAuditoria servicioAuditoria,
            IUsuarios usuario)
        {
            _repoPrestamo = repoPrestamo;
            _repoDevolucion = repoDevolucion;
            _servicioPenalizacion = servicioPenalizacion;
            _servicioAuditoria = servicioAuditoria;
            _usuarios = usuario;
        }

        public async Task<IEnumerable<DevolucionResponseDTO>> ConsultarHistorialDevolucionesPorRecurso(string isbnLibro)
        {
            var devoluciones =  await _repoDevolucion.ConsultarHistorialPorRecurso(isbnLibro);

            return devoluciones.Select(MapearDevolucionesResponse);
        }

        public async Task<IEnumerable<DevolucionResponseDTO>> ConsultarHistorialDevolucionesPorUsuario(string matriculaONumeroEmpleado)
        {
            var Usuario = await _usuarios.ObtenerPorMatriculaONumeroEmpleadoAsync(matriculaONumeroEmpleado);

            var devoluciones = await _repoDevolucion.ConsultarHistorialPorUsuario(Usuario.IdUsuario);

            return devoluciones.Select(MapearDevolucionesResponse);
        }

        public async Task<Usuario> ObtenerBibliotecarioAsync(string matriculaONumeroEmpleadoBibliotecario)
        {
            var usuario = await _usuarios.ObtenerPorMatriculaONumeroEmpleadoAsync(matriculaONumeroEmpleadoBibliotecario);

            if (usuario is not PersonalBibliotecario)
                throw new NegocioExeption("Solo el personal bibliotecario puede aprobar, rechazar o registrar devoluciones.");

            return usuario;
        }



        public async Task ProcesarDevolucionAsync(DevolucionRequestDTO devolucion)
        {

            if (devolucion == null)
                throw new NegocioExeption("Los datos de la devolución son obligatorios.");

            if (devolucion.IdPrestamo <= 0)
                throw new NegocioExeption("El identificador del préstamo no es válido.");

            var bibliotecario = await ObtenerBibliotecarioAsync(
                devolucion.MatriculaONumeroEmpleadoBibliotecario
            );

            var prestamo = await _repoPrestamo.obtenerPrestamoConDetalleAsync(devolucion.IdPrestamo);

            if (prestamo == null)
                throw new NegocioExeption("El préstamo no fue encontrado.");

            int diasRetraso = prestamo.CalcularDiasRetraso();

            var nuevaDevolucion = new Devolucion(
                prestamo.IdPrestamo,
                devolucion.CondicionLibro,
                devolucion.Observaciones
            );

            if (diasRetraso > 0)
            {
                await _servicioPenalizacion.GenerarMultaPorRetrasoAsync(
                    prestamo.IdUsuario,
                    diasRetraso
                );
            }

            if (nuevaDevolucion.RequierePenalizacionPorDano())
            {
                await _servicioPenalizacion.GenerarPenalizacionPorCondicionAsync(
                    prestamo.IdUsuario,
                    devolucion.CondicionLibro
                );
            }

            foreach (var ejemplar in prestamo.EjemplaresAprestar)
            {
                if (devolucion.CondicionLibro == CondicionDevolucion.BuenEstado)
                {
                    ejemplar.HabilitarParaPrestamo();
                }
                else
                {
                    ejemplar.MarcarComoFueraDeServicio();
                }
            }

            prestamo.RegistrarDevolucion();

            await _repoDevolucion.AgregarAsync(nuevaDevolucion);
            await _repoPrestamo.ActualizarAsync(prestamo);

            await _servicioAuditoria.RegistrarAccionAsync(
                idUsuario: bibliotecario.IdUsuario,
                tipoAccion: "Registrar devolución",
                entidadAfectada: "Prestamo",
                detalles:
                    $"El bibliotecario {bibliotecario.Nombre} registró la devolución del préstamo #{prestamo.IdPrestamo}. " +
                    $"Condición: {devolucion.CondicionLibro}. " +
                    $"Días de retraso: {diasRetraso}. " +
                    $"Observaciones: {devolucion.Observaciones}"
            );
        }

        private DevolucionResponseDTO MapearDevolucionesResponse(Devolucion devolucion) {

            return new DevolucionResponseDTO
            {
                IdDevolucion = devolucion.IdDevolucion,
                IdPrestamo = devolucion.IdPrestamo,
                FechaDevolucion = devolucion.FechaDevolucion,
                CondicionLibro = devolucion.CondicionLibro.ToString(),
                Observaciones = devolucion.Observaciones,

                idusuario = devolucion.Prestamo.IdUsuario,
                NombreUsuario = devolucion.Prestamo.Usuario != null
             ? devolucion.Prestamo.Usuario.Nombre
             : string.Empty,

                TitulosLibros = devolucion.Prestamo.EjemplaresAprestar
             .Where(e => e.Libro != null)
             .Select(e => e.Libro!.Titulo)
             .ToList()
            };
        }
    }
}
