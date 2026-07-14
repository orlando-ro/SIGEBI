using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIGEBI.Application.DTOs;
using SIGEBI.Application.Interfaces;
using System.Threading.Tasks;

namespace SIGEBI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Protegemos el controlador completo
    public class CategoriaController : BaseController // Usamos el controlador base
    {
        private readonly IServicioCategoria _GestorCategoria;

        public CategoriaController(IServicioCategoria GestorCategoria)
        {
            _GestorCategoria = GestorCategoria;
        }

        //GET: api/categoria
        [HttpGet]
        [AllowAnonymous] // Permitimos a cualquier usuario listar las categorías
        public async Task<IActionResult> ConsultarTodas()
        {
            var categorias = await _GestorCategoria.ConsultarTodasAsync();
            return Ok(categorias);
        }

        //GET: api/categoria/{id}
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var categoria = await _GestorCategoria.ObtenerPorIdAsync(id);

            if (categoria == null)
                return NotFound("La categoría no fue encontrada.");

            return Ok(categoria);
        }

        //POST: api/categoria/registrar
        [HttpPost("registrar")]
        [Authorize(Roles = "Administrador,PersonalBibliotecario")]
        public async Task<IActionResult> RegistrarCategoria([FromBody] CategoriaRequestDTO request)
        {
            int idResponsable = ObtenerIdResponsable();
            await _GestorCategoria.RegistrarCategoriaAsync(request, idResponsable);
            return Ok(new { Mensaje = "Categoría creada exitosamente" });
        }

        //PUT: api/categoria/{id}
        [HttpPut("{id}")]
        [Authorize(Roles = "Administrador,PersonalBibliotecario")]
        public async Task<IActionResult> ActualizarCategoria(int id, [FromBody] CategoriaRequestDTO request)
        {
            int idResponsable = ObtenerIdResponsable();
            await _GestorCategoria.ActualizarCategoriaAsync(id, request, idResponsable);
            return Ok(new { mensaje = "Categoría actualizada exitosamente." });
        }
    }
}