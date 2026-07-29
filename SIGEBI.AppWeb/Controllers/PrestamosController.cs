using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIGEBI.AppWeb.Models.Prestamos;
using SIGEBI.AppWeb.Services;
using System.Security.Claims;

namespace SIGEBI.AppWeb.Controllers
{
    [Authorize] // Solo requiere estar logueado
    public class PrestamosController : Controller
    {
        private readonly ServicioPrestamoApi _servicioPrestamoApi;
        private readonly ILogger<PrestamosController> _logger;

        public PrestamosController(ServicioPrestamoApi servicioPrestamoApi, ILogger<PrestamosController> logger)
        {
            _servicioPrestamoApi = servicioPrestamoApi;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            // Extraemos la matrícula directo del Token
            var identificador = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? User.Identity?.Name;

            if (string.IsNullOrWhiteSpace(identificador))
            {
                TempData["ErrorMessage"] = "No se pudo identificar su sesión de usuario.";
                return View(new List<PrestamoItemViewModel>());
            }

            try
            {
                // Solo consultamos los préstamos de ESTE usuario
                var prestamosDto = await _servicioPrestamoApi.ObtenerPrestamosPorUsuarioAsync(identificador);
                
                var modelo = prestamosDto.Select(p => new PrestamoItemViewModel
                {
                    IdPrestamo = p.IdPrestamo,
                    FechaInicio = p.FechaInicio,
                    FechaVencimiento = p.FechaVencimiento,
                    Estado = p.Estado,
                    DiasRetraso = p.DiasRetraso,
                    EstaVencido = p.EstaVencido
                }).ToList();
                return View(modelo);
            }
           
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al consultar préstamos para {Identificador}", identificador);
                TempData["ErrorMessage"] = "Ocurrió un error inesperado al cargar sus datos.";
                return View(new List<PrestamoItemViewModel>());
            }
        }

       
       
    }
}