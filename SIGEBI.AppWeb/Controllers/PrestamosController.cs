using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIGEBI.Application.DTOs;
using SIGEBI.Application.Interfaces;
using SIGEBI.Domain.Exceptions;
using SIGEBI.AppWeb.Models.Prestamos;
using System.Security.Claims;

namespace SIGEBI.AppWeb.Controllers
{
    [Authorize]
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
        [Authorize(Roles = "PersonalBibliotecario,Administrador,Auditor,Estudiante,Docente")]
        public async Task<IActionResult> Index()
        {
            var rol = User.FindFirst(ClaimTypes.Role)?.Value;
            bool esUsuarioRegular = rol == "Estudiante" || rol == "Docente";

            if (esUsuarioRegular)
            {
                // Seguridad: Extraemos la matrícula directo del Token
                var identificador = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? User.Identity?.Name;

                if (!string.IsNullOrWhiteSpace(identificador))
                {
                    try
                    {
                        var prestamosDto = await _servicioPrestamo.ConsultarPrestamosActivosPorIdentificadorAsync(identificador);
                        ViewBag.EsUsuarioRegular = true;
                        return View(MapearLista(prestamosDto));
                    }
                    catch (NegocioExeption)
                    {
                        
                        ViewBag.EsUsuarioRegular = true;
                        return View(new List<PrestamoItemViewModel>());
                    }
                }
            }

            
            ViewBag.EsUsuarioRegular = false;
            return View(new List<PrestamoItemViewModel>());
        }

        [HttpGet]
        [Authorize(Roles = "PersonalBibliotecario")]
        public IActionResult Aprobar()
        {
            return View(new AprobarPrestamoViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "PersonalBibliotecario")]
        public async Task<IActionResult> Aprobar(AprobarPrestamoViewModel peticionWeb)
        {
            try
            {
                var claimId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? User.FindFirst("id")?.Value;

                if (!int.TryParse(claimId, out int idBibliotecarioResponsable))
                {
                    ModelState.AddModelError(string.Empty, "No se pudo obtener el ID del bibliotecario responsable.");
                    return View(peticionWeb);
                }

                var peticionDto = new PrestamoRequestDTO
                {
                    IdSolicitud = peticionWeb.IdSolicitud
                };

                var resultado = await _servicioPrestamo.AprobarYRegistrarPrestamoAsync(peticionDto, idBibliotecarioResponsable);

                TempData["SuccessMessage"] = $"¡Éxito! El préstamo #{resultado.IdPrestamo} para el usuario {resultado.NombreUsuario} ha sido aprobado.";
                return RedirectToAction("Index");
            }
            catch (NegocioExeption ex)
            {
                _logger.LogError(ex, "Error de negocio al aprobar el préstamo con solicitud ID {IdSolicitud}.", peticionWeb.IdSolicitud);
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(peticionWeb);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error inesperado al aprobar el préstamo.");
                ModelState.AddModelError(string.Empty, "Ocurrió un error inesperado en el servidor.");
                return View(peticionWeb);
            }
        }

        [HttpGet]
        [Authorize(Roles = "PersonalBibliotecario,Administrador,Estudiante,Docente")]
        public async Task<IActionResult> ActivosPorUsuario(string? identificador)
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
                    if (esUsuarioRegular) throw new NegocioExeption("No se pudo identificar su matrícula en el sistema.");
                    return View(new List<PrestamoItemViewModel>());
                }

                var prestamosDto = await _servicioPrestamo.ConsultarPrestamosActivosPorIdentificadorAsync(identificador);

                ViewBag.Busqueda = identificador;
                ViewBag.EsUsuarioRegular = esUsuarioRegular;

                return View(MapearLista(prestamosDto));
            }
            catch (NegocioExeption ex)
            {
                TempData["WarningMessage"] = ex.Message;
                ViewBag.Busqueda = identificador;
                ViewBag.EsUsuarioRegular = User.FindFirst(ClaimTypes.Role)?.Value == "Estudiante" || User.FindFirst(ClaimTypes.Role)?.Value == "Docente";
                return View(new List<PrestamoItemViewModel>());
            }
        }

        [HttpGet]
        [Authorize(Roles = "PersonalBibliotecario,Administrador,Estudiante,Docente")]
        public async Task<IActionResult> ActivosPorRecurso(string? isbnLibro)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(isbnLibro))
                    return View(new List<PrestamoItemViewModel>());

                var resultadoDto = await _servicioPrestamo.ConsultarPrestamosActivosPorRecursoAsync(isbnLibro);
                ViewBag.Busqueda = isbnLibro;
                return View(MapearLista(resultadoDto));
            }
            catch (NegocioExeption ex)
            {
                TempData["WarningMessage"] = ex.Message;
                ViewBag.Busqueda = isbnLibro;
                return View(new List<PrestamoItemViewModel>());
            }
        }

        [HttpGet]
        [Authorize(Roles = "PersonalBibliotecario,Administrador,Auditor")]
        public async Task<IActionResult> HistorialPorUsuario(string? identificador)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(identificador))
                    return View(new List<PrestamoItemViewModel>());

                var resultadoDto = await _servicioPrestamo.ConsultarHistorialPorUsuarioAsync(identificador);
                ViewBag.Busqueda = identificador;
                return View(MapearLista(resultadoDto));
            }
            catch (NegocioExeption ex)
            {
                TempData["WarningMessage"] = ex.Message;
                ViewBag.Busqueda = identificador;
                return View(new List<PrestamoItemViewModel>());
            }
        }

        [HttpGet]
        [Authorize(Roles = "PersonalBibliotecario,Administrador,Auditor")]
        public async Task<IActionResult> HistorialPorRecurso(string? isbnLibro)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(isbnLibro))
                    return View(new List<PrestamoItemViewModel>());

                var resultadoDto = await _servicioPrestamo.ConsultarHistorialPorRecursoAsync(isbnLibro);
                ViewBag.Busqueda = isbnLibro;
                return View(MapearLista(resultadoDto));
            }
            catch (NegocioExeption ex)
            {
                TempData["WarningMessage"] = ex.Message;
                ViewBag.Busqueda = isbnLibro;
                return View(new List<PrestamoItemViewModel>());
            }
        }

        private List<PrestamoItemViewModel> MapearLista(IEnumerable<PrestamoResponseDTO> dtos)
        {
            return dtos.Select(dto => new PrestamoItemViewModel
            {
                IdPrestamo = dto.IdPrestamo,
                NombreUsuario = dto.NombreUsuario,
                Matricula = dto.Matricula,
                NumeroEmpleado = dto.NumeroEmpleado,
                FechaInicio = dto.FechaInicio,
                FechaVencimiento = dto.FechaVencimiento,
                Estado = dto.Estado,
                DiasRetraso = dto.DiasRetraso,
                EstaVencido = dto.EstaVencido
            }).ToList();
        }
    }
}