using SIGEBI.Application.DTOs;
using SIGEBI.Application.Interfaces;
using SIGEBI.Domain.Entities;
using SIGEBI.Domain.Enums;
using SIGEBI.Domain.Exceptions;

namespace SIGEBI.Application.Services
{
    public class GestorDevoluciones : IServicioDevolucion
    {
        private readonly IRepositorioPrestamo _repoPrestamo;
        private readonly IRepositorioDevolucion _repoDevolucion;
        private readonly IServicioPenalizacion _servicioPenalizacion;
        private readonly IServicioAuditoria _servicioAuditoria;
        private readonly IUsuarios _usuarios;
        private readonly IServicioNotificacion _servicioNotificacion;
        private readonly IServiciosObtenerBibliotecario _serviciosObtenerBibliotecario;


        public GestorDevoluciones(
            IRepositorioPrestamo repoPrestamo,
            IRepositorioDevolucion repoDevolucion,
            IServicioPenalizacion servicioPenalizacion,
            IServicioAuditoria servicioAuditoria,
            IServicioNotificacion servicioNotificacion,
            IServiciosObtenerBibliotecario serviciosObtenerBibliotecario,
            IUsuarios usuario)
        {
            _repoPrestamo = repoPrestamo;
            _repoDevolucion = repoDevolucion;
            _servicioPenalizacion = servicioPenalizacion;
            _servicioAuditoria = servicioAuditoria;
            _usuarios = usuario;
            _servicioNotificacion = servicioNotificacion;
            _serviciosObtenerBibliotecario = serviciosObtenerBibliotecario;
        }

        public async Task<IEnumerable<DevolucionResponseDTO>> ConsultarHistorialDevolucionesPorRecurso(string isbnLibro)
        {
            var devoluciones =  await _repoDevolucion.ConsultarHistorialPorRecurso(isbnLibro);

            if(devoluciones == null || !devoluciones.Any())
                throw new NegocioExeption("No se encontraron devoluciones para el recurso especificado.");

            return devoluciones.Select(MapearDevolucionesResponse);
        }

        public async Task<IEnumerable<DevolucionResponseDTO>> ConsultarHistorialDevolucionesPorUsuario(string matriculaONumeroEmpleado)
        {
            var Usuario = await _usuarios.ObtenerPorMatriculaONumeroEmpleadoAsync(matriculaONumeroEmpleado);

            if (Usuario == null)
                throw new NegocioExeption("El usuario no fue encontrado.");

            var devoluciones = await _repoDevolucion.ConsultarHistorialPorUsuario(Usuario.IdUsuario);

            if (devoluciones == null || !devoluciones.Any())
                throw new NegocioExeption("No se encontraron devoluciones para el usuario especificado.");

            return devoluciones.Select(MapearDevolucionesResponse);
        }



        public async Task<DevolucionResponseDTO> ProcesarDevolucionAsync(DevolucionRequestDTO devolucion)
        {
            if (devolucion == null)
                throw new NegocioExeption("Los datos de la devolución son obligatorios.");

            if (devolucion.IdPrestamo <= 0)
                throw new NegocioExeption("El identificador del préstamo no es válido.");

            var bibliotecario = await _serviciosObtenerBibliotecario.ObtenerBibliotecarioAsync(
                devolucion.MatriculaONumeroEmpleadoBibliotecario
            );

            var prestamo = await _repoPrestamo.obtenerPrestamoConDetalleAsync(
                devolucion.IdPrestamo
            );

            if (prestamo == null)
                throw new NegocioExeption("El préstamo no fue encontrado.");

            if (prestamo.Estado != "Activo")
                throw new NegocioExeption("Solo se pueden devolver préstamos que estén activos.");

            var devolucionExistente = await _repoDevolucion.ObtenerPorPrestamoAsync(
                devolucion.IdPrestamo
            );

            if (devolucionExistente != null)
                throw new NegocioExeption("Este préstamo ya tiene una devolución registrada.");

            if (prestamo.EjemplaresAprestar == null || !prestamo.EjemplaresAprestar.Any())
                throw new NegocioExeption("El préstamo no tiene ejemplares asociados.");

            int diasRetraso = prestamo.CalcularDiasRetraso();
            bool generoPenalizacion = false;

            var nuevaDevolucion = new Devolucion(
              prestamo.IdPrestamo,
              bibliotecario.IdUsuario,
              devolucion.CondicionLibro,
              devolucion.Observaciones
             );

            if (diasRetraso > 0)
            {
                await _servicioPenalizacion.GenerarMultaPorRetrasoAsync(
                   prestamo.IdUsuario,
                   prestamo.IdPrestamo,
                   diasRetraso
                );

                generoPenalizacion = true;
            }

            if (nuevaDevolucion.RequierePenalizacionPorDano())
            {
                await _servicioPenalizacion.GenerarPenalizacionPorCondicionAsync(
                      prestamo.IdUsuario,
                      prestamo.IdPrestamo,
                      devolucion.CondicionLibro
                );

                generoPenalizacion = true;
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
                idResponsable: bibliotecario.IdUsuario,
                tipoAccion: "Registrar devolución",
                entidadAfectada: "Prestamo",
                detalles:
                    $"El bibliotecario {bibliotecario.Nombre} registró la devolución del préstamo #{prestamo.IdPrestamo}. " +
                    $"Condición: {devolucion.CondicionLibro}. " +
                    $"Días de retraso: {diasRetraso}. " +
                    $"Observaciones: {devolucion.Observaciones}"
            );
            await _servicioNotificacion.EnviarNotificacionAsync(
                bibliotecario.IdUsuario,
                $"El bibliotecario {bibliotecario.Nombre} registró la devolución del préstamo #{prestamo.IdPrestamo}. " +
                    $"Condición: {devolucion.CondicionLibro}. " +
                    $"Días de retraso: {diasRetraso}. " +
                    $"Observaciones: {devolucion.Observaciones}",
                TipoNotificacion.ConfirmacionDevolucion

                );

            return MapearDevolucionesResponse(
                nuevaDevolucion,
                prestamo,
                bibliotecario.IdUsuario,
                generoPenalizacion,
                diasRetraso
            );

            
        }
        private DevolucionResponseDTO MapearDevolucionesResponse(Devolucion devolucion)
        {
            if (devolucion.Prestamo == null)
                throw new NegocioExeption("La devolucion no tiene un prestamo asociado");

            return MapearDevolucionesResponse(
                devolucion,
                devolucion.Prestamo,
                0,
                false,
                0
            );
        }

        private DevolucionResponseDTO MapearDevolucionesResponse(
            Devolucion devolucion,
            Prestamo prestamo,
            int idBibliotecario,
            bool generoPenalizacion,
            int diasRetraso)
        {
            return new DevolucionResponseDTO
            {
                IdDevolucion = devolucion.IdDevolucion,
                IdPrestamo = devolucion.IdPrestamo,
                FechaDevolucion = devolucion.FechaDevolucion,
                CondicionLibro = devolucion.CondicionLibro.ToString(),
                Observaciones = devolucion.Observaciones,

                IdUsuario = prestamo.IdUsuario,

                NombreUsuario = prestamo.Usuario != null
                    ? prestamo.Usuario.Nombre
                    : string.Empty,

                IdBibliotecario = idBibliotecario,

                GeneroPenalizacion = generoPenalizacion,

                DiasRetraso = diasRetraso,

                TitulosLibros = prestamo.EjemplaresAprestar
                    .Where(e => e.Libro != null)
                    .Select(e => e.Libro!.Titulo)
                    .ToList()
            };
        }
    }
}
