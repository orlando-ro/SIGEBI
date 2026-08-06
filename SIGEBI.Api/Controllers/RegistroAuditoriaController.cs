using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SIGEBI.Application.Interfaces;
using System;
using System.Threading.Tasks;

namespace SIGEBI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Auditor,Administrador")]
    public class RegistroAuditoriaController : ControllerBase
    {
        private readonly IServicioAuditoria _servicioAuditoria;

        public RegistroAuditoriaController(IServicioAuditoria servicioAuditoria)
        {
            _servicioAuditoria = servicioAuditoria;
        }

        [HttpGet("ConsultarRegistrosAuditoria")]
        public async Task<IActionResult> ConsultarHistorialAuditoria(
            [FromQuery] DateTime? fechaInicio = null,
            [FromQuery] DateTime? fechaFin = null,
            [FromQuery] string? accion = null,
            [FromQuery] string? entidadAfectada = null)
        {
            var registros = await _servicioAuditoria.ConsultarHistorialAsync(fechaInicio, fechaFin, accion, entidadAfectada);
            return Ok(registros);
        }

        
        [HttpGet("ExportarPDF")]
        public async Task<IActionResult> ExportarPDF(
            [FromQuery] DateTime? fechaInicio = null,
            [FromQuery] DateTime? fechaFin = null,
            [FromQuery] string? accion = null,
            [FromQuery] string? entidadAfectada = null)
        {
            var pdfBytes = await _servicioAuditoria.ExportarHistorialPDFAsync(fechaInicio, fechaFin, accion, entidadAfectada);
            var nombreArchivo = $"Auditoria_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

            return File(pdfBytes, "application/pdf", nombreArchivo);
        }
    }
}