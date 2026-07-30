using Microsoft.AspNetCore.Mvc;
using SIGEBI.AppWeb.Models.DTOs.Catalogo;
using SIGEBI.AppWeb.Services;

namespace SIGEBI.AppWeb.Controllers
{
    public class CatalogoController : Controller
    {
        private readonly IServicioCatalogoApi _servicioCatalogo;

        public CatalogoController(IServicioCatalogoApi servicioCatalogo)
        {
            _servicioCatalogo = servicioCatalogo;
        }

        // Vista principal: Muestra todos los libros o filtra según la búsqueda
        [HttpGet]
        public async Task<IActionResult> Index(FiltroCatalogoDTO filtros)
        {
            IEnumerable<LibroResponseDTO> libros;

            // Si hay filtros aplicados, usamos el endpoint de búsqueda
            if (!string.IsNullOrEmpty(filtros.TerminoBusqueda) || filtros.IdCategoria.HasValue)
            {
                libros = await _servicioCatalogo.ConsultarCatalogoAsync(filtros);
            }
            else // Si no hay filtros, traemos todos
            {
                libros = await _servicioCatalogo.ConsultarTodosAsync();
            }

            // Aquí puedes retornar la lista directa o un ViewModel si tu vista lo requiere
            return View(libros);
        }

        // Vista de detalles: Muestra la información de un libro específico
        [HttpGet]
        public async Task<IActionResult> Detalles(string id) // id corresponde al ISBN
        {
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction("Index");
            }

            var libro = await _servicioCatalogo.BuscarPorIsbnAsync(id);

            if (libro == null)
            {
                return NotFound("El libro solicitado no existe en el catálogo.");
            }

            return View(libro);
        }
    }
}