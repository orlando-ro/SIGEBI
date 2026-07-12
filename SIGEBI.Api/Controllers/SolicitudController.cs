using Microsoft.AspNetCore.Mvc;
using SIGEBI.Application.DTOs;
using SIGEBI.Application.Interfaces;

namespace SIGEBI.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SolicitudesController : ControllerBase
    {
        private readonly IServicioSolicitud _iservicioSolicitud;

        public SolicitudesController(
            IServicioSolicitud iservicioSolicitud)
        {
            _iservicioSolicitud = iservicioSolicitud;
        }

        
        [HttpPost("crear")]
        public async Task<IActionResult> CrearSolicitud(
            [FromBody] SolicitudRequestDTO peticion)
        {
            var resultado = await _iservicioSolicitud
                .CrearSolicitudAsync(peticion);

            return Ok(resultado);
        }

       
        [HttpGet("{idSolicitud:int}")]
        public async Task<IActionResult> ObtenerSolicitudPorId(
            int idSolicitud)
        {
            var resultado = await _iservicioSolicitud
                .ObtenerPorIdAsync(idSolicitud);

            return Ok(resultado);
        }

        
        [HttpGet("pendientes")]
        public async Task<IActionResult> ConsultarSolicitudesPendientes()
        {
            var resultado = await _iservicioSolicitud
                .ConsultarPendientesAsync();

            return Ok(resultado);
        }

        
        [HttpGet("usuario/{identificador}")]
        public async Task<IActionResult> ConsultarSolicitudesPorUsuario(
            string identificador)
        {
            var resultado = await _iservicioSolicitud
                .ConsultarPorUsuarioAsync(identificador);

            return Ok(resultado);
        }

        
        [HttpPatch("rechazar")]
        public async Task<IActionResult> RechazarSolicitud(
            [FromBody] RechazoSolicitudRequestDTO peticion)
        {
            await _iservicioSolicitud
                .RechasarSolicitudAsync(peticion);

            return Ok(new
            {
                mensaje = "La solicitud fue rechazada correctamente."
            });
        }
    }
}