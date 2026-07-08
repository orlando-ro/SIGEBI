using SIGEBI.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGEBI.Application.Interfaces
{
    public interface IPDFService
    {
        byte[] GenerarReportePrestamosPDF(ReportePrestamosResponseDTO reporte);
        byte[] GenerarReporteInventarioPDF(ReporteInventarioResponseDTO reporte);

        byte[] GenerarReporteUsoCatalogoPDF(ReporteCatalogoResponseDTO reporte);
        byte[] GenerarReportePenalizacionesPDF(ReportePenalizacionesDTO reporte);

        byte[] GenerarReporteAuditoriaPDF(IEnumerable<AuditoriaResponseDTO> auditorias);
    }
}
