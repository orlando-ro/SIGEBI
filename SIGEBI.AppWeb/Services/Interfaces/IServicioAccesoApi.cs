using SIGEBI.AppWeb.Models.DTOs.Acceso;

namespace SIGEBI.AppWeb.Services.Interfaces
{
    public interface IServicioAccesoApi
    {
        Task<string> IniciarSesionAsync(LoginRequestDTO credenciales);
    }
}
