using SIGEBI.AppEscritorio.DTOs.Devoluciones;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGEBI.AppEscritorio.Services.Interfaces
{
    public interface IServicioDevolucionApi
    {
        Task<DevolucionResponseDTO?> ProcesarDevolucionAsync(DevolucionRequestDTO devolucion);

       
        Task<List<DevolucionResponseDTO>> ConsultarHistorialDevolucionesPorUsuarioAsync(string identificador, string condicion);
        Task<List<DevolucionResponseDTO>> ConsultarHistorialDevolucionesPorTituloLibroAsync(string tituloLibro, string condicion);
        Task<List<DevolucionResponseDTO>> ConsultarHistorialCompletoAsync(string condicion);
    }
}