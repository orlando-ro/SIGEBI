using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIGEBI.AppWeb.Models.Penalizaciones;
using SIGEBI.AppWeb.Services.Interfaces;

namespace SIGEBI.AppWeb.Controllers
{
    [Authorize(Roles = "Estudiante,Docente")]
    public class PenalizacionesController : Controller
    {
        private readonly IServicioPenalizacionesApi _servicePenalizacionesApi;
        private readonly ILogger<PenalizacionesController> _logger;

        public PenalizacionesController(IServicioPenalizacionesApi servicioPenalizacion, ILogger<PenalizacionesController> logger)
        {
            _servicePenalizacionesApi = servicioPenalizacion;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                // Llamada limpia sin manipular Claims en el controlador
                var pendientesDto = await _servicePenalizacionesApi.ObtenerTodasPenalizacionesPendientes();

                var modelo = pendientesDto.Select(p => new PenalizacionItemViewModel
                {
                    IdPenalizacion = p.IdPenalizacion,
                    Monto = (double)p.Monto,
                    Motivo = p.Motivo,
                    FechaEmision = p.FechaEmision,
                    Pagada = false,
                    IdPrestamo = p.IdPrestamo,
                    NombreUsuario = p.NombreUsuario,
                    Identificador = p.Identificador
                }).ToList();

                return View(modelo);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al consultar las penalizaciones del usuario.");
                TempData["ErrorMessage"] = "Ocurrió un error al cargar sus datos.";
                return View(new List<PenalizacionItemViewModel>());
            }
        }
    }
}