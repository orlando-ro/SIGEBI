using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using SIGEBI.Application.Interfaces;

namespace SIGEBI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificacionesController : ControllerBase
    {
        private readonly IServicioNotificacion _servicioNotificacion;

        public NotificacionesController(IServicioNotificacion servicioNotificacion)
        {
            _servicioNotificacion = servicioNotificacion;
        }

        // Para la campanita de notificaciones en el frontend del usuario
        [HttpGet("pendientes")]
        [Authorize]
        public async Task<IActionResult> ObtenerPendientes()
        {
            int idUsuario = ObtenerIdUsuario();
            var notificaciones = await _servicioNotificacion.ObtenerPendientesAsync(idUsuario);
            return Ok(notificaciones);
        }

        [HttpPut("{id}/leer")]
        [Authorize]
        public async Task<IActionResult> MarcarComoLeida(int id)
        {
            await _servicioNotificacion.MarcarComoLeidaAsync(id);
            return Ok(new { Mensaje = "Notificación marcada como leída." });
        }

        // CU-NOT-05: Consultar Registro de Notificaciones
        [HttpGet("historial")]
        [Authorize(Roles = "Administrador,Auditor")] // Restringido según tu tabla
        public async Task<IActionResult> ConsultarHistorialGlobal()
        {
            var historial = await _servicioNotificacion.ConsultarHistorialGlobalAsync();
            return Ok(historial);
        }

        // CU-NOT-01: Endpoint "gatillo" para el automatismo
        // Nota: Esto se deja para que un programador de tareas (Cron Job) haga la peticion HTTP cada noche a las 00:00
        [HttpPost("trigger-vencimientos")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> TriggerVencimientos([FromQuery] int diasAntelacion = 3)
        {
            await _servicioNotificacion.GenerarNotificacionesDeVencimientoAsync(diasAntelacion);
            return Ok(new { Mensaje = $"Recordatorios automáticos generados para préstamos a {diasAntelacion} días de vencer." });
        }

        #region Helpers
        private int ObtenerIdUsuario()
        {
            var claim = User.FindFirst(ClaimTypes.NameIdentifier) ?? User.FindFirst("id");
            if (claim != null && int.TryParse(claim.Value, out int id)) return id;
            throw new UnauthorizedAccessException("Usuario no autenticado o token inválido.");
        }
        #endregion
    }
}