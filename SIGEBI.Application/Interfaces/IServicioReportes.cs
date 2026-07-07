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
        Task<ReportePrestamosResponseDTO> GenerarReportesPrestamosAsync(DateTime FechaInicio, DateTime FechaFin);
        Task<ReporteInventarioResponseDTO> GenerarReporteInventarioAsync();

        Task<ReporteCatalogoResponseDTO> GenerarReporteUsoCatalogoAsync(DateTime FechaInicio, DateTime FechaFin);

        Task<ReportePenalizacionesDTO> GenerarPanalizacionesAsync(DateTime FechaInicio, DateTime FechaFin);

    }
}
