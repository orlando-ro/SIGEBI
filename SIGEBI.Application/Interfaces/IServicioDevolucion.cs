using SIGEBI.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGEBI.Application.Interfaces
{
    public interface IServicioDevolucion
    {
        Task<DevolucionResponseDTO> ProcesarDevolucionAsync(DevolucionRequestDTO devolucion, int idBibliotecarioResponsable);

        Task<IEnumerable<DevolucionResponseDTO>> ConsultarHistorialDevolucionesPorUsuario(string matriculaONumeroEmpleado);

        Task<IEnumerable<DevolucionResponseDTO>> ConsultarHistorialDevolucionesPorRecurso(string isbnLibro);
    }
}