using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIGEBI.Application.Interfaces;
using SIGEBI.AppWeb.Models.Auditoria;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SIGEBI.AppWeb.Controllers
{
    [Authorize(Roles = "Administrador,Auditor")]
    public class AuditoriaController : Controller
    {
        private readonly IServicioAuditoria _servicioAuditoria;
        private readonly ILogger<AuditoriaController> _logger;

        public AuditoriaController(IServicioAuditoria servicioAuditoria, ILogger<AuditoriaController> logger)
        {
            _servicioAuditoria = servicioAuditoria;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int? idResponsable, string? entidadAfectada)
        {
            try
            {
                // Llamamos a tu servicio pasándole los filtros (pueden ser nulos si es la primera vez que entra)
                var auditoriasDto = await _servicioAuditoria.ConsultarHistorialAsync(idResponsable, entidadAfectada);

                var modelo = auditoriasDto.Select(a => new AuditoriaItemViewModel
                {
                    IdAuditoria = a.IdAuditoria,
                    IdResponsable = a.IdResponsable,
                    FechaHora = a.FechaHora,
                    Accion = a.Accion,
                    EntidadAfectada = a.EntidadAfectada,
                    Detalles = a.Detalles
                }).ToList();

                // Guardamos los filtros en el ViewBag para mantenerlos en los inputs de texto de la vista
                ViewBag.IdResponsable = idResponsable;
                ViewBag.EntidadAfectada = entidadAfectada;

                return View(modelo);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al cargar el log de auditoría.");
                TempData["ErrorMessage"] = "Ocurrió un error inesperado al consultar los registros del sistema.";
                return View(new List<AuditoriaItemViewModel>());
            }
        }
    }
}