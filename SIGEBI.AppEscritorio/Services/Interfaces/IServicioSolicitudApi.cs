using SIGEBI.AppEscritorio.DTOs.Solicitudes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGEBI.AppEscritorio.Services.Interfaces
{
    public interface IServicioSolicitudApi
    {
        Task RechazarSolicitudAsync(RechazoSolicitudRequestDTO peticion);
        Task<SolicitudResponseDTO?> ObtenerPorIdAsync(int idSolicitud);
        Task<List<SolicitudResponseDTO>> ConsultarPendientesAsync();
        Task<List<SolicitudResponseDTO>> ConsultarPorUsuarioAsync(string identificador);
    }
}