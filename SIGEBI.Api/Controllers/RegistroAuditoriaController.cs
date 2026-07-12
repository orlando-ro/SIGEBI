using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIGEBI.Application.Interfaces;

namespace SIGEBI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistroAuditoriaController : ControllerBase
    {
        private readonly IServicioAuditoria _servicioAuditoria;
        public RegistroAuditoriaController(IServicioAuditoria servicioAuditoria)
        {
            _servicioAuditoria = servicioAuditoria;
        }

        [HttpGet("ConsultarRegistrosAuditoria")]

        public async Task<IActionResult> ConsultarHistorialAuditoria([FromQuery] int? idResponsable = null, [FromQuery] string? entidadAfectada = null)
        {
            var registros = await _servicioAuditoria.ConsultarHistorialAsync(idResponsable, entidadAfectada);

            return Ok(registros);
        }

    }
}
