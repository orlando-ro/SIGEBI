using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SIGEBI.Application.Interfaces;
using SIGEBI.Domain.Exceptions;
using System;
using System.Threading.Tasks;

namespace SIGEBI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReportesController : ControllerBase
    {
        private readonly IRepositorioReporte _repositorioReporte;
        private readonly IPDFService _pdfService;
        private readonly IServicioAuditoria _servicioAuditoria;

        public ReportesController(
            IRepositorioReporte repositorioReporte,
            IPDFService pdfService,
            IServicioAuditoria servicioAuditoria)
        {
            _repositorioReporte = repositorioReporte;
            _pdfService = pdfService;
            _servicioAuditoria = servicioAuditoria;
        }

        [HttpGet("prestamos/pdf")]
        [Authorize(Roles = "Administrador,Auditor")]
        public async Task<IActionResult> GenerarReportePrestamosPDF(
            [FromQuery] DateTime fechaInicio,
            [FromQuery] DateTime fechaFin)
        {
            var rango = ValidarYNormalizarRango(fechaInicio, fechaFin);
            var reporte = await _repositorioReporte.ObtenerReportesPrestamosAsync(rango.FechaInicio, rango.FechaFin);
            var archivoPdf = _pdfService.GenerarReportePrestamosPDF(reporte);
            var nombreArchivo = $"ReportePrestamos_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

            return File(archivoPdf, "application/pdf", nombreArchivo);
        }

        [HttpGet("inventario/pdf")]
        [Authorize(Roles = "PersonalBibliotecario,Administrador,Auditor")]
        public async Task<IActionResult> GenerarReporteInventarioPDF()
        {
            var reporte = await _repositorioReporte.ObtenerReporteInventarioAsync();
            var archivoPdf = _pdfService.GenerarReporteInventarioPDF(reporte);
            var nombreArchivo = $"ReporteInventario_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

            return File(archivoPdf, "application/pdf", nombreArchivo);
        }

        [HttpGet("catalogo/pdf")]
        [Authorize(Roles = "Administrador,Auditor")]
        public async Task<IActionResult> GenerarReporteCatalogoPDF(
            [FromQuery] DateTime fechaInicio,
            [FromQuery] DateTime fechaFin)
        {
            var rango = ValidarYNormalizarRango(fechaInicio, fechaFin);
            var reporte = await _repositorioReporte.ObtenerReporteUsoCatalogoAsync(rango.FechaInicio, rango.FechaFin);
            var archivoPdf = _pdfService.GenerarReporteUsoCatalogoPDF(reporte);
            var nombreArchivo = $"ReporteUsoCatalogo_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

            return File(archivoPdf, "application/pdf", nombreArchivo);
        }

        [HttpGet("penalizaciones/pdf")]
        [Authorize(Roles = "Administrador,Auditor")]
        public async Task<IActionResult> GenerarReportePenalizacionesPDF(
            [FromQuery] DateTime fechaInicio,
            [FromQuery] DateTime fechaFin)
        {
            var rango = ValidarYNormalizarRango(fechaInicio, fechaFin);
            var reporte = await _repositorioReporte.ObtenerPenalizacionesAsync(rango.FechaInicio, rango.FechaFin);
            var archivoPdf = _pdfService.GenerarReportePenalizacionesPDF(reporte);
            var nombreArchivo = $"ReportePenalizaciones_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

            return File(archivoPdf, "application/pdf", nombreArchivo);
        }

        [HttpGet("auditoria/pdf")]
        [Authorize(Roles = "Administrador,Auditor")]
        public async Task<IActionResult> GenerarReporteAuditoriaPDF(
            [FromQuery] DateTime? fechaInicio = null,
            [FromQuery] DateTime? fechaFin = null,
            [FromQuery] string? accion = null,
            [FromQuery] string? entidadAfectada = null)
        {
            DateTime? inicioNorm = null;
            DateTime? finNorm = null;

            if (fechaInicio.HasValue && fechaFin.HasValue)
            {
                var rango = ValidarYNormalizarRango(fechaInicio.Value, fechaFin.Value);
                inicioNorm = rango.FechaInicio;
                finNorm = rango.FechaFin;
            }
            else if (fechaInicio.HasValue)
            {
                inicioNorm = fechaInicio.Value.Date;
            }
            else if (fechaFin.HasValue)
            {
                finNorm = fechaFin.Value.Date.AddDays(1).AddTicks(-1);
            }

            var archivoPdf = await _servicioAuditoria.ExportarHistorialPDFAsync(inicioNorm, finNorm, accion, entidadAfectada);
            var nombreArchivo = $"ReporteAuditoria_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

            return File(archivoPdf, "application/pdf", nombreArchivo);
        }

        
        private static (DateTime FechaInicio, DateTime FechaFin) ValidarYNormalizarRango(DateTime fechaInicio, DateTime fechaFin)
        {
            if (fechaInicio.Date > fechaFin.Date)
            {
                throw new NegocioExeption("La fecha de inicio no puede ser mayor que la fecha final.");
            }

            DateTime inicioNormalizado = fechaInicio.Date;
            DateTime finNormalizado = fechaFin.Date.AddDays(1).AddTicks(-1);

            return (inicioNormalizado, finNormalizado);
        }
    }
}