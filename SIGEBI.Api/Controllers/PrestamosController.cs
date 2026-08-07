using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIGEBI.Application.DTOs;
using SIGEBI.Application.Interfaces;
using System.Threading.Tasks;

namespace SIGEBI.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrestamosController : BaseController
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
            int idBibliotecarioResponsable = ObtenerIdResponsable();
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

        [HttpGet("historial/usuario/{identificador}")]
        [Authorize(Roles = "PersonalBibliotecario,Administrador,Auditor")]
        public async Task<IActionResult> ConsultarHistorialPrestamosPorUsuario(string identificador)
        {
            var resultado = await _iservicioPrestamo.ConsultarHistorialPorUsuarioAsync(identificador);
            return Ok(resultado);
        }

        [HttpGet("activos")]
        [Authorize(Roles = "PersonalBibliotecario,Administrador")]
        public async Task<IActionResult> ConsultarPrestamosActivos()
        {
            var resultado = await _iservicioPrestamo.ConsultarTodosAsync();
            return Ok(resultado);
        }

        [HttpGet("historial/todos")]
        [Authorize(Roles = "PersonalBibliotecario,Administrador,Auditor")]
        public async Task<IActionResult> ConsultarHistorialCompleto()
        {
            var resultado = await _iservicioPrestamo.ConsultarHistorialCompletoAsync();
            return Ok(resultado);
        }

        [HttpGet("busqueda-avanzada")]
        [Authorize(Roles = "PersonalBibliotecario,Administrador,Auditor")]
        public async Task<IActionResult> ConsultarHistorialAvanzado([FromQuery] string? termino, [FromQuery] string? estado)
        {
            var resultado = await _iservicioPrestamo.ConsultarHistorialAvanzadoAsync(termino, estado);
            return Ok(resultado);
        }

        [HttpGet("activos/busqueda")]
        [Authorize(Roles = "PersonalBibliotecario,Administrador,Estudiante,Docente")]
        public async Task<IActionResult> ConsultarActivosPorFiltro([FromQuery] string criterio, [FromQuery] string valor)
        {
            var resultado = await _iservicioPrestamo.ConsultarActivosPorFiltroAsync(criterio, valor ?? "");
            return Ok(resultado);
        }

        [HttpGet("mis-activos")]
        [Authorize(Roles = "Estudiante,Docente")]
        public async Task<IActionResult> ConsultarMisPrestamosActivos()
        {
            int idUsuario = ObtenerIdResponsable();
            var resultado = await _iservicioPrestamo.ConsultarPrestamosActivosPorIdUsuarioAsync(idUsuario);
            return Ok(resultado);
        }
    }
}