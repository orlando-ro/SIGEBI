using SIGEBI.AppWeb.Models.DTOs.Prestamos;

namespace SIGEBI.AppWeb.Services.Interfaces
{
    public interface IServicioPrestamoApi
    {
        Task<List<PrestamoResponseDTO>> ObtenerPrestamosPorUsuarioAsync(string identificador);

        Task<List<PrestamoResponseDTO>> ObtenerMisPrestamosActivosAsync();
    }
}
