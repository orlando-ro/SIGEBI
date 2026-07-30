using SIGEBI.AppWeb.Models.DTOs.Notificaciones;

namespace SIGEBI.AppWeb.Services.Interfaces
{
    public interface IServicioNotificacionesApi
    {
        Task<IEnumerable<NotificacionResponseDTO>> ObtenerPendientesAsync();
        Task<bool> MarcarComoLeidaAsync(int id);
    }
}
