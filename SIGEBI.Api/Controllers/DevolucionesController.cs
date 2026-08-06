using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SIGEBI.Application.Interfaces;
using SIGEBI.Application.DTOs;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SIGEBI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevolucionesController : ControllerBase
    {
        private readonly IServicioDevolucion _servicioDevolucion;

        public DevolucionesController(IServicioDevolucion servicioDevolucion)
        {
            _servicioDevolucion = servicioDevolucion;
        }

        [HttpGet("consultar/devoluciones/recurso/{tituloLibro}")]
        [Authorize(Roles = "PersonalBibliotecario,Administrador,Auditor")]
        public async Task<IActionResult> ConsultarHistorialDevolucionesPorRecurso(string tituloLibro, [FromQuery] string? condicion = "Todos")
        {
            var resultado = await _servicioDevolucion.ConsultarHistorialDevolucionesPorTituloLibroAsync(tituloLibro, condicion ?? "Todos");
            return Ok(resultado);
        }

        [HttpGet("consultar/devoluciones/usuario/{matriculaONumeroEmpleado}")]
        [Authorize(Roles = "PersonalBibliotecario,Administrador,Auditor")]
        public async Task<IActionResult> ConsultarHistorialDevolucionesPorUsuario(string matriculaONumeroEmpleado, [FromQuery] string? condicion = "Todos")
        {
            var resultado = await _servicioDevolucion.ConsultarHistorialDevolucionesPorUsuarioAsync(matriculaONumeroEmpleado, condicion ?? "Todos");
            return Ok(resultado);
        }

        [HttpGet("consultar/devoluciones/todas")]
        [Authorize(Roles = "PersonalBibliotecario,Administrador,Auditor")]
        public async Task<IActionResult> ConsultarHistorialCompleto([FromQuery] string? condicion = "Todos")
        {
            var resultado = await _servicioDevolucion.ConsultarHistorialCompletoAsync(condicion ?? "Todos");
            return Ok(resultado);
        }

        [HttpPost("Procesar/devolucion")]
        [Authorize(Roles = "PersonalBibliotecario,Administrador")]
        public async Task<IActionResult> ProcesarDevolucion([FromBody] DevolucionRequestDTO peticion)
        {
            var claimId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? User.FindFirst("id")?.Value;
            int idBibliotecarioResponsable = int.Parse(claimId!);

            var resultado = await _servicioDevolucion.ProcesarDevolucionAsync(peticion, idBibliotecarioResponsable);

            return Ok(resultado);
        }
    }
}