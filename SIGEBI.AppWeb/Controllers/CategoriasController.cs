using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIGEBI.Application.DTOs;
using SIGEBI.Application.Interfaces;
using SIGEBI.AppWeb.Models.Categorias;
using SIGEBI.Domain.Exceptions;
using System.Security.Claims;

namespace SIGEBI.AppWeb.Controllers
{
    [Authorize]
    public class CategoriasController : Controller
    {
        private readonly IServicioCategoria _servicioCategoria;
        private readonly ILogger<CategoriasController> _logger;

        public CategoriasController(IServicioCategoria servicioCategoria, ILogger<CategoriasController> logger)
        {
            _servicioCategoria = servicioCategoria;
            _logger = logger;
        }

        [HttpGet]
        [Authorize(Roles = "PersonalBibliotecario,Administrador,Auditor")]
        public async Task<IActionResult> Index()
        {
            var dtos = await _servicioCategoria.ConsultarTodasAsync();
            var modelo = dtos.Select(d => new CategoriaItemViewModel
            {
                IdCategoria = d.IdCategoria,
                Nombre = d.Nombre,
                Descripcion = d.Descripcion
            }).ToList();

            return View(modelo);
        }

        [HttpGet]
        [Authorize(Roles = "Administrador,PersonalBibliotecario")]
        public IActionResult Registrar()
        {
            return View(new CategoriaFormViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador,PersonalBibliotecario")]
        public async Task<IActionResult> Registrar(CategoriaFormViewModel modelo)
        {
            if (!ModelState.IsValid) return View(modelo);

            try
            {
                var claimId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? User.FindFirst("id")?.Value;
                if (!int.TryParse(claimId, out int idResponsable))
                {
                    TempData["ErrorMessage"] = "Error de autenticación al validar su usuario.";
                    return RedirectToAction(nameof(Index));
                }

                var dto = new CategoriaRequestDTO
                {
                    Nombre = modelo.Nombre,
                    Descripcion = modelo.Descripcion
                };

                await _servicioCategoria.RegistrarCategoriaAsync(dto, idResponsable);
                TempData["SuccessMessage"] = "Categoría registrada exitosamente.";
                return RedirectToAction(nameof(Index));
            }
            catch (NegocioExeption ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(modelo);
            }
        }

        [HttpGet]
        [Authorize(Roles = "Administrador,PersonalBibliotecario")]
        public async Task<IActionResult> Actualizar(int id)
        {
            var categoriaDto = await _servicioCategoria.ObtenerPorIdAsync(id);
            if (categoriaDto == null)
            {
                TempData["ErrorMessage"] = "La categoría que intenta editar no existe.";
                return RedirectToAction(nameof(Index));
            }

            var modelo = new CategoriaFormViewModel
            {
                IdCategoria = categoriaDto.IdCategoria,
                Nombre = categoriaDto.Nombre,
                Descripcion = categoriaDto.Descripcion
            };

            return View(modelo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador,PersonalBibliotecario")]
        public async Task<IActionResult> Actualizar(int id, CategoriaFormViewModel modelo)
        {
            if (!ModelState.IsValid) return View(modelo);

            try
            {
                var claimId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? User.FindFirst("id")?.Value;
                if (!int.TryParse(claimId, out int idResponsable))
                {
                    TempData["ErrorMessage"] = "Error de autenticación al validar su usuario.";
                    return RedirectToAction(nameof(Index));
                }

                var dto = new CategoriaRequestDTO
                {
                    Nombre = modelo.Nombre,
                    Descripcion = modelo.Descripcion
                };

                await _servicioCategoria.ActualizarCategoriaAsync(id, dto, idResponsable);
                TempData["SuccessMessage"] = "Categoría actualizada exitosamente.";
                return RedirectToAction(nameof(Index));
            }
            catch (NegocioExeption ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(modelo);
            }
        }
    }
}