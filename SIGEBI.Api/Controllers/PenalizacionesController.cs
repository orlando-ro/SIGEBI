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
    [Authorize]
    public class PenalizacionesController : ControllerBase
    {
        private readonly IServicioPenalizacion _servicioPrenalizacion;

        public PenalizacionesController(IServicioPenalizacion servicioPrenalizacion)
        {
            _servicioPrenalizacion = servicioPrenalizacion;
        }

        [HttpPatch("RegistrarPago/{idPenalizacion}")]
        [Authorize(Roles = "PersonalBibliotecario,Administrador")]
        public async Task<IActionResult> RegistrarPagoPenalizacion(int idPenalizacion, [FromBody] PenalizacionRequestDTO peticion)
        {
            var claimId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? User.FindFirst("id")?.Value;
            int idUsuarioResolutor = int.Parse(claimId!);

            await _servicioPrenalizacion.ProcesarPagoMultaAsync(idPenalizacion, peticion, idUsuarioResolutor);

            return Ok(new { mensaje = "Pago de penalización registrado exitosamente." });
        }

        [HttpGet("Pendientes/Usuario/{matriculaONumeroEmpleado}")]
        [Authorize(Roles = "PersonalBibliotecario,Administrador,Estudiante,Docente")]
        public async Task<IActionResult> ObtenerPendientesPorUsuario(string matriculaONumeroEmpleado)
        {
            var resultado = await _servicioPrenalizacion.ObtenerPendientesPorUsuariosAsync(matriculaONumeroEmpleado);
            return Ok(resultado);
        }

        [HttpGet("Pendientes/Todas")]
        [Authorize(Roles = "PersonalBibliotecario,Administrador")] // Solo staff
        public async Task<IActionResult> ObtenerTodasPendientes()
        {
            var resultado = await _servicioPrenalizacion.ObtenerTodasPendientesAsync();
            return Ok(resultado);
        }

        [HttpGet("Historial/Usuario/{matriculaONumeroEmpleado}")]
        [Authorize(Roles = "PersonalBibliotecario,Administrador,Auditor")]
        public async Task<IActionResult> ObtenerHistorialPorUsuario(string matriculaONumeroEmpleado)
        {
            var resultado = await _servicioPrenalizacion.ObtenerHistorialPorUsuariosAsync(matriculaONumeroEmpleado);
            return Ok(resultado);
        }

        [HttpGet("Historial/Todas")]
        [Authorize(Roles = "PersonalBibliotecario,Administrador,Auditor")]
        public async Task<IActionResult> ObtenerHistorialCompleto()
        {
            var resultado = await _servicioPrenalizacion.ObtenerHistorialCompletoAsync();
            return Ok(resultado);
        }
    }
}