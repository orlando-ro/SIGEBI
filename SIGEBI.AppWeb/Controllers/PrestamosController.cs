using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIGEBI.AppWeb.Models.Prestamos;
using System.Security.Claims;

namespace SIGEBI.AppWeb.Controllers
{
    [Authorize] // Solo requiere estar logueado
    public class PrestamosController : Controller
    {
        private readonly IservicioPrestamo _servicioPrestamo;
        private readonly ILogger<PrestamosController> _logger;

        public PrestamosController(IservicioPrestamo servicioPrestamo, ILogger<PrestamosController> logger)
        {
            _servicioPrestamo = servicioPrestamo;
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
                var prestamosDto = await _servicioPrestamo.ConsultarPrestamosActivosPorIdentificadorAsync(identificador);
                return View(MapearLista(prestamosDto));
            }
            catch (NegocioExeption)
            {
                // Si no tiene préstamos activos, la capa de negocio suele lanzar excepción. Devolvemos lista vacía.
                return View(new List<PrestamoItemViewModel>());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al consultar préstamos para {Identificador}", identificador);
                TempData["ErrorMessage"] = "Ocurrió un error inesperado al cargar sus datos.";
                return View(new List<PrestamoItemViewModel>());
            }
        }

        #region Helpers
        // Este mapeo está perfecto, lo conservamos tal cual lo tenías
        private List<PrestamoItemViewModel> MapearLista(IEnumerable<SIGEBI.Application.DTOs.PrestamoResponseDTO> dtos)
        {
            return dtos.Select(dto => new PrestamoItemViewModel
            {
                IdPrestamo = dto.IdPrestamo,
                FechaInicio = dto.FechaInicio,
                FechaVencimiento = dto.FechaVencimiento,
                Estado = dto.Estado,
                DiasRetraso = dto.DiasRetraso,
                EstaVencido = dto.EstaVencido
            }).ToList();
        }
        #endregion
    }
}