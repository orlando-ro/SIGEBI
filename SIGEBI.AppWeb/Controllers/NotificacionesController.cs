using Microsoft.AspNetCore.Mvc;
using SIGEBI.AppWeb.Services;
using SIGEBI.AppWeb.Services.Interfaces;

namespace SIGEBI.AppWeb.Controllers
{
    public class NotificacionesController : Controller
    {
        private readonly IServicioNotificacionesApi _servicioNotificaciones;

        public NotificacionesController(IServicioNotificacionesApi servicioNotificaciones)
        {
            _servicioNotificaciones = servicioNotificaciones;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var notificaciones = await _servicioNotificaciones.ObtenerPendientesAsync();
            return View(notificaciones);
        }

        [HttpPost]
        public async Task<IActionResult> MarcarComoLeida(int id)
        {
            var exito = await _servicioNotificaciones.MarcarComoLeidaAsync(id);

            if (exito)
            {
                return RedirectToAction("Index");
            }

            TempData["ErrorMessage"] = "No se pudo marcar la notificación como leída.";
            return RedirectToAction("Index");
        }
    }
}