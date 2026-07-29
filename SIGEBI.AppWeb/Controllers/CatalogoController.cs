using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SIGEBI.AppWeb.Models.Catalogo;
using System.Security.Claims;

namespace SIGEBI.AppWeb.Controllers
{
    [Authorize]
    public class CatalogoController : Controller
    {
        private readonly IServicioCatalogo _servicioCatalogo;
        private readonly IServicioCategoria _servicioCategoria;
        private readonly ILogger<CatalogoController> _logger;

        public CatalogoController(IServicioCatalogo servicioCatalogo, IServicioCategoria servicioCategoria, ILogger<CatalogoController> logger)
        {
            _servicioCatalogo = servicioCatalogo;
            _servicioCategoria = servicioCategoria;
            _logger = logger;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index(string? titulo, string? autor, int? idCategoria, bool soloDisponibles = false)
        {
            await CargarCategoriasViewBag(idCategoria);

            var filtros = new FiltroCatalogoDTO
            {
                Titulo = titulo,
                NombreAutor = autor,
                IdCategoria = idCategoria,
                SoloDisponibles = false // Manejo seguro en memoria para evitar fallos de SQL
            };

            var dtos = await _servicioCatalogo.ConsultarCatalogoAsync(filtros);

            var modelo = dtos.Select(d => new CatalogoItemViewModel
            {
                ISBN = d.ISBN,
                Titulo = d.Titulo,
                NombreAutor = d.NombreAutor,
                AnioPublicacion = d.AnioPublicacion,
                NombreCategoria = d.NombreCategoria,
                UrlImagen = d.UrlImagen,
                CopiasDisponibles = d.CopiasDisponibles
            }).ToList();

            // Filtro seguro en memoria RAM del servidor web si el usuario marca la casilla
            if (soloDisponibles)
            {
                modelo = modelo.Where(m => m.CopiasDisponibles > 0).ToList();
            }

            return View(modelo);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Detalles(string isbn)
        {
            if (string.IsNullOrWhiteSpace(isbn))
            {
                TempData["ErrorMessage"] = "Debe proporcionar un ISBN válido.";
                return RedirectToAction(nameof(Index));
            }

            var libroDto = await _servicioCatalogo.BuscarPorIsbnAsync(isbn);

            if (libroDto == null)
            {
                TempData["ErrorMessage"] = "El recurso bibliográfico que intenta ver no existe.";
                return RedirectToAction(nameof(Index));
            }

            // Reutilizamos el ViewModel del catálogo para mostrar los detalles
            var modelo = new CatalogoItemViewModel
            {
                ISBN = libroDto.ISBN,
                Titulo = libroDto.Titulo,
                NombreAutor = libroDto.NombreAutor,
                AnioPublicacion = libroDto.AnioPublicacion,
                NombreCategoria = libroDto.Categoria,
                UrlImagen = libroDto.UrlImagen,
                CopiasDisponibles = libroDto.CopiasDisponibles
            };

            return View(modelo);
        }

        #region Helpers
        private async Task CargarCategoriasViewBag(int? idSeleccionado = null)
        {
            var categorias = await _servicioCategoria.ConsultarTodasAsync();
            ViewBag.Categorias = new SelectList(categorias, "IdCategoria", "Nombre", idSeleccionado);
        }
        #endregion
    }
}