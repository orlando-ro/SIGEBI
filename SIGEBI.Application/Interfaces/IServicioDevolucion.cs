using SIGEBI.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGEBI.Application.Interfaces
{
    public interface IServicioDevolucion
    {
        Task<DevolucionResponseDTO> ProcesarDevolucionAsync(DevolucionRequestDTO devolucion, int idBibliotecarioResponsable);

        Task<IEnumerable<DevolucionResponseDTO>> ConsultarHistorialDevolucionesPorUsuarioAsync(string matriculaONumeroEmpleado, string condicionStr);
        Task<IEnumerable<DevolucionResponseDTO>> ConsultarHistorialDevolucionesPorTituloLibroAsync(string tituloLibro, string condicionStr);
        Task<IEnumerable<DevolucionResponseDTO>> ConsultarHistorialCompletoAsync(string condicionStr);
    }
}