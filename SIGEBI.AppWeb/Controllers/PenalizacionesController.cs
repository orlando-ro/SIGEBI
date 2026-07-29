using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIGEBI.AppWeb.Models.Penalizaciones;
using System.Security.Claims;
using System.Linq;
using SIGEBI.AppWeb.Services;

namespace SIGEBI.AppWeb.Controllers
{
    [Authorize]
    public class PenalizacionesController : Controller
    {
        private readonly ServicePenalizacionesApi _servicePenalizacionesApi;
        private readonly ILogger<PenalizacionesController> _logger;

        public PenalizacionesController(ServicePenalizacionesApi servicioPenalizacion, ILogger<PenalizacionesController> logger)
        {
            _servicePenalizacionesApi  = servicioPenalizacion;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var identificador = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? User.Identity?.Name;

            if (string.IsNullOrWhiteSpace(identificador))
            {
                TempData["ErrorMessage"] = "No se pudo identificar su sesión de usuario.";
                return View(new List<PenalizacionItemViewModel>());
            }

            try
            {
                var pendientesDto = await _servicePenalizacionesApi.ObtenerPenalizacionesPendientesPorUsuario(identificador);

               
                var modelo = pendientesDto.Select(p => new PenalizacionItemViewModel
                {
                    IdPenalizacion = p.IdPenalizacion,
                    IdPrestamo = p.IdPrestamo,
                    Monto = (double)p.Monto, 
                    Motivo = p.Motivo,
                    FechaEmision = p.FechaEmision,
                    Pagada = false, 
                    Identificador = identificador,
                    NombreUsuario = string.Empty  
                }).ToList();

                return View(modelo);
            }
           
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al consultar penalizaciones para {Identificador}", identificador);
                TempData["ErrorMessage"] = "Ocurrió un error al cargar sus datos.";
                return View(new List<PenalizacionItemViewModel>());
            }
        }
    }
}