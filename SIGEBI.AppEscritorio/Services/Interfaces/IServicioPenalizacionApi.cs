using SIGEBI.AppEscritorio.DTOs.Penalizaciones;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGEBI.AppEscritorio.Services.Interfaces
{
    public interface IServicioPenalizacionApi
    {
        Task ProcesarPagoMultaAsync(int idPenalizacion, PenalizacionRequestDTO peticion);
        Task<IEnumerable<PenalizacionResponseDTO>> ObtenerPendientesPorUsuariosAsync(string MatriculaONumeroEmpleado);
        Task<IEnumerable<PenalizacionResponseDTO>> ObtenerTodasPendientesAsync();

        Task<IEnumerable<PenalizacionResponseDTO>> ObtenerHistorialPorUsuarioAsync(string identificador);
        Task<IEnumerable<PenalizacionResponseDTO>> ObtenerTodasHistorialAsync();
    }
}