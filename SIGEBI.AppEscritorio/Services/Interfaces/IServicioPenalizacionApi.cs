using SIGEBI.AppEscritorio.DTOs.Penalizaciones;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGEBI.AppEscritorio.Services.Interfaces
{
    public interface IServicioPenalizacionApi
    {
        Task ProcesarPagoMultaAsync(
          int idPenalizacion,
          PenalizacionRequestDTO peticion
          );

        Task<IEnumerable<PenalizacionResponseDTO>> ObtenerPendientesPorUsuariosAsync(string MatriculaONumeroEmpleado);

        Task<IEnumerable<PenalizacionResponseDTO>> ObtenerTodasPendientesAsync();
    }
}
