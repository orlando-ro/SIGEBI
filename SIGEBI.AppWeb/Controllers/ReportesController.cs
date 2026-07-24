using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIGEBI.Application.Interfaces;
using SIGEBI.Domain.Exceptions;
using System;
using System.Threading.Tasks;

namespace SIGEBI.AppWeb.Controllers
{
    [Authorize]
    public class ReportesController : Controller
    {
        private readonly IRepositorioReporte _repositorioReporte;
        private readonly IPDFService _pdfService;
        private readonly IServicioAuditoria _servicioAuditoria;
        private readonly ILogger<ReportesController> _logger;

        public ReportesController(
            IRepositorioReporte repositorioReporte,
            IPDFService pdfService,
            IServicioAuditoria servicioAuditoria,
            ILogger<ReportesController> logger)
        {
            _repositorioReporte = repositorioReporte;
            _pdfService = pdfService;
            _servicioAuditoria = servicioAuditoria;
            _logger = logger;
        }

        
        [HttpGet]
        [Authorize(Roles = "PersonalBibliotecario,Administrador,Auditor")]
        public IActionResult Index()
        {
            
            ViewBag.FechaInicio = DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd");
            ViewBag.FechaFin = DateTime.Now.ToString("yyyy-MM-dd");
            return View();
        }

        

        [HttpGet]
        [Authorize(Roles = "PersonalBibliotecario,Administrador,Auditor")]
        public async Task<IActionResult> DescargarInventario()
        {
            try
            {
                var reporte = await _repositorioReporte.ObtenerReporteInventarioAsync();
                var archivoPdf = _pdfService.GenerarReporteInventarioPDF(reporte);
                return File(archivoPdf, "application/pdf", $"ReporteInventario_{DateTime.Now:yyyyMMdd_HHmm}.pdf");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al generar reporte de inventario.");
                TempData["ErrorMessage"] = "Ocurrió un error al generar el documento de Inventario.";
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        [Authorize(Roles = "Administrador,Auditor")]
        public async Task<IActionResult> DescargarPrestamos(DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                var rango = ValidarYNormalizarRango(fechaInicio, fechaFin);
                var reporte = await _repositorioReporte.ObtenerReportesPrestamosAsync(rango.FechaInicio, rango.FechaFin);
                var archivoPdf = _pdfService.GenerarReportePrestamosPDF(reporte);

                return File(archivoPdf, "application/pdf", $"ReportePrestamos_{DateTime.Now:yyyyMMdd_HHmm}.pdf");
            }
            catch (NegocioExeption ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        [Authorize(Roles = "Administrador,Auditor")]
        public async Task<IActionResult> DescargarCatalogo(DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                var rango = ValidarYNormalizarRango(fechaInicio, fechaFin);
                var reporte = await _repositorioReporte.ObtenerReporteUsoCatalogoAsync(rango.FechaInicio, rango.FechaFin);
                var archivoPdf = _pdfService.GenerarReporteUsoCatalogoPDF(reporte);

                return File(archivoPdf, "application/pdf", $"ReporteCatalogo_{DateTime.Now:yyyyMMdd_HHmm}.pdf");
            }
            catch (NegocioExeption ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        [Authorize(Roles = "Administrador,Auditor")]
        public async Task<IActionResult> DescargarPenalizaciones(DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                var rango = ValidarYNormalizarRango(fechaInicio, fechaFin);
                var reporte = await _repositorioReporte.ObtenerPenalizacionesAsync(rango.FechaInicio, rango.FechaFin);
                var archivoPdf = _pdfService.GenerarReportePenalizacionesPDF(reporte);

                return File(archivoPdf, "application/pdf", $"ReportePenalizaciones_{DateTime.Now:yyyyMMdd_HHmm}.pdf");
            }
            catch (NegocioExeption ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        [Authorize(Roles = "Administrador,Auditor")]
        public async Task<IActionResult> DescargarAuditoria(int? idResponsable, string? entidadAfectada)
        {
            try
            {
                var archivoPdf = await _servicioAuditoria.ExportarHistorialPDFAsync(idResponsable, entidadAfectada);
                return File(archivoPdf, "application/pdf", $"LogAuditoria_{DateTime.Now:yyyyMMdd_HHmm}.pdf");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al exportar auditoría.");
                TempData["ErrorMessage"] = "No se pudo generar el log de auditoría.";
                return RedirectToAction("Index");
            }
        }

        // Helpers Privados
        private static (DateTime FechaInicio, DateTime FechaFin) ValidarYNormalizarRango(DateTime fechaInicio, DateTime fechaFin)
        {
            if (fechaInicio.Date > fechaFin.Date)
                throw new NegocioExeption("La fecha de inicio no puede ser mayor que la fecha final.");

            DateTime inicioNormalizado = fechaInicio.Date;
            DateTime finNormalizado = fechaFin.Date.AddDays(1).AddTicks(-1);

            return (inicioNormalizado, finNormalizado);
        }
    }
}