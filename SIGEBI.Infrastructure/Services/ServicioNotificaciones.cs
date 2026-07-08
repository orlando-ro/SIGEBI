using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SIGEBI.Application.DTOs;
using SIGEBI.Application.Interfaces;
using SIGEBI.Domain.Entities;

namespace SIGEBI.Infrastructure.Services
{
    public class ServicioNotificaciones : IServicioNotificacion
    {
        private readonly IRepositorioNotificacion _repoNoti;
        private readonly IRepositorioPrestamo _repoPrestamo;

        public ServicioNotificaciones(
            IRepositorioNotificacion repoNoti,
            IRepositorioPrestamo repoPrestamo)
        {
            _repoNoti = repoNoti;
            _repoPrestamo = repoPrestamo;
        }

        public async Task EnviarNotificacionAsync(int idUsuario, string mensaje, TipoNotificacion tipo)
        {
            var notificacion = new Notificacion
            {
                IdUsuario = idUsuario,
                Mensaje = mensaje,
                Tipo = tipo,
                FechaEnvio = DateTime.Now,
                Leida = false
            };

            await _repoNoti.AgregarAsync(notificacion);
        }

        public async Task GenerarNotificacionesDeVencimientoAsync(int diasAntelacion)
        {
            DateTime fechaObjetivo = DateTime.Today.AddDays(diasAntelacion);
            var prestamosAVencer = await _repoPrestamo.ObtenerActivosPorFechaVencimientoAsync(fechaObjetivo);

            if (!prestamosAVencer.Any()) return;

            foreach (var prestamo in prestamosAVencer)
            {
                var notificacion = new Notificacion
                {
                    IdUsuario = prestamo.IdUsuario,
                    Mensaje = $"Recordatorio: Tu préstamo vence el {prestamo.FechaVencimiento:dd/MM/yyyy}. Devuélvelo a tiempo.",
                    Tipo = TipoNotificacion.RecordatorioPrestamo,
                    FechaEnvio = DateTime.Now,
                    Leida = false
                };

                await _repoNoti.AgregarAsync(notificacion);
            }
        }

        public async Task<IEnumerable<NotificacionResponseDTO>> ConsultarHistorialGlobalAsync()
        {
            var historial = await _repoNoti.ObtenerTodoElHistorialAsync();

            return historial.Select(n => new NotificacionResponseDTO
            {
                Id = n.IdNotificacion,
                Mensaje = n.Mensaje,
                FechaEnvio = n.FechaEnvio,
                Tipo = n.Tipo.ToString(),
                Leida = n.Leida
            }).ToList();
        }

        public async Task<IEnumerable<NotificacionResponseDTO>> ObtenerPendientesAsync(int idUsuario)
        {
            var pendientes = await _repoNoti.ObtenerNoLeidasPorUsuarioAsync(idUsuario);
            return pendientes.Select(n => new NotificacionResponseDTO
            {
                Id = n.IdNotificacion,
                Mensaje = n.Mensaje,
                FechaEnvio = n.FechaEnvio,
                Tipo = n.Tipo.ToString(),
                Leida = n.Leida
            }).ToList();
        }

        public async Task MarcarComoLeidaAsync(int idNotificacion)
        {
            var notificacion = await _repoNoti.ObtenerPorIdAsync(idNotificacion);
            if (notificacion != null && !notificacion.Leida)
            {
                notificacion.MarcarComoLeida();
                await _repoNoti.ActualizarAsync(notificacion);
            }
        }
    }
}