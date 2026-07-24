using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIGEBI.Application.DTOs;
using SIGEBI.Application.Interfaces;
using SIGEBI.Domain.Exceptions;
using System.Security.Claims;

namespace SIGEBI.AppWeb.Controllers
{
    [Authorize]
    public class PenalizacionesController : Controller
    {
        private readonly IServicioPenalizacion _servicioPenalizacion;
        private readonly ILogger<PenalizacionesController> _logger;

        public PenalizacionesController(IServicioPenalizacion servicioPenalizacion, ILogger<PenalizacionesController> logger)
        {
            _servicioPenalizacion = servicioPenalizacion;
            _logger = logger;
        }

        [HttpGet]
        [Authorize(Roles = "PersonalBibliotecario,Administrador,Estudiante,Docente")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "PersonalBibliotecario,Administrador,Estudiante,Docente")]
        public async Task<IActionResult> ConsultarPorUsuario(string identificador)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(identificador))
                    return RedirectToAction("Index");

                var pendientesDto = await _servicioPenalizacion.ObtenerPendientesPorUsuariosAsync(identificador);
                ViewBag.Busqueda = identificador;

                return View(pendientesDto);
            }
            catch (NegocioExeption ex)
            {
                // Si el gestor lanza la excepción de que no hay penalizaciones, lo capturamos aquí
                TempData["SuccessMessage"] = "Excelente: " + ex.Message; // Usamos Success porque no deber nada es algo bueno
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error inesperado al consultar penalizaciones para {Identificador}", identificador);
                TempData["ErrorMessage"] = "Ocurrió un error inesperado al consultar los datos en el servidor.";
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        [Authorize(Roles = "PersonalBibliotecario,Administrador")]
        public IActionResult Resolver(int? id)
        {
            ViewBag.IdPenalizacion = id ?? 0;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "PersonalBibliotecario,Administrador")]
        public async Task<IActionResult> Resolver(int idPenalizacion, string identificador, string concepto)
        {
            try
            {
                var claimId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? User.FindFirst("id")?.Value;
                if (!int.TryParse(claimId, out int idUsuarioResolutor))
                {
                    TempData["ErrorMessage"] = "Error de autenticación.";
                    return RedirectToAction("Index");
                }

                
                var peticion = new PenalizacionRequestDTO
                {
                    MatriculaONumeroEmpleado = identificador,
                    MotivoResolucion = concepto
                };

                await _servicioPenalizacion.ProcesarPagoMultaAsync(idPenalizacion, peticion, idUsuarioResolutor);

                TempData["SuccessMessage"] = $"El pago de la penalización #{idPenalizacion} se registró exitosamente.";
                return RedirectToAction("Index");
            }
            catch (NegocioExeption ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }
    }
}