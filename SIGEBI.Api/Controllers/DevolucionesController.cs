using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIGEBI.Application.Interfaces;
using SIGEBI.Application.DTOs;
using SIGEBI.Domain.Enums;

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

        [HttpGet("consultar/devoluciones/recurso/{isbnLibro}")]

        public async Task<IActionResult> ConsultarHistorialDevolucionesPorRecurso(string isbnLibro)
        {
            var resultado = await _servicioDevolucion.ConsultarHistorialDevolucionesPorRecurso(isbnLibro);

            return Ok(resultado);
        }

        [HttpGet("consultar/devoluciones/usuario/{matriculaONumeroEmpleado}")]
        public async Task<IActionResult> ConsultarHistorialDevolucionesPorUsuario(string matriculaONumeroEmpleado)
        {
            var resultado = await _servicioDevolucion.ConsultarHistorialDevolucionesPorUsuario(matriculaONumeroEmpleado);
            return Ok(resultado);
        }

        [HttpPost("Procesar/devolucion")]

        public async Task<IActionResult> ProcesarDevolucion([FromBody] DevolucionRequestDTO peticion)
        {
            var resultado = await _servicioDevolucion.ProcesarDevolucionAsync(peticion);

            return Ok(resultado);
        }
    }
}
