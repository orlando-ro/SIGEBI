using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIGEBI.Application.DependencyInyeccion;
using SIGEBI.Application.DTOs;
using SIGEBI.Application.Interfaces;
using SIGEBI.Application.Services;
using SIGEBI.Domain.Entities;
using SIGEBI.Infrastructure.DependencyInjection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace SIGEBI.Api.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly IServicioCategoria _GestorCategoria;

        public CategoriaController(IServicioCategoria GestorCategoria)
        {
            _GestorCategoria = GestorCategoria;
        }

        //GET: api/categoria
        [HttpGet]
        public async Task<IActionResult> ConsultarTodas()
        {
            var categorias = await _GestorCategoria.ConsultarTodasAsync();
            return Ok(categorias);
        }

        //GET: api/categoria/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var categoria = await _GestorCategoria.ObtenerPorIdAsync(id);

            if (categoria == null)
                return NotFound("La categoría no fue encontrada.");

            return Ok(categoria);
        }

        //POST: api/categoria/registrar
        [HttpPost("registrar")]
        public async Task<IActionResult> RegistrarCategoria([FromBody] CategoriaRequestDTO request)
        {
            await _GestorCategoria.RegistrarCategoriaAsync(request);
            return Ok(); // 201
        }
    }
}