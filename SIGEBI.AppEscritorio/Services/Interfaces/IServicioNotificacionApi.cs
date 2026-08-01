using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIGEBI.AppEscritorio.Models;

namespace SIGEBI.AppEscritorio.Services
{
    public interface IServicioNotificacionApi
    {
        Task<IEnumerable<NotificacionResponseDTO>> ObtenerPendientesAsync();
        Task<bool> MarcarComoLeidaAsync(int id);
        Task<IEnumerable<NotificacionResponseDTO>> ConsultarHistorialGlobalAsync();
        Task<bool> TriggerVencimientosAsync(int diasAntelacion = 3);
    }
}