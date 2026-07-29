using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIGEBI.AppWeb.Models.DTOs.Solicitudes;
using SIGEBI.AppWeb.Models.Solicitudes; 
using SIGEBI.AppWeb.Services;
using System.Security.Claims;

namespace SIGEBI.AppWeb.Controllers
{
    [Authorize(Roles = "Estudiante,Docente")] // restringido a usuarios con rol "Estudiante" o "Docente" 
    public class SolicitudesController : Controller
    {
        private readonly ServicioSolicitudApi _servicioSolicitud;
        private readonly ILogger<SolicitudesController> _logger;

        public SolicitudesController(ServicioSolicitudApi servicioSolicitud, ILogger<SolicitudesController> logger)
        {
            _servicioSolicitud = servicioSolicitud;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index() 
        {
           return RedirectToAction(nameof(Crear));
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View(new CrearSolicitudViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(CrearSolicitudViewModel modelo)
        {
            try
            {
                if (!ModelState.IsValid) return View(modelo);

                // Procesamos los ISBNs ingresados separándolos por comas o saltos de línea
                var isbnsList = modelo.IsbnsIngresados
                    .Split(new[] { ',', '\n' }, StringSplitOptions.RemoveEmptyEntries) // sirve para separar los ISBNs por comas o saltos de línea
                    .Select(i => i.Trim())
                    .ToList();

                // Armamos el Request DTO local de la web
                var peticionDto = new SolicitudRequestDTO { IsbnsLibros = isbnsList };

                // Enviamos la petición POST a través del servicio HTTP
                var resultado = await _servicioSolicitud.CrearSolicitudAsync(peticionDto);

                TempData["SuccessMessage"] = $"Tu solicitud #{resultado.IdSolicitud} ha sido enviada correctamente y se encuentra en revisión.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Error al crear la solicitud vía API.");
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(modelo);
            }
        }

    }
}