using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIGEBI.AppWeb.Models.DTOs.Solicitudes;
using SIGEBI.AppWeb.Models.Solicitudes;
using SIGEBI.AppWeb.Services.Interfaces;
using System.Security.Claims;

namespace SIGEBI.AppWeb.Controllers
{
    [Authorize(Roles = "Estudiante,Docente")]
    public class SolicitudesController : Controller
    {
        private readonly IServicioSolicitudApi _servicioSolicitud;
        private readonly ILogger<SolicitudesController> _logger;

        public SolicitudesController(IServicioSolicitudApi servicioSolicitud, ILogger<SolicitudesController> logger)
        {
            _servicioSolicitud = servicioSolicitud;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            // Llamada limpia: El backend se encarga de todo.
            var pendientes = await _servicioSolicitud.ConsultarMisSolicitudesPendientesAsync();
            return View(pendientes);
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

                var isbnsList = modelo.IsbnsIngresados
                    .Split(new[] { ',', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(i => i.Trim())
                    .ToList();

                var peticionDto = new SolicitudRequestDTO { IsbnsLibros = isbnsList };
                var resultado = await _servicioSolicitud.CrearSolicitudAsync(peticionDto);

              
                // Extraemos los títulos del DTO y los unimos en una sola cadena legible.
                var nombresLibros = resultado.TitulosLibros != null && resultado.TitulosLibros.Any()
                    ? string.Join(", ", resultado.TitulosLibros)
                    : "los recursos seleccionados";

                TempData["SuccessMessage"] = $"Tu solicitud de los ejemplares: '{nombresLibros}', ha sido enviada correctamente y se encuentra en revisión.";

                return RedirectToAction(nameof(Index));
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