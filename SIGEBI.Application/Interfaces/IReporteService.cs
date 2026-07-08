using SIGEBI.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGEBI.Application.Interfaces
{
    public interface IReporteService
    {
        Task<ReportePrestamosResponseDTO> ObtenerReportePrestamoAsync(DateTime Inicio, DateTime fin);

        Task<ReporteInventarioResponseDTO> ObtenerReportesInventarioAsync();

        Task<ReportePenalizacionesDTO> ObtenerReportesPenalizacionesAsync(DateTime Inicio, DateTime fin);
        Task<ReporteCatalogoResponseDTO> ObtenerReporteCatalogoAsync(DateTime Inicio, DateTime fin);


    }
}
