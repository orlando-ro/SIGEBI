using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIGEBI.Application.DTOs;
using SIGEBI.Application.Interfaces;
using SIGEBI.Domain.Exceptions;
using System.Security.Claims;

namespace SIGEBI.AppWeb.Controllers
{
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
        [Authorize(Roles = "PersonalBibliotecario")]
        public IActionResult Aprobar()
        {

            return View(new PrestamoRequestDTO());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "PersonalBibliotecario")]
        public async Task<IActionResult> Aprobar(PrestamoRequestDTO peticion)
        {
            try
            {

                var claimId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ??
                    User.FindFirst("id")?.Value;

                if (!int.TryParse(claimId, out int idBibliotecarioResponsable))
                {

                    ModelState.AddModelError(
                        string.Empty, "No se pudo obtener el ID del bibliotecario responsable.");
                    return View(peticion);
                }

                var resultado = await _servicioPrestamo.AprobarYRegistrarPrestamoAsync(peticion, idBibliotecarioResponsable);

                TempData["SuccessMessage"] = $"El préstamo con ID {resultado.IdPrestamo} ha sido aprobado y registrado exitosamente.";
                return RedirectToAction("Index", "Prestamos");
            }
            catch (NegocioExeption ex)
            {
                _logger.LogError(ex, "Error al aprobar el préstamo con ID {IdPrestamo}.", peticion);
                ModelState.AddModelError(string.Empty, $"No se encontró el préstamo con ID {peticion}.");
                return View(peticion);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error inesperado al aprobar el préstamo con ID {IdPrestamo}.", peticion);
                ModelState.AddModelError(string.Empty, "Ocurrió un error inesperado. Por favor, inténtelo de nuevo más tarde.");
                return View(peticion);
            }
        }

        [HttpGet]
        [Authorize(Roles = "PersonalBibliotecario,Administrador,Estudiante,Docente")]
        public async Task<IActionResult> ConsultarPrestamosActivosPorUsuario(string? identificador)
        {
            try
            {

                if (string.IsNullOrWhiteSpace(identificador))
                {
                    ModelState.AddModelError(string.Empty, "El identificador del usuario no puede estar vacío.");
                    return View(new List<PrestamoResponseDTO>());
                }
                var prestamos = await _servicioPrestamo.ConsultarPrestamosActivosPorIdentificadorAsync(identificador);

                ViewBag.IdentificadorUsuario = identificador;
                return View(prestamos);


            }
            catch (NegocioExeption ex)
            {
                _logger.LogWarning(ex, "Error al consultar préstamos activos por usuario.");

                TempData["Error"] = ex.Message;

                return View(new List<PrestamoResponseDTO>());
            }
        }
        [HttpGet]
        [Authorize(Roles = "PersonalBibliotecario,Administrador,Estudiante,Docente")]
        public async Task<IActionResult> ActivosPorRecurso(string? isbnLibro)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(isbnLibro))
                    return View(new List<PrestamoResponseDTO>());

                var resultado = await _servicioPrestamo
                    .ConsultarPrestamosActivosPorRecursoAsync(isbnLibro);

                ViewBag.ISBN = isbnLibro;

                return View(resultado);
            }
            catch (NegocioExeption ex)
            {
                _logger.LogWarning(ex, "Error al consultar préstamos activos por recurso.");

                TempData["Error"] = ex.Message;

                return View(new List<PrestamoResponseDTO>());
            }
        }

        [HttpGet]
        [Authorize(Roles = "PersonalBibliotecario,Administrador,Auditor")]
        public async Task<IActionResult> HistorialPorUsuario(string? identificador)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(identificador))
                    return View(new List<PrestamoResponseDTO>());

                var resultado = await _servicioPrestamo
                    .ConsultarHistorialPorUsuarioAsync(identificador);

                ViewBag.Identificador = identificador; 

                return View(resultado);
            }
            catch (NegocioExeption ex)
            {
                _logger.LogWarning(ex, "Error al consultar historial de préstamos por usuario.");

                TempData["Error"] = ex.Message;

                return View(new List<PrestamoResponseDTO>());
            }
        }

        [HttpGet]
        [Authorize(Roles = "PersonalBibliotecario,Administrador,Auditor")]
        public async Task<IActionResult> HistorialPorRecurso(string? isbnLibro)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(isbnLibro))
                    return View(new List<PrestamoResponseDTO>());

                var resultado = await _servicioPrestamo
                    .ConsultarHistorialPorRecursoAsync(isbnLibro);

                ViewBag.ISBN = isbnLibro;

                return View(resultado);
            }
            catch (NegocioExeption ex)
            {
                _logger.LogWarning(ex, "Error al consultar historial de préstamos por recurso.");

                TempData["Error"] = ex.Message;

                return View(new List<PrestamoResponseDTO>());
            }
        }
    }
}

