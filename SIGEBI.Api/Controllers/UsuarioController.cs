using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc;
using SIGEBI.Application.DTOs;
using SIGEBI.Application.Interfaces;
using SIGEBI.Infrastructure.DependencyInjection;
using SIGEBI.Application.DependencyInyeccion;

namespace SIGEBI.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IServicioUsuarios _GestorUsuarios;

        public UsuarioController(IServicioUsuarios GestorUsuarios)
        {
            _GestorUsuarios = GestorUsuarios;
        }

        // GET: api/usuarios/5
        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var usuario = await _GestorUsuarios.ObtenerUsuarioPorIdAsync(id);

            if (usuario == null)
                return NotFound("El usuario no fue encontrado.");

            return Ok(usuario);
        }

        // GET: api/usuarios/identificador/EMP-001
        [HttpGet("identificador/{identificador}")]
        public async Task<IActionResult> ObtenerPorIdentificador(string identificador)
        {
            var usuario = await _GestorUsuarios.ObtenerPorMatriculaONumeroEmpleadoAsync(identificador);

            if (usuario == null)
                return NotFound("No se encontró ningún usuario con ese identificador.");

            return Ok(usuario);
        }

        // POST: api/usuarios/registrar
        [HttpPost("registrar")]
        public async Task<IActionResult> RegistrarUsuario([FromBody] UsuarioRequestDTO request)
        {
            await _GestorUsuarios.RegistrarUsuarioAsync(request);
            return Ok(new {Mensaje = "Usuario Creado exitosamente"}); // 201 Created
        }

        // PUT: api/usuarios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarUsuario(int id, [FromBody] UsuarioUpdateRequestDTO request)
        {
            await _GestorUsuarios.ActualizarUsuarioAsync(id, request);
            return NoContent(); // 204 No Content
        }

        // PUT: api/usuarios/identificador/EMP-001
        [HttpPut("identificador/{identificador}")]
        public async Task<IActionResult> ActualizarPorIdentificador(string identificador, [FromBody] UsuarioUpdateRequestDTO request)
        {
            await _GestorUsuarios.ActualizarPorIdentificadorAsync(identificador, request);
            return NoContent();
        }

        // PUT: api/usuarios/5/suspender
        [HttpPut("{id}/suspender")]
        public async Task<IActionResult> SuspenderUsuario(int id)
        {
            await _GestorUsuarios.SuspenderUsuarioAsync(id);
            return NoContent();
        }

        // PUT: api/usuarios/identificador/EMP-001/suspender
        [HttpPut("identificador/{identificador}/suspender")]
        public async Task<IActionResult> SuspenderPorIdentificador(string identificador)
        {
            await _GestorUsuarios.SuspenderUsuarioPorIdentificadorAsync(identificador);
            return NoContent();
        }
    }
}



