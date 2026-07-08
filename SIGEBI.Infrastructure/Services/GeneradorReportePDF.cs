using SIGEBI.Application.DTOs;
using SIGEBI.Application.Interfaces;

using SIGEBI.Domain.Entities;
namespace SIGEBI.Application.Services
{
    public class GeneradorReportePDF : IPDFService
    {
        private readonly IRepositorioReporte _repositorioReporte;


        public GeneradorReportePDF(IRepositorioReporte repositorioReporte)
        {

            _repositorioReporte = repositorioReporte;

        }

        public byte[] GenerarReporteInventarioPDF(ReporteInventarioResponseDTO reporte)
        {
            throw new NotImplementedException();
        }

        public byte[] GenerarReportePenalizacionesPDF(ReportePenalizacionesDTO reporte)
        {
            throw new NotImplementedException();
        }

        public byte[] GenerarReportePrestamosPDF(ReportePrestamosResponseDTO reporte)
        {
            throw new NotImplementedException();
        }

        public byte[] GenerarReporteUsoCatalogoPDF(ReporteCatalogoResponseDTO reporte)
        {
            throw new NotImplementedException();
        }
    }
}
