using SIGEBI.AppEscritorio.DTOs.Devoluciones;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGEBI.AppEscritorio.Services.Interfaces
{
    public interface IServicioDevolucionApi
    {
        Task<DevolucionResponseDTO?> ProcesarDevolucionAsync(DevolucionRequestDTO devolucion);
        Task<List<DevolucionResponseDTO>> ConsultarHistorialDevolucionesPorUsuarioAsync(string identificador);
        Task<List<DevolucionResponseDTO>> ConsultarHistorialDevolucionesPorRecursoAsync(string isbnLibro);

        Task<List<DevolucionResponseDTO>> ConsultarHistorialCompletoAsync();
    }
}