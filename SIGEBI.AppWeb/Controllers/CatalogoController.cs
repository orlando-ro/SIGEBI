using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SIGEBI.Application.DTOs;
using SIGEBI.Application.Interfaces;
using SIGEBI.AppWeb.Models.Catalogo;
using SIGEBI.Domain.Exceptions;
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
        [AllowAnonymous] // permite que cualquier usuario, autenticado, pueda ver los detalles del libro
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

        [HttpGet]
        [Authorize(Roles = "Administrador,PersonalBibliotecario")]
        public async Task<IActionResult> Registrar()
        {
            await CargarCategoriasViewBag();
            return View(new RegistrarLibroViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador,PersonalBibliotecario")]
        public async Task<IActionResult> Registrar(RegistrarLibroViewModel modelo)
        {
            if (!ModelState.IsValid)
            {
                await CargarCategoriasViewBag();
                return View(modelo);
            }

            try
            {
                var claimId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? User.FindFirst("id")?.Value;
                if (!int.TryParse(claimId, out int idResponsable))
                {
                    TempData["ErrorMessage"] = "Error de autenticación.";
                    return RedirectToAction(nameof(Index));
                }

                byte[]? bytesImagen = null;
                string? extensionArchivo = null;

                if (modelo.Imagen != null && modelo.Imagen.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await modelo.Imagen.CopyToAsync(memoryStream);
                        bytesImagen = memoryStream.ToArray();
                        extensionArchivo = Path.GetExtension(modelo.Imagen.FileName);
                    }
                }

                var dto = new LibroRequestDTO
                {
                    ISBN = modelo.ISBN,
                    Titulo = modelo.Titulo,
                    NombreAutor = modelo.NombreAutor,
                    AnioPublicacion = modelo.AnioPublicacion,
                    CopiasTotales = modelo.CopiasTotales,
                    IdCategoria = modelo.IdCategoria,
                    ContenidoImagen = bytesImagen,
                    ExtensionImagen = extensionArchivo
                };

                await _servicioCatalogo.RegistrarLibroAsync(dto, idResponsable);
                TempData["SuccessMessage"] = $"El libro '{modelo.Titulo}' se ha registrado exitosamente con sus ejemplares.";
                return RedirectToAction(nameof(Index));
            }
            catch (NegocioExeption ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                await CargarCategoriasViewBag();
                return View(modelo);
            }
        }

        [HttpGet]
        [Authorize(Roles = "Administrador,PersonalBibliotecario")]
        public async Task<IActionResult> Actualizar(string isbn)
        {
            if (string.IsNullOrWhiteSpace(isbn)) return RedirectToAction(nameof(Index));

            var libroDto = await _servicioCatalogo.BuscarPorIsbnAsync(isbn);
            if (libroDto == null)
            {
                TempData["ErrorMessage"] = "El recurso bibliográfico no existe.";
                return RedirectToAction(nameof(Index));
            }

            var categorias = await _servicioCategoria.ConsultarTodasAsync();
            var categoriaSeleccionada = categorias.FirstOrDefault(c => c.Nombre == libroDto.Categoria);

            var modelo = new ActualizarLibroViewModel
            {
                ISBN = libroDto.ISBN,
                Titulo = libroDto.Titulo,
                NombreAutor = libroDto.NombreAutor,
                AnioPublicacion = libroDto.AnioPublicacion,
                IdCategoria = categoriaSeleccionada?.IdCategoria ?? 0
            };

            await CargarCategoriasViewBag(modelo.IdCategoria);
            return View(modelo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador,PersonalBibliotecario")]
        public async Task<IActionResult> Actualizar(string isbn, ActualizarLibroViewModel modelo)
        {
            if (!ModelState.IsValid)
            {
                await CargarCategoriasViewBag(modelo.IdCategoria);
                modelo.ISBN = isbn;
                return View(modelo);
            }

            try
            {
                var claimId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? User.FindFirst("id")?.Value;
                if (!int.TryParse(claimId, out int idResponsable))
                {
                    TempData["ErrorMessage"] = "Error de autenticación.";
                    return RedirectToAction(nameof(Index));
                }

                var dto = new LibroUpdateDTO
                {
                    Titulo = modelo.Titulo,
                    NombreAutor = modelo.NombreAutor,
                    AnioPublicacion = modelo.AnioPublicacion,
                    IdCategoria = modelo.IdCategoria
                };

                await _servicioCatalogo.ActualizarLibroAsync(isbn, dto, idResponsable);
                TempData["SuccessMessage"] = "El recurso ha sido actualizado exitosamente.";
                return RedirectToAction(nameof(Index));
            }
            catch (NegocioExeption ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                await CargarCategoriasViewBag(modelo.IdCategoria);
                modelo.ISBN = isbn;
                return View(modelo);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Eliminar(string isbn)
        {
            try
            {
                var claimId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? User.FindFirst("id")?.Value;
                if (!int.TryParse(claimId, out int idResponsable))
                {
                    TempData["ErrorMessage"] = "Error de autenticación.";
                    return RedirectToAction(nameof(Index));
                }

                await _servicioCatalogo.EliminarLibroAsync(isbn, idResponsable);
                TempData["SuccessMessage"] = "El recurso ha sido dado de baja exitosamente.";
            }
            catch (NegocioExeption ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }
            return RedirectToAction(nameof(Index));
        }

        private async Task CargarCategoriasViewBag(int? idSeleccionado = null)
        {
            var categorias = await _servicioCategoria.ConsultarTodasAsync();
            ViewBag.Categorias = new SelectList(categorias, "IdCategoria", "Nombre", idSeleccionado);
        }
    }
}