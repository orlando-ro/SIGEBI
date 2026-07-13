using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIGEBI.Application.DTOs;
using SIGEBI.Application.Interfaces;
using System.Threading.Tasks;

namespace SIGEBI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Protegemos el controlador completo por defecto
    public class CatalogoController : BaseController
    {
        private readonly IServicioCatalogo _gestorCatalogo;

        public CatalogoController(IServicioCatalogo gestorCatalogo)
        {
            _gestorCatalogo = gestorCatalogo;
        }

        // GET: api/catalogo
        [HttpGet]
        [AllowAnonymous] 
        public async Task<IActionResult> ConsultarTodos()
        {
            var libros = await _gestorCatalogo.ConsultarTodoAsync();
            return Ok(libros);
        }

        // GET: api/catalogo/{isbn}
        [HttpGet("{isbn}")]
        [AllowAnonymous]
        public async Task<IActionResult> BuscarPorIsbn(string isbn)
        {
            var libro = await _gestorCatalogo.BuscarPorIsbnAsync(isbn);

            if (libro == null)
                return NotFound($"No se encontró ningún libro con el ISBN: {isbn}");

            return Ok(libro);
        }

        // GET: api/catalogo/buscar
        [HttpGet("buscar")]
        [AllowAnonymous]
        public async Task<IActionResult> ConsultarCatalogo([FromQuery] FiltroCatalogoDTO filtros)
        {
            var resultados = await _gestorCatalogo.ConsultarCatalogoAsync(filtros);
            return Ok(resultados);
        }

        // POST: api/catalogo/registrar
        [HttpPost("registrar")]
        [Authorize(Roles = "Administrador,PersonalBibliotecario")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> RegistrarLibro([FromForm] LibroRequestDTO request)
        {
            int idResponsable = ObtenerIdResponsable();

            await _gestorCatalogo.RegistrarLibroAsync(request, idResponsable);
            return Ok(new { Mensaje = "Libro y ejemplares registrados exitosamente." });
        }

        // PUT: api/catalogo/{isbn}
        [HttpPut("{isbn}")]
        [Authorize(Roles = "Administrador,PersonalBibliotecario")]
        public async Task<IActionResult> ActualizarLibro(string isbn, [FromBody] LibroUpdateDTO request)
        {
            int idResponsable = ObtenerIdResponsable();

            await _gestorCatalogo.ActualizarLibroAsync(isbn, request, idResponsable);
            return NoContent(); // 204 No Content
        }

        // PUT: api/catalogo/{isbn}/desactivar
        [HttpPut("{isbn}/desactivar")]
        [Authorize(Roles = "Administrador")] 
        public async Task<IActionResult> DesactivarLibro(string isbn)
        {
            int idResponsable = ObtenerIdResponsable();

            await _gestorCatalogo.EliminarLibroAsync(isbn, idResponsable);

            return NoContent(); // 204 No Content
        }
    }
}