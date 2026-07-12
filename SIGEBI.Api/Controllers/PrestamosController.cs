using Microsoft.AspNetCore.Mvc;
using SIGEBI.Application.DTOs;
using SIGEBI.Application.Interfaces;


namespace SIGEBI.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PrestamosController : ControllerBase
    {
        private readonly IservicioPrestamo _iservicioPrestamo;

        public PrestamosController(IservicioPrestamo iservicioPrestamo)
        {
            _iservicioPrestamo = iservicioPrestamo;
        }


        [HttpPost("aprobar")]
        public async Task<IActionResult> AprobarYCrearPrestamo([FromBody] PrestamoRequestDTO peticion)
        {

            var resultado = await _iservicioPrestamo.AprobarYRegistrarPrestamoAsync(peticion);

            return Ok(resultado);
        }

        [HttpGet("activos/usuario/{identificador}")]
        public async Task<IActionResult> ConsultarPrestamosActivosPorUsuario(string identificador)
        {

            var resultado = await _iservicioPrestamo.ConsultarPrestamosActivosPorIdentificadorAsync(identificador);

            return Ok(resultado);

        }

        [HttpGet("activos/recurso/{IsbnLibro}")]
        public async Task<IActionResult> ConsultarPrestamosActivosPorRecurso(string IsbnLibro) { 
        
            var resultado = await _iservicioPrestamo.ConsultarPrestamosActivosPorRecursoAsync(IsbnLibro);
            return Ok(resultado);
        }

        [HttpGet("historial/usuario/{identificador}")]
        public async Task<IActionResult> ConsultarHistorialPrestamosPorUsuario(string identificador)
        {
            var resultado = await _iservicioPrestamo.ConsultarHistorialPorUsuarioAsync(identificador);

            return Ok(resultado);
        }

        [HttpGet("historial/recurso/{IsbnLibro}")]
        public async Task<IActionResult> ConsultarHistorialPrestamosPorRecurso(string IsbnLibro)
        {
            var resultado = await _iservicioPrestamo.ConsultarHistorialPorRecursoAsync(IsbnLibro);

            return Ok(resultado);
        }
    }
}

