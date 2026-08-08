using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIGEBI.AppWeb.Models.Prestamos;
using SIGEBI.AppWeb.Services.Interfaces;

namespace SIGEBI.AppWeb.Controllers
{
    [Authorize(Roles = "Estudiante,Docente")]
    public class PrestamosController : Controller
    {
        private readonly IServicioPrestamoApi _servicioPrestamoApi;
        private readonly ILogger<PrestamosController> _logger;

        public PrestamosController(IServicioPrestamoApi servicioPrestamoApi, ILogger<PrestamosController> logger)
        {
            _servicioPrestamoApi = servicioPrestamoApi;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var prestamosDto = await _servicioPrestamoApi.ObtenerMisPrestamosActivosAsync();

                var modelo = prestamosDto.Select(p => new PrestamoItemViewModel
                {
                    IdPrestamo = p.IdPrestamo,
                    FechaInicio = p.FechaInicio,
                    FechaVencimiento = p.FechaVencimiento,
                    Estado = p.Estado,
                    DiasRetraso = p.DiasRetraso,
                    EstaVencido = p.EstaVencido,

                    TituloLibro = p.TitulosLibros != null && p.TitulosLibros.Any()
                        ? string.Join(", ", p.TitulosLibros)
                        : "Recurso bibliotecario"
                }).ToList();

                return View(modelo);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al consultar los préstamos activos del usuario.");
                TempData["ErrorMessage"] = "Ocurrió un error inesperado al cargar sus datos.";
                return View(new List<PrestamoItemViewModel>());
            }
        }
    }
}