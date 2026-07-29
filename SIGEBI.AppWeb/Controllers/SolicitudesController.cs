using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIGEBI.AppWeb.Models.Solicitudes;
using System.Security.Claims;

namespace SIGEBI.AppWeb.Controllers
{
    [Authorize] // Aseguramos que se requiera login a nivel de clase
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
        public async Task<IActionResult> Index()
        {
            var identificador = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? User.Identity?.Name;

            if (string.IsNullOrWhiteSpace(identificador))
            {
                TempData["ErrorMessage"] = "No se pudo identificar su sesión de usuario.";
                return View(new List<SolicitudItemViewModel>());
            }

            try
            {
                // Obtenemos solo el historial de solicitudes de ESTE usuario
                var solicitudesDto = await _servicioSolicitud.ConsultarPorUsuarioAsync(identificador);
                return View(MapearLista(solicitudesDto));
            }
            catch (NegocioExeption)
            {
                // Si no tiene solicitudes, retornamos lista vacía
                return View(new List<SolicitudItemViewModel>());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al consultar solicitudes para {Identificador}", identificador);
                TempData["ErrorMessage"] = "Ocurrió un error inesperado al cargar su historial.";
                return View(new List<SolicitudItemViewModel>());
            }
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View(new CrearSolicitudViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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

                var isbnsList = modelo.IsbnsIngresados
                    .Split(new[] { ',', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(i => i.Trim())
                    .ToList();

                var peticionDto = new SIGEBI.Application.DTOs.SolicitudRequestDTO { IsbnsLibros = isbnsList };
                var resultado = await _servicioSolicitud.CrearSolicitudAsync(peticionDto, idUsuarioSolicitante);

                TempData["SuccessMessage"] = $"Tu solicitud #{resultado.IdSolicitud} ha sido enviada a la biblioteca y está en revisión.";
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
                ModelState.AddModelError(string.Empty, "Ocurrió un error inesperado al enviar tu solicitud.");
                return View(modelo);
            }
        }

        #region Helpers
        private List<SolicitudItemViewModel> MapearLista(IEnumerable<SIGEBI.Application.DTOs.SolicitudResponseDTO> dtos)
        {
            return dtos.Select(dto => new SolicitudItemViewModel
            {
                IdSolicitud = dto.IdSolicitud,
                FechaSolicitud = dto.FechaSolicitud,
                Estado = dto.Estado,
                ISBNs = dto.ISBNs,
                TitulosLibros = dto.TitulosLibros
            }).ToList();
        }
        #endregion
    }
}