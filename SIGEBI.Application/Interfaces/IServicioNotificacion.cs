using SIGEBI.Application.DTOs;
using SIGEBI.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGEBI.Application.Interfaces
{
    public interface IServicioNotificacion
    {
        Task<IEnumerable<NotificacionResponseDTO>> ObtenerPendientesAsync(int idUsuario);
        Task MarcarComoLeidaAsync(int idNotificacion);
        Task EnviarNotificacionAsync(int idUsuario, string mensaje, TipoNotificacion tipo);
        Task GenerarNotificacionesDeVencimientoAsync(int diasAntelacion);
        Task<IEnumerable<NotificacionResponseDTO>> ConsultarHistorialGlobalAsync();
    }
}