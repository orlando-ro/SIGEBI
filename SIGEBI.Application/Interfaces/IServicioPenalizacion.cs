using SIGEBI.Application.DTOs;
using SIGEBI.Domain.Entities;
using SIGEBI.Domain.Enums;

namespace SIGEBI.Application.Interfaces
{
    public interface IServicioPenalizacion
    {
        Task GenerarMultaPorRetrasoAsync(
            int idUsuario,
            int idPrestamo,
            int diasRetraso);

        Task GenerarPenalizacionPorCondicionAsync(
            int idUsuario,
            int idPrestamo,
            CondicionDevolucion condicion);

        Task ProcesarPagoMultaAsync(
            int idPenalizacion,
            PenalizacionRequestDTO peticion,
            int idUsuarioResolutor);

        Task<IEnumerable<PenalizacionResponseDTO>> ObtenerPendientesPorUsuariosAsync(string MatriculaONumeroEmpleado);
    }
}

