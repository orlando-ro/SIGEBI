using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SIGEBI.Application.DTOs;
using SIGEBI.Application.Interfaces;
using System.Security.Claims;

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
        [Authorize(Roles = "PersonalBibliotecario")]
        public async Task<IActionResult> AprobarYCrearPrestamo([FromBody] PrestamoRequestDTO peticion)
        {
            var claimId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? User.FindFirst("id")?.Value;
            int idBibliotecarioResponsable = int.Parse(claimId!);

            var resultado = await _iservicioPrestamo.AprobarYRegistrarPrestamoAsync(peticion, idBibliotecarioResponsable);

            return Ok(resultado);
        }

        [HttpGet("activos/usuario/{identificador}")]
        [Authorize(Roles = "PersonalBibliotecario,Administrador,Estudiante,Docente")]
        public async Task<IActionResult> ConsultarPrestamosActivosPorUsuario(string identificador)
        {
            var resultado = await _iservicioPrestamo.ConsultarPrestamosActivosPorIdentificadorAsync(identificador);
            return Ok(resultado);
        }

        [HttpGet("activos/recurso/{IsbnLibro}")]
        [Authorize(Roles = "PersonalBibliotecario,Administrador,Estudiante,Docente")]
        public async Task<IActionResult> ConsultarPrestamosActivosPorRecurso(string IsbnLibro)
        {
            var resultado = await _iservicioPrestamo.ConsultarPrestamosActivosPorRecursoAsync(IsbnLibro);
            return Ok(resultado);
        }

        [HttpGet("historial/usuario/{identificador}")]
        [Authorize(Roles = "PersonalBibliotecario,Administrador,Auditor")]
        public async Task<IActionResult> ConsultarHistorialPrestamosPorUsuario(string identificador)
        {
            var resultado = await _iservicioPrestamo.ConsultarHistorialPorUsuarioAsync(identificador);
            return Ok(resultado);
        }

        [HttpGet("historial/recurso/{IsbnLibro}")]
        [Authorize(Roles = "PersonalBibliotecario,Administrador,Auditor")]
        public async Task<IActionResult> ConsultarHistorialPrestamosPorRecurso(string IsbnLibro)
        {
            var resultado = await _iservicioPrestamo.ConsultarHistorialPorRecursoAsync(IsbnLibro);
            return Ok(resultado);
        }

        [HttpGet("activos")]
        [Authorize(Roles = "PersonalBibliotecario,Administrador")]

        public async Task<IActionResult> ConsultarPrestamosActivos()
        {

            var resultado = await _iservicioPrestamo.ConsultarTodosAsync();
            return Ok(resultado);

        }
    }
}