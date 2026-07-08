using SIGEBI.Application.DTOs;
using SIGEBI.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGEBI.Application.Services
{
    public class GeneradorReportePantalla : IReporteService
    {
        private readonly IRepositorioReporte _repositorioReporte;

         public GeneradorReportePantalla( IRepositorioReporte repositorioReporte) 
         {
            _repositorioReporte = repositorioReporte;

        

         }
        public async Task<ReporteCatalogoResponseDTO> ObtenerReporteCatalogoAsync(DateTime Inicio, DateTime Fin)
        {
            return await _repositorioReporte.ObtenerReporteUsoCatalogoAsync(Inicio, Fin);
        }

        public async Task<ReportePrestamosResponseDTO> ObtenerReportePrestamoAsync(DateTime Inicio, DateTime Fin)
        {
            return await _repositorioReporte.ObtenerReportesPrestamosAsync(Inicio, Fin);
        }

        public async Task<ReporteInventarioResponseDTO> ObtenerReportesInventarioAsync()
        {
            return await _repositorioReporte.ObtenerReporteInventarioAsync();
        }

        public async Task<ReportePenalizacionesDTO> ObtenerReportesPenalizacionesAsync(DateTime Inicio, DateTime Fin)
        {
            return await _repositorioReporte.ObtenerPenalizacionesAsync(Inicio, Fin);
        }
    }
}
