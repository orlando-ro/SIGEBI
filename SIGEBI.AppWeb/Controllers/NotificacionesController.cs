using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIGEBI.Application.Interfaces;
using SIGEBI.AppWeb.Models.Notificaciones;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SIGEBI.AppWeb.Controllers
{
    [Authorize]
    public class NotificacionesController : Controller
    {
        private readonly IServicioNotificacion _servicioNotificacion;
        private readonly ILogger<NotificacionesController> _logger;

        public NotificacionesController(IServicioNotificacion servicioNotificacion, ILogger<NotificacionesController> logger)
        {
            _servicioNotificacion = servicioNotificacion;
            _logger = logger;
        }

        
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                int idUsuario = ObtenerIdUsuario();
                var dtos = await _servicioNotificacion.ObtenerPendientesAsync(idUsuario);

                
                var modelo = dtos.Select(n => new NotificacionItemViewModel
                {
                    Id = n.Id,
                    Mensaje = n.Mensaje,
                    FechaEnvio = n.FechaEnvio,
                    Tipo = n.Tipo,
                    Leida = n.Leida
                }).OrderByDescending(n => n.FechaEnvio).ToList();

                return View(modelo);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener notificaciones del usuario.");
                TempData["ErrorMessage"] = "No se pudieron cargar sus notificaciones en este momento.";
                return View(new List<NotificacionItemViewModel>());
            }
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MarcarLeida(int id)
        {
            try
            {
                await _servicioNotificacion.MarcarComoLeidaAsync(id);
                TempData["SuccessMessage"] = "Notificación archivada correctamente.";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al marcar la notificación {Id} como leída.", id);
                TempData["ErrorMessage"] = "Hubo un error al intentar actualizar la notificación.";
            }

            return RedirectToAction(nameof(Index));
        }

        
        [HttpGet]
        [Authorize(Roles = "Administrador,Auditor")]
        public async Task<IActionResult> HistorialGlobal(HistorialNotificacionesViewModel modeloFiltros)
        {
            try
            {
                
                var dtos = await _servicioNotificacion.ConsultarHistorialGlobalAsync();
                var query = dtos.AsEnumerable();

                
                if (!string.IsNullOrWhiteSpace(modeloFiltros.FiltroTipoEvento))
                {
                    query = query.Where(n => n.Tipo.Equals(modeloFiltros.FiltroTipoEvento, StringComparison.OrdinalIgnoreCase));
                }

                if (modeloFiltros.FechaInicio.HasValue)
                {
                    query = query.Where(n => n.FechaEnvio.Date >= modeloFiltros.FechaInicio.Value.Date);
                }

                if (modeloFiltros.FechaFin.HasValue)
                {
                    query = query.Where(n => n.FechaEnvio.Date <= modeloFiltros.FechaFin.Value.Date);
                }

               
                modeloFiltros.Notificaciones = query.Select(n => new NotificacionItemViewModel
                {
                    Id = n.Id,
                    Mensaje = n.Mensaje,
                    FechaEnvio = n.FechaEnvio,
                    Tipo = n.Tipo,
                    Leida = n.Leida
                }).OrderByDescending(n => n.FechaEnvio).ToList();

                return View(modeloFiltros);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al consultar el historial global de notificaciones.");
                TempData["ErrorMessage"] = "Ocurrió un error al cargar el historial del sistema.";
                return View(new HistorialNotificacionesViewModel());
            }
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> DispararRecordatorios(int diasAntelacion = 3)
        {
            try
            {
                await _servicioNotificacion.GenerarNotificacionesDeVencimientoAsync(diasAntelacion);
                TempData["SuccessMessage"] = $"El sistema ha generado notificaciones automáticas para los préstamos que vencen en {diasAntelacion} días.";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al ejecutar la generación de notificaciones de vencimiento.");
                TempData["ErrorMessage"] = "No se pudieron generar las notificaciones de vencimiento.";
            }

            return RedirectToAction(nameof(HistorialGlobal));
        }

        #region Helpers
        private int ObtenerIdUsuario()
        {
            var claim = User.FindFirst(ClaimTypes.NameIdentifier) ?? User.FindFirst("id");
            if (claim != null && int.TryParse(claim.Value, out int id)) return id;
            throw new UnauthorizedAccessException("Usuario no autenticado o token de seguridad inválido.");
        }
        #endregion
    }
}