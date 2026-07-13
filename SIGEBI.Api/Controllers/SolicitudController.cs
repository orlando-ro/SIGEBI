using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SIGEBI.Application.DTOs;
using SIGEBI.Application.Interfaces;
using System.Security.Claims;

namespace SIGEBI.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SolicitudesController : ControllerBase
    {
        private readonly IServicioSolicitud _iservicioSolicitud;

        public SolicitudesController(IServicioSolicitud iservicioSolicitud)
        {
            _iservicioSolicitud = iservicioSolicitud;
        }

        [HttpPost("crear")]
        [Authorize(Roles = "Estudiante,Docente")]
        public async Task<IActionResult> CrearSolicitud([FromBody] SolicitudRequestDTO peticion)
        {
            var claimId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? User.FindFirst("id")?.Value;
            int idUsuarioSolicitante = int.Parse(claimId!);

            var resultado = await _iservicioSolicitud.CrearSolicitudAsync(peticion, idUsuarioSolicitante);
            return Ok(resultado);
        }

        [HttpGet("{idSolicitud:int}")]
        [Authorize(Roles = "PersonalBibliotecario,Administrador,Estudiante,Docente")]
        public async Task<IActionResult> ObtenerSolicitudPorId(int idSolicitud)
        {
            var resultado = await _iservicioSolicitud.ObtenerPorIdAsync(idSolicitud);
            return Ok(resultado);
        }

        [HttpGet("pendientes")]
        [Authorize(Roles = "PersonalBibliotecario,Administrador")]
        public async Task<IActionResult> ConsultarSolicitudesPendientes()
        {
            var resultado = await _iservicioSolicitud.ConsultarPendientesAsync();
            return Ok(resultado);
        }

        [HttpGet("usuario/{identificador}")]
        [Authorize(Roles = "PersonalBibliotecario,Administrador,Estudiante,Docente")]
        public async Task<IActionResult> ConsultarSolicitudesPorUsuario(string identificador)
        {
            var resultado = await _iservicioSolicitud.ConsultarPorUsuarioAsync(identificador);
            return Ok(resultado);
        }

        [HttpPatch("rechazar")]
        [Authorize(Roles = "PersonalBibliotecario")]
        public async Task<IActionResult> RechazarSolicitud([FromBody] RechazoSolicitudRequestDTO peticion)
        {
            var claimId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? User.FindFirst("id")?.Value;
            int idBibliotecarioResponsable = int.Parse(claimId!);

            await _iservicioSolicitud.RechasarSolicitudAsync(peticion, idBibliotecarioResponsable);

            return Ok(new
            {
                mensaje = "La solicitud fue rechazada correctamente."
            });
        }
    }
}