using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIGEBI.Application.DTOs;
using SIGEBI.Application.Interfaces;
using System.IO;
using System.Threading.Tasks;

namespace SIGEBI.Api.Controllers
{
    // Clase exclusiva de la API para recibir el multipart/form-data
    public class RegistrarLibroApiRequest
    {
        public string ISBN { get; set; } = string.Empty;
        public string Titulo { get; set; } = string.Empty;
        public string NombreAutor { get; set; } = string.Empty;
        public int AnioPublicacion { get; set; }
        public int CopiasTotales { get; set; }
        public int IdCategoria { get; set; }
        public IFormFile? Imagen { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CatalogoController : BaseController
    {
        private readonly IServicioCatalogo _gestorCatalogo;

        public CatalogoController(IServicioCatalogo gestorCatalogo)
        {
            _gestorCatalogo = gestorCatalogo;
        }

        
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConsultarTodos()
        {
            var libros = await _gestorCatalogo.ConsultarTodoAsync();
            return Ok(libros);
        }

       
        [HttpGet("{isbn}")]
        [AllowAnonymous]
        public async Task<IActionResult> BuscarPorIsbn(string isbn)
        {
            var libro = await _gestorCatalogo.BuscarPorIsbnAsync(isbn);

            if (libro == null)
                return NotFound($"No se encontró ningún libro con el ISBN: {isbn}");

            return Ok(libro);
        }

        
        [HttpGet("buscar")]
        [AllowAnonymous]
        public async Task<IActionResult> ConsultarCatalogo([FromQuery] FiltroCatalogoDTO filtros)
        {
            var resultados = await _gestorCatalogo.ConsultarCatalogoAsync(filtros);
            return Ok(resultados);
        }

       
        [HttpPost("registrar")]
        [Authorize(Roles = "Administrador,PersonalBibliotecario")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> RegistrarLibro([FromForm] RegistrarLibroApiRequest request)
        {
            int idResponsable = ObtenerIdResponsable();

            // Transformación del IFormFile a byte[]
            byte[]? bytesImagen = null;
            string? extensionArchivo = null;

            if (request.Imagen != null && request.Imagen.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await request.Imagen.CopyToAsync(memoryStream);
                    bytesImagen = memoryStream.ToArray();
                    extensionArchivo = Path.GetExtension(request.Imagen.FileName);
                }
            }

            // Mapeo al DTO (Agnóstico a la web)
            var dto = new LibroRequestDTO
            {
                ISBN = request.ISBN,
                Titulo = request.Titulo,
                NombreAutor = request.NombreAutor,
                AnioPublicacion = request.AnioPublicacion,
                CopiasTotales = request.CopiasTotales,
                IdCategoria = request.IdCategoria,
                ContenidoImagen = bytesImagen,
                ExtensionImagen = extensionArchivo
            };

            await _gestorCatalogo.RegistrarLibroAsync(dto, idResponsable);
            return Ok(new { Mensaje = "Libro y ejemplares registrados exitosamente." });
        }

      
        [HttpPut("{isbn}")]
        [Authorize(Roles = "Administrador,PersonalBibliotecario")]
        public async Task<IActionResult> ActualizarLibro(string isbn, [FromBody] LibroUpdateDTO request)
        {
            int idResponsable = ObtenerIdResponsable();

            await _gestorCatalogo.ActualizarLibroAsync(isbn, request, idResponsable);
            return Ok(new { mensaje = "Libro actualizado" });
        }

        
        [HttpPut("{isbn}/desactivar")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> DesactivarLibro(string isbn)
        {
            int idResponsable = ObtenerIdResponsable();

            await _gestorCatalogo.EliminarLibroAsync(isbn, idResponsable);
            return Ok(new { mensaje = "Libro Desactivado" });
        }

        [HttpPost("{isbn}/ejemplares")]
        [Authorize(Roles = "Administrador,PersonalBibliotecario")]
        public async Task<IActionResult> AgregarEjemplares(string isbn, [FromBody] AgregarEjemplaresRequestDTO request)
        {
            if (request.Cantidad <= 0)
                return BadRequest(new { mensaje = "La cantidad de ejemplares a agregar debe ser mayor a cero." });

            int idResponsable = ObtenerIdResponsable();

            await _gestorCatalogo.AgregarEjemplaresAsync(isbn, request.Cantidad, idResponsable);

            return Ok(new { mensaje = $"Se han agregado {request.Cantidad} ejemplares exitosamente al catálogo." });
        }
    }
}