using SIGEBI.AppWeb.Models.DTOs.Solicitudes;


namespace SIGEBI.AppWeb.Services.Interfaces
{
    public interface IServicioSolicitudApi
    {
        Task<SolicitudResponseDTO> CrearSolicitudAsync(SolicitudRequestDTO peticion);
    }
}
