using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SIGEBI.Application.DTOs;
using SIGEBI.Application.Interfaces;

namespace SIGEBI.Infrastructure.Services
{
    public class ServicioNotificaciones : IServicioNotificacion
    {
        private readonly IRepositorioNotificacion _repoNoti;

        public ServicioNotificaciones(IRepositorioNotificacion repoNoti)
        {
            _repoNoti = repoNoti;
        }

        public async Task<IEnumerable<NotificacionResponseDTO>> ObtenerPendientesAsync(string idUsuario)
        {
            var pendientes = await _repoNoti.ObtenerNoLeidasPorUsuarioAsync(idUsuario);

            return pendientes.Select(n => new NotificacionResponseDTO
            {
                Id = n.IdNotificacion,
                Mensaje = n.Mensaje,
                FechaEnvio = n.FechaEnvio,
                Tipo = n.Tipo.ToString(),
                Leida = n.Leida
            });
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