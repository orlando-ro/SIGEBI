using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIGEBI.Application.DTOs;
using SIGEBI.Application.Interfaces;
using SIGEBI.AppWeb.Models.Devoluciones;
using SIGEBI.Domain.Exceptions;
using System.Security.Claims;

namespace SIGEBI.AppWeb.Controllers
{
    public class DevolucionesController : Controller
    {
        private readonly IServicioDevolucion _servicioDevolucion;
        private readonly ILogger<DevolucionesController> _logger;

        public DevolucionesController(IServicioDevolucion servicioDevolucion, ILogger<DevolucionesController> logger)
        {
            _servicioDevolucion = servicioDevolucion;
            _logger = logger;
        }

        [HttpGet]
        [Authorize(Roles = "PersonalBibliotecario,Administrador,Auditor")]
        public IActionResult Index()
        {
            return View();
        }

        
        [HttpGet]
        [Authorize(Roles = "PersonalBibliotecario")]
        public IActionResult Registrar()
        {
            return View(new RegistrarDevolucionViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "PersonalBibliotecario")]
        public async Task<IActionResult> Registrar(RegistrarDevolucionViewModel modelo)
        {
            try
            {
                if (!ModelState.IsValid) return View(modelo);

                var claimId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? User.FindFirst("id")?.Value;
                if (!int.TryParse(claimId, out int idBibliotecario))
                {
                    ModelState.AddModelError(string.Empty, "Error de seguridad: No se pudo validar su identificador de bibliotecario.");
                    return View(modelo);
                }

                var peticionDto = new DevolucionRequestDTO
                {
                    IdPrestamo = modelo.IdPrestamo,
                    CondicionLibro = modelo.CondicionLibro,
                    Observaciones = modelo.Observaciones ?? string.Empty
                };

                var resultado = await _servicioDevolucion.ProcesarDevolucionAsync(peticionDto, idBibliotecario);

                string msjPenalizacion = resultado.GeneroPenalizacion ? " ⚠️ Se ha generado una penalización al usuario por condición o retraso." : "";
                TempData["SuccessMessage"] = $"Devolución #{resultado.IdDevolucion} registrada con éxito.{msjPenalizacion}";

                return RedirectToAction("Index");
            }
            catch (NegocioExeption ex)
            {
                _logger.LogWarning(ex, "Regla de negocio no cumplida al registrar devolución del préstamo {Id}", modelo.IdPrestamo);
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(modelo);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error inesperado al registrar devolución.");
                ModelState.AddModelError(string.Empty, "Ocurrió un error inesperado en el servidor.");
                return View(modelo);
            }
        }

        
        [HttpGet]
        [Authorize(Roles = "PersonalBibliotecario,Administrador,Auditor")]
        public async Task<IActionResult> HistorialPorUsuario(string? identificador)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(identificador))
                    return View(new List<DevolucionItemViewModel>());

                var devolucionesDto = await _servicioDevolucion.ConsultarHistorialDevolucionesPorUsuario(identificador);
                ViewBag.Busqueda = identificador;
                return View(MapearLista(devolucionesDto));
            }
            catch (NegocioExeption ex)
            {
                TempData["WarningMessage"] = ex.Message;
                ViewBag.Busqueda = identificador;
                return View(new List<DevolucionItemViewModel>());
            }
        }

        [HttpGet]
        [Authorize(Roles = "PersonalBibliotecario,Administrador,Auditor")]
        public async Task<IActionResult> HistorialPorRecurso(string? isbnLibro)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(isbnLibro))
                    return View(new List<DevolucionItemViewModel>());

                var devolucionesDto = await _servicioDevolucion.ConsultarHistorialDevolucionesPorRecurso(isbnLibro);
                ViewBag.Busqueda = isbnLibro;
                return View(MapearLista(devolucionesDto));
            }
            catch (NegocioExeption ex)
            {
                TempData["WarningMessage"] = ex.Message;
                ViewBag.Busqueda = isbnLibro;
                return View(new List<DevolucionItemViewModel>());
            }
        }

        // Helper de Mapeo
        private List<DevolucionItemViewModel> MapearLista(IEnumerable<DevolucionResponseDTO> dtos)
        {
            return dtos.Select(dto => new DevolucionItemViewModel
            {
                IdDevolucion = dto.IdDevolucion,
                IdPrestamo = dto.IdPrestamo,
                FechaDevolucion = dto.FechaDevolucion,
                CondicionLibro = dto.CondicionLibro,
                Observaciones = dto.Observaciones,
                NombreUsuario = dto.NombreUsuario,
                GeneroPenalizacion = dto.GeneroPenalizacion,
                DiasRetraso = dto.DiasRetraso,
                TitulosLibros = dto.TitulosLibros
            }).ToList();
        }
    }
}