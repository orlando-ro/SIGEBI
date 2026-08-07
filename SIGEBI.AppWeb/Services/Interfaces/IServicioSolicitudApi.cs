using SIGEBI.AppWeb.Models.DTOs.Solicitudes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGEBI.AppWeb.Services.Interfaces
{
    public interface IServicioSolicitudApi
    {
        Task<SolicitudResponseDTO> CrearSolicitudAsync(SolicitudRequestDTO peticion);
        Task<List<SolicitudResponseDTO>> ConsultarMisSolicitudesPendientesAsync();
    }
}