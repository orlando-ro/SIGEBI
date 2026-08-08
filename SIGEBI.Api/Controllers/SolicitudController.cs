using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SIGEBI.Application.DTOs;
using SIGEBI.Application.Interfaces;

namespace SIGEBI.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    // 1. HEREDAMOS DE TU BASE CONTROLLER
    public class SolicitudesController : BaseController
    {
        private readonly IServicioSolicitud _iservicioSolicitud;

        public SolicitudesController(IServicioSolicitud iservicioSolicitud)
        {
            _iservicioSolicitud = iservicioSolicitud;
        }

        [HttpPost("crear")]
        [AllowAnonymous]
        [Authorize(Roles = "Estudiante,Docente")]
        public async Task<IActionResult> CrearSolicitud([FromBody] SolicitudRequestDTO peticion)
        {
            // 2. USAMOS TU MÉTODO HEREDADO
            int idUsuarioSolicitante = ObtenerIdResponsable();

            var resultado = await _iservicioSolicitud.CrearSolicitudAsync(peticion, idUsuarioSolicitante);
            return Ok(resultado);
        }

        [HttpGet("{idSolicitud:int}")]
        [Authorize(Roles = "PersonalBibliotecario,Administrador")]
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
        [Authorize(Roles = "PersonalBibliotecario,Administrador,Estudiante")]
        public async Task<IActionResult> ConsultarSolicitudesPorUsuario(string identificador)
        {
            var resultado = await _iservicioSolicitud.ConsultarPorUsuarioAsync(identificador);
            return Ok(resultado);
        }

        [HttpPatch("rechazar")]
        [Authorize(Roles = "PersonalBibliotecario,Administrador")]
        public async Task<IActionResult> RechazarSolicitud([FromBody] RechazoSolicitudRequestDTO peticion)
        {
            // 2. USAMOS TU MÉTODO HEREDADO
            int idBibliotecarioResponsable = ObtenerIdResponsable();

            await _iservicioSolicitud.RechasarSolicitudAsync(peticion, idBibliotecarioResponsable);

            return Ok(new { mensaje = "La solicitud fue rechazada correctamente." });
        }

        [HttpGet("mis-pendientes")]
        [Authorize(Roles = "Estudiante,Docente")]
        public async Task<IActionResult> ConsultarMisSolicitudesPendientes()
        {
            // 2. USAMOS TU MÉTODO HEREDADO
            int idUsuario = ObtenerIdResponsable();

            var resultado = await _iservicioSolicitud.ConsultarMisSolicitudesPendientesAsync(idUsuario);
            return Ok(resultado);
        }
    }
}