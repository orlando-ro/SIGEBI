using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIGEBI.Application.DTOs;
using SIGEBI.Application.Interfaces;
using SIGEBI.Infrastructure.DependencyInjection;
using SIGEBI.Application.DependencyInyeccion;

namespace SIGEBI.Api.Controllers
{
    // Heredamos de BaseController para acceder a ObtenerIdResponsable()
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // Asegura que todo el controlador requiera estar autenticado por defecto
    public class UsuarioController : BaseController
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
        [Authorize(Roles = "Administrador,PersonalBibliotecario")] // Restringido
        public async Task<IActionResult> RegistrarUsuario([FromBody] UsuarioRequestDTO request)
        {
            int idResponsable = ObtenerIdResponsable();
            await _GestorUsuarios.RegistrarUsuarioAsync(request, idResponsable);
            return Ok(new { Mensaje = "Usuario Creado exitosamente" }); // 201 Created
        }

        // PUT: api/usuarios/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Administrador,PersonalBibliotecario")]
        public async Task<IActionResult> ActualizarUsuario(int id, [FromBody] UsuarioUpdateRequestDTO request)
        {
            int idResponsable = ObtenerIdResponsable();
            await _GestorUsuarios.ActualizarUsuarioAsync(id, request, idResponsable);
            return NoContent(); // 204 No Content
        }

        // PUT: api/usuarios/identificador/EMP-001
        [HttpPut("identificador/{identificador}")]
        [Authorize(Roles = "Administrador,PersonalBibliotecario")]
        public async Task<IActionResult> ActualizarPorIdentificador(string identificador, [FromBody] UsuarioUpdateRequestDTO request)
        {
            int idResponsable = ObtenerIdResponsable();
            await _GestorUsuarios.ActualizarPorIdentificadorAsync(identificador, request, idResponsable);
            return NoContent();
        }

        // PUT: api/usuarios/5/suspender
        [HttpPut("{id}/suspender")]
        [Authorize(Roles = "Administrador,PersonalBibliotecario")] 
        public async Task<IActionResult> SuspenderUsuario(int id)
        {
            int idResponsable = ObtenerIdResponsable();
            await _GestorUsuarios.SuspenderUsuarioAsync(id, idResponsable);
            return NoContent();
        }

        // PUT: api/usuarios/identificador/EMP-001/suspender
        [HttpPut("identificador/{identificador}/suspender")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> SuspenderPorIdentificador(string identificador)
        {
            int idResponsable = ObtenerIdResponsable();
            await _GestorUsuarios.SuspenderUsuarioPorIdentificadorAsync(identificador, idResponsable);
            return NoContent();
        }

            
    }
}