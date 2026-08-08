using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIGEBI.Application.DTOs;
using SIGEBI.Application.Interfaces;
using System.Threading.Tasks;

namespace SIGEBI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PenalizacionesController : BaseController
    {
        private readonly IServicioPenalizacion _servicioPrenalizacion;

        // 🔥 CORREGIDO: Se retiró IUsuarios porque el controlador ya no lo necesita
        public PenalizacionesController(IServicioPenalizacion servicioPrenalizacion)
        {
            _servicioPrenalizacion = servicioPrenalizacion;
        }

        [HttpPatch("RegistrarPago/{idPenalizacion}")]
        [Authorize(Roles = "PersonalBibliotecario,Administrador")]
        public async Task<IActionResult> RegistrarPagoPenalizacion(int idPenalizacion, [FromBody] PenalizacionRequestDTO peticion)
        {
            int idUsuarioResolutor = ObtenerIdResponsable();
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
        [Authorize(Roles = "PersonalBibliotecario,Administrador")]
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

       
        [HttpGet("mis-pendientes")]
        [Authorize(Roles = "Estudiante,Docente")]
        public async Task<IActionResult> ConsultarMisPenalizacionesPendientes()
        {
            int idUsuario = ObtenerIdResponsable();
            var resultado = await _servicioPrenalizacion.ObtenerPendientesPorIdUsuarioAsync(idUsuario);
            return Ok(resultado);
        }
    }
}