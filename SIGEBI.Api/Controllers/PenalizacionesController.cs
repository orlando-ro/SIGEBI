using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIGEBI.Application.Interfaces;
using SIGEBI.Application.DTOs;
using SIGEBI.Domain.Enums;

namespace SIGEBI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PenalizacionesController : ControllerBase
    {
        private readonly IServicioPenalizacion _servicioPrenalizacion;

        public PenalizacionesController(IServicioPenalizacion servicioPrenalizacion)
        {
            _servicioPrenalizacion = servicioPrenalizacion;
        }


        [HttpPatch("RegistrarPago/{idPenalizacion}/Usuario/{idUsuarioResolutor}")]
        public async Task<IActionResult> RegistrarPagoPenalizacion(int idPenalizacion, [FromBody] PenalizacionRequestDTO peticion, int idUsuarioResolutor) {
        
            await _servicioPrenalizacion.ProcesarPagoMultaAsync(idPenalizacion, peticion, idUsuarioResolutor);
            return Ok(new { mensaje = "Pago de penalización registrado exitosamente." });
        }

        [HttpGet("Pendientes/Usuario/{matriculaONumeroEmpleado}")]
        public async Task<IActionResult> ObtenerPendientesPorUsuario(string matriculaONumeroEmpleado) {
        
            var resultado = await _servicioPrenalizacion.ObtenerPendientesPorUsuariosAsync(matriculaONumeroEmpleado);

            return Ok(resultado);
        }

    }
}
