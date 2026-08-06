using SIGEBI.Application.DTOs;
using SIGEBI.Application.Helpers;
using SIGEBI.Application.Interfaces;
using SIGEBI.Domain.Entities;
using SIGEBI.Domain.Enums;
using SIGEBI.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public GestorDevoluciones(
            IRepositorioPrestamo repoPrestamo,
            IRepositorioDevolucion repoDevolucion,
            IServicioPenalizacion servicioPenalizacion,
            IServicioAuditoria servicioAuditoria,
            IServicioNotificacion servicioNotificacion,
            IUsuarios usuario)
        {
            _repoPrestamo = repoPrestamo;
            _repoDevolucion = repoDevolucion;
            _servicioPenalizacion = servicioPenalizacion;
            _servicioAuditoria = servicioAuditoria;
            _usuarios = usuario;
            _servicioNotificacion = servicioNotificacion;
        }

        // Método auxiliar para evitar repetir la validación del Enum
        private CondicionDevolucion? ObtenerCondicionFiltro(string condicionStr)
        {
            if (string.IsNullOrWhiteSpace(condicionStr) || condicionStr.Equals("Todos", StringComparison.OrdinalIgnoreCase))
                return null;

            if (Enum.TryParse<CondicionDevolucion>(condicionStr, true, out var parsedCondicion))
                return parsedCondicion;

            throw new NegocioExeption("El filtro de condición especificado no es válido.");
        }

        public async Task<IEnumerable<DevolucionResponseDTO>> ConsultarHistorialDevolucionesPorTituloLibroAsync(string tituloLibro, string condicionStr)
        {
            var condicion = ObtenerCondicionFiltro(condicionStr);
            var devoluciones = await _repoDevolucion.ConsultarHistorialPorTituloLibroAsync(tituloLibro, condicion);

            if (devoluciones == null || !devoluciones.Any())
                throw new NegocioExeption("No se encontraron devoluciones que coincidan con el libro especificado.");

            return devoluciones.Select(MapearDevolucionesResponse);
        }

        public async Task<IEnumerable<DevolucionResponseDTO>> ConsultarHistorialDevolucionesPorUsuarioAsync(string matriculaONumeroEmpleado, string condicionStr)
        {
            var Usuario = await ResolucionUsuario.ObtenerPorIdentificadorAsync(_usuarios, matriculaONumeroEmpleado);
            var condicion = ObtenerCondicionFiltro(condicionStr);
            var devoluciones = await _repoDevolucion.ConsultarHistorialPorUsuarioAsync(Usuario.IdUsuario, condicion);

            if (devoluciones == null || !devoluciones.Any())
                throw new NegocioExeption("No se encontraron devoluciones para el usuario especificado.");

            return devoluciones.Select(MapearDevolucionesResponse);
        }

        public async Task<IEnumerable<DevolucionResponseDTO>> ConsultarHistorialCompletoAsync(string condicionStr)
        {
            var condicion = ObtenerCondicionFiltro(condicionStr);
            var devoluciones = await _repoDevolucion.ConsultarHistorialCompletoAsync(condicion);

            if (devoluciones == null || !devoluciones.Any())
                throw new NegocioExeption("No hay devoluciones registradas con los criterios especificados.");

            return devoluciones.Select(MapearDevolucionesResponse);
        }

        public async Task<DevolucionResponseDTO> ProcesarDevolucionAsync(DevolucionRequestDTO devolucion, int idBibliotecarioResponsable)
        {
            if (devolucion == null) throw new NegocioExeption("Los datos de la devolución son obligatorios.");
            if (devolucion.IdPrestamo <= 0) throw new NegocioExeption("El identificador del préstamo no es válido.");

            var bibliotecario = await _usuarios.ObtenerUsuarioConDetallesAsync(idBibliotecarioResponsable);
            if (bibliotecario == null || bibliotecario is not PersonalBibliotecario)
                throw new NegocioExeption("Solo el personal bibliotecario puede registrar devoluciones.");

            var prestamo = await _repoPrestamo.obtenerPrestamoConDetalleAsync(devolucion.IdPrestamo);
            if (prestamo == null) throw new NegocioExeption("El préstamo no fue encontrado.");
            if (prestamo.Estado != "Activo") throw new NegocioExeption("Solo se pueden devolver préstamos que estén activos.");

            var devolucionExistente = await _repoDevolucion.ObtenerPorPrestamoAsync(devolucion.IdPrestamo);
            if (devolucionExistente != null) throw new NegocioExeption("Este préstamo ya tiene una devolución registrada.");

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
                await _servicioPenalizacion.GenerarMultaPorRetrasoAsync(prestamo.IdUsuario, prestamo.IdPrestamo, diasRetraso);
                generoPenalizacion = true;
            }

            if (nuevaDevolucion.RequierePenalizacionPorDano())
            {
                await _servicioPenalizacion.GenerarPenalizacionPorCondicionAsync(prestamo.IdUsuario, prestamo.IdPrestamo, devolucion.CondicionLibro);
                generoPenalizacion = true;
            }

            foreach (var ejemplar in prestamo.EjemplaresAprestar)
            {
                if (devolucion.CondicionLibro == CondicionDevolucion.BuenEstado)
                    ejemplar.HabilitarParaPrestamo();
                else
                    ejemplar.MarcarComoFueraDeServicio();
            }

            prestamo.RegistrarDevolucion();
            await _repoDevolucion.AgregarAsync(nuevaDevolucion);
            await _repoPrestamo.ActualizarAsync(prestamo);

            
            var titulosLibros = string.Join(", ", prestamo.EjemplaresAprestar.Where(e => e.Libro != null).Select(e => e.Libro!.Titulo));
            string nombreUsuario = prestamo.Usuario?.Nombre ?? "un usuario";

            await _servicioAuditoria.RegistrarAccionAsync(
                idResponsable: bibliotecario.IdUsuario,
                tipoAccion: "Registrar devolución",
                entidadAfectada: "Préstamos y Devoluciones",
                detalles: $"El bibliotecario {bibliotecario.Nombre} registró la devolución de los libros ({titulosLibros}) prestados a {nombreUsuario}. Condición: {devolucion.CondicionLibro}. Retraso: {diasRetraso} días."
            );

            await _servicioNotificacion.EnviarNotificacionAsync(
                bibliotecario.IdUsuario,
                $"El bibliotecario {bibliotecario.Nombre} registró la devolución de los libros ({titulosLibros}) prestados a {nombreUsuario}. " +
                $"Condición: {devolucion.CondicionLibro}. Retraso: {diasRetraso} días. Observaciones: {devolucion.Observaciones}",
                TipoNotificacion.ConfirmacionDevolucion
            );

            return new DevolucionResponseDTO
            {
                IdDevolucion = nuevaDevolucion.IdDevolucion,
                FechaDevolucion = nuevaDevolucion.FechaDevolucion,
                CondicionLibro = nuevaDevolucion.CondicionLibro.ToString(),
                Observaciones = nuevaDevolucion.Observaciones ?? string.Empty,
                NombreUsuario = prestamo.Usuario?.Nombre ?? string.Empty,
                GeneroPenalizacion = generoPenalizacion,
                DiasRetraso = diasRetraso,
                TitulosLibros = prestamo.EjemplaresAprestar.Where(e => e.Libro != null).Select(e => e.Libro!.Titulo).ToList()
            };
        }

        private DevolucionResponseDTO MapearDevolucionesResponse(Devolucion devolucion)
        {
            if (devolucion.Prestamo == null)
                throw new NegocioExeption("La devolucion no tiene un prestamo asociado");

           
            int diasRetraso = (devolucion.FechaDevolucion.Date - devolucion.Prestamo.FechaVencimiento.Date).Days;
            if (diasRetraso < 0) diasRetraso = 0;

            bool generoPenalizacion = diasRetraso > 0 || devolucion.RequierePenalizacionPorDano();

            return new DevolucionResponseDTO
            {
                IdDevolucion = devolucion.IdDevolucion,
                FechaDevolucion = devolucion.FechaDevolucion,
                NombreUsuario = devolucion.Prestamo.Usuario != null ? devolucion.Prestamo.Usuario.Nombre : string.Empty,
                CondicionLibro = devolucion.CondicionLibro.ToString(),
                Observaciones = devolucion.Observaciones ?? "Ninguna",
                GeneroPenalizacion = generoPenalizacion,
                DiasRetraso = diasRetraso,
                TitulosLibros = devolucion.Prestamo.EjemplaresAprestar
                    .Where(e => e.Libro != null)
                    .Select(e => e.Libro!.Titulo)
                    .ToList()
            };
        }
    }
}