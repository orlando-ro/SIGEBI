using SIGEBI.Application.DTOs;
using SIGEBI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGEBI.Application.Interfaces
{
    public interface IRepositorioReporte 

    {
        Task<ReportePrestamosResponseDTO> ObtenerReportesPrestamosAsync(DateTime FechaInicio, DateTime FechaFin);
        Task<ReporteInventarioResponseDTO> ObtenerReporteInventarioAsync();

        Task<ReporteCatalogoResponseDTO> ObtenerReporteUsoCatalogoAsync(DateTime FechaInicio, DateTime FechaFin);

        Task<ReportePenalizacionesDTO> ObtenerPenalizacionesAsync(DateTime FechaInicio, DateTime FechaFin);
        
    }
}
