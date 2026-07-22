using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIGEBI.Application.DTOs;
using SIGEBI.Application.Interfaces;
using SIGEBI.AppWeb.Models.Solicitudes;
using SIGEBI.Domain.Exceptions;
using System.Security.Claims;

namespace SIGEBI.AppWeb.Controllers
{
    public class SolicitudesController : Controller
    {
        private readonly IServicioSolicitud _servicioSolicitud;
        private readonly ILogger<SolicitudesController> _logger;

        public SolicitudesController(IServicioSolicitud servicioSolicitud, ILogger<SolicitudesController> logger)
        {
            _servicioSolicitud = servicioSolicitud;
            _logger = logger;
        }

        [HttpGet]
        [Authorize(Roles = "PersonalBibliotecario,Administrador,Estudiante,Docente")]
        public IActionResult Index()
        {
            return View();
        }

        // ==========================================
        // CREAR SOLICITUD (Solo Estudiantes y Docentes)
        // ==========================================
        [HttpGet]
        [Authorize(Roles = "Estudiante,Docente")]
        public IActionResult Crear()
        {
            return View(new CrearSolicitudViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Estudiante,Docente")]
        public async Task<IActionResult> Crear(CrearSolicitudViewModel modelo)
        {
            try
            {
                if (!ModelState.IsValid) return View(modelo);

                var claimId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? User.FindFirst("id")?.Value;
                if (!int.TryParse(claimId, out int idUsuarioSolicitante))
                {
                    ModelState.AddModelError(string.Empty, "Error de autenticación al obtener su identificador.");
                    return View(modelo);
                }

                // Parsear los ISBNs ingresados separados por coma
                var isbnsList = modelo.IsbnsIngresados
                    .Split(new[] { ',', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(i => i.Trim())
                    .ToList();

                var peticionDto = new SolicitudRequestDTO { IsbnsLibros = isbnsList };

                var resultado = await _servicioSolicitud.CrearSolicitudAsync(peticionDto, idUsuarioSolicitante);

                TempData["SuccessMessage"] = $"La solicitud #{resultado.IdSolicitud} ha sido creada correctamente y se encuentra pendiente de aprobación.";
                return RedirectToAction("Index");
            }
            catch (NegocioExeption ex)
            {
                _logger.LogWarning(ex, "Regla de negocio no cumplida al crear solicitud.");
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(modelo);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error inesperado al crear la solicitud.");
                ModelState.AddModelError(string.Empty, "Ocurrió un error inesperado en el servidor.");
                return View(modelo);
            }
        }

        // ==========================================
        // RECHAZAR SOLICITUD (Solo Bibliotecarios)
        // ==========================================
        [HttpGet]
        [Authorize(Roles = "PersonalBibliotecario")]
        public IActionResult Rechazar(int? id)
        {
            var modelo = new RechazarSolicitudViewModel();
            if (id.HasValue) modelo.IdSolicitud = id.Value;

            return View(modelo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "PersonalBibliotecario")]
        public async Task<IActionResult> Rechazar(RechazarSolicitudViewModel modelo)
        {
            try
            {
                if (!ModelState.IsValid) return View(modelo);

                var claimId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? User.FindFirst("id")?.Value;
                if (!int.TryParse(claimId, out int idBibliotecario))
                {
                    ModelState.AddModelError(string.Empty, "No se pudo validar el identificador del bibliotecario.");
                    return View(modelo);
                }

                var peticionDto = new RechazoSolicitudRequestDTO
                {
                    idSolicitud = modelo.IdSolicitud,
                    MotivoRechazo = modelo.MotivoRechazo
                };

                // Llamada respetando el nombre exacto de tu interfaz
                await _servicioSolicitud.RechasarSolicitudAsync(peticionDto, idBibliotecario);

                TempData["SuccessMessage"] = $"La solicitud #{modelo.IdSolicitud} ha sido rechazada exitosamente.";
                return RedirectToAction("Index");
            }
            catch (NegocioExeption ex)
            {
                _logger.LogWarning(ex, "Error de validación al rechazar la solicitud {Id}", modelo.IdSolicitud);
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(modelo);
            }
        }

        // ==========================================
        // CONSULTAS (Bibliotecarios y Administradores)
        // ==========================================
        [HttpGet]
        [Authorize(Roles = "PersonalBibliotecario,Administrador")]
        public async Task<IActionResult> Pendientes()
        {
            var solicitudesDto = await _servicioSolicitud.ConsultarPendientesAsync();
            return View(MapearLista(solicitudesDto));
        }

        [HttpGet]
        [Authorize(Roles = "PersonalBibliotecario,Administrador")]
        public async Task<IActionResult> ConsultarPorUsuario(string? identificador)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(identificador))
                    return View(new List<SolicitudItemViewModel>());

                var solicitudesDto = await _servicioSolicitud.ConsultarPorUsuarioAsync(identificador);
                ViewBag.Busqueda = identificador;
                return View(MapearLista(solicitudesDto));
            }
            catch (NegocioExeption ex)
            {
                TempData["WarningMessage"] = ex.Message;
                ViewBag.Busqueda = identificador;
                return View(new List<SolicitudItemViewModel>());
            }
        }

        // Helper de Mapeo
        private List<SolicitudItemViewModel> MapearLista(IEnumerable<SolicitudResponseDTO> dtos)
        {
            return dtos.Select(dto => new SolicitudItemViewModel
            {
                IdSolicitud = dto.IdSolicitud,
                FechaSolicitud = dto.FechaSolicitud,
                Estado = dto.Estado,
                NombreUsuarioSolicitante = dto.NombreUsuarioSolicitante,
                MatriculaONumeroEmpleado = dto.Matricula ?? dto.NumeroEmpleado ?? "N/A",
                ISBNs = dto.ISBNs,
                TitulosLibros = dto.TitulosLibros
            }).ToList();
        }
    }
}