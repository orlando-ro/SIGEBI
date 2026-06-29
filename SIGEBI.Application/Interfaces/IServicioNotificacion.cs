using System.Collections.Generic;
using System.Threading.Tasks;
using SIGEBI.Application.DTOs;

namespace SIGEBI.Application.Interfaces
{
    public interface IServicioNotificacion
    {
        Task<IEnumerable<NotificacionResponseDTO>> ObtenerPendientesAsync(string idUsuario);
        Task MarcarComoLeidaAsync(int idNotificacion);
    }
}