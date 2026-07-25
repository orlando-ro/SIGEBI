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
        public async Task<IActionResult> Index()
        {
            var rol = User.FindFirst(ClaimTypes.Role)?.Value;
            bool esUsuarioRegular = rol == "Estudiante" || rol == "Docente";

            if (esUsuarioRegular)
            {
                // Seguridad: Extraemos el identificador directamente del Token
                var identificador = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? User.Identity?.Name;

                if (!string.IsNullOrWhiteSpace(identificador))
                {
                    try
                    {
                        var pendientesDto = await _servicioPenalizacion.ObtenerPendientesPorUsuariosAsync(identificador);
                        ViewBag.EsUsuarioRegular = true;
                        return View(pendientesDto);
                    }
                    catch (NegocioExeption)
                    {
                        // Si no hay deudas, mandamos lista vacía para mostrar el mensaje de felicitaciones
                        ViewBag.EsUsuarioRegular = true;
                        return View(new List<PenalizacionResponseDTO>());
                    }
                }
            }

            ViewBag.EsUsuarioRegular = false;
            return View(new List<PenalizacionResponseDTO>());
        }

        [HttpGet]
        [Authorize(Roles = "PersonalBibliotecario,Administrador,Estudiante,Docente")]
        public async Task<IActionResult> ConsultarPorUsuario(string? identificador)
        {
            try
            {
                var rol = User.FindFirst(ClaimTypes.Role)?.Value;
                bool esUsuarioRegular = rol == "Estudiante" || rol == "Docente";

                if (esUsuarioRegular)
                {
                    identificador = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? User.Identity?.Name;
                }

                if (string.IsNullOrWhiteSpace(identificador))
                {
                    if (esUsuarioRegular) throw new NegocioExeption("No se pudo identificar su matrícula.");
                    return RedirectToAction("Index");
                }

                var pendientesDto = await _servicioPenalizacion.ObtenerPendientesPorUsuariosAsync(identificador);
                ViewBag.Busqueda = identificador;
                ViewBag.EsUsuarioRegular = esUsuarioRegular;

                return View(pendientesDto);
            }
            catch (NegocioExeption ex)
            {
                ViewBag.Busqueda = identificador;
                ViewBag.EsUsuarioRegular = User.FindFirst(ClaimTypes.Role)?.Value == "Estudiante" || User.FindFirst(ClaimTypes.Role)?.Value == "Docente";

                if (!ViewBag.EsUsuarioRegular)
                {
                    TempData["SuccessMessage"] = ex.Message;
                    return RedirectToAction("Index");
                }

                return View(new List<PenalizacionResponseDTO>());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al consultar penalizaciones para {Identificador}", identificador);
                TempData["ErrorMessage"] = "Error inesperado en el servidor.";
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