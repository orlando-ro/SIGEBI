using SIGEBI.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGEBI.Application.Interfaces
{
    public interface IServicioReportes
    {
        Task<ReporteResponseDTO> SolicitarGeneracionReporteAsync(ReporteRequestDTO peticion);

        Task<IEnumerable<ReporteResponseDTO>> ConsultarTodosAsync();

        Task<IEnumerable<ReporteResponseDTO>> ConsultarPendientesAsync();

        Task<IEnumerable<ReporteResponseDTO>> ConsultarPorEstadoAsync(string estado);

        Task<IEnumerable<ReporteResponseDTO>> ConsultarPorSolicitanteAsync(string matriculaONumeroEmpleado);

    }
}
