using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        [HttpGet]
        public async Task<IActionResult> Index(FiltroCatalogoDTO filtros)
        {
            IEnumerable<LibroResponseDTO> libros;

            bool hayFiltros = !string.IsNullOrEmpty(filtros.Titulo) ||
                              !string.IsNullOrEmpty(filtros.NombreAutor) ||
                              filtros.IdCategoria.HasValue ||
                              filtros.SoloDisponibles;

            if (hayFiltros)
            {
                libros = await _servicioCatalogo.ConsultarCatalogoAsync(filtros);
            }
            else 
            {
                libros = await _servicioCatalogo.ConsultarTodosAsync();
            }

            var categorias = await _servicioCatalogo.ObtenerCategoriasAsync();

            ViewBag.Categorias = new SelectList(categorias, "IdCategoria", "Nombre", filtros.IdCategoria);

            ViewBag.FiltroTitulo = filtros.Titulo;
            ViewBag.FiltroAutor = filtros.NombreAutor;
            ViewBag.FiltroDisponibles = filtros.SoloDisponibles;

            return View(libros);
        }

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