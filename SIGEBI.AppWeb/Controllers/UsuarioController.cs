using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIGEBI.Application.Interfaces;
using SIGEBI.AppWeb.Models.Usuarios;
using System.Security.Claims;

namespace SIGEBI.AppWeb.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class UsuariosController : Controller
    {
        private readonly IServicioUsuarios _servicioUsuarios;
        private readonly ILogger<UsuariosController> _logger;

        public UsuariosController(IServicioUsuarios servicioUsuarios, ILogger<UsuariosController> logger)
        {
            _servicioUsuarios = servicioUsuarios;
            _logger = logger;
        }

        // GET: /Usuarios
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var usuariosDto = await _servicioUsuarios.ConsultarTodosAsync();

                var modelo = usuariosDto.Select(u => new UsuarioItemViewModel
                {
                    IdUsuario = u.IdUsuario,
                    Nombre = u.Nombre,
                    Email = u.Email,
                    Estado = u.Estado,
                    TipoUsuario = u.TipoUsuario,
                    Matricula = u.Matricula,
                    NumeroEmpleado = u.NumeroEmpleado,
                    HabilitadoParaPrestamos = u.HabilitadoParaPrestamos
                }).ToList();

                return View(modelo);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al cargar la lista de usuarios.");
                TempData["ErrorMessage"] = "Ocurrió un error al intentar cargar los usuarios.";
                return View(new List<UsuarioItemViewModel>());
            }
        }

        // GET: /Usuarios/Crear
        [HttpGet]
        public IActionResult Crear()
        {
            return View(new SIGEBI.Application.DTOs.UsuarioRequestDTO());
        }

        // POST: /Usuarios/Crear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(SIGEBI.Application.DTOs.UsuarioRequestDTO modelo)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Por favor, complete todos los campos obligatorios correctamente.";
                return View(modelo);
            }

            try
            {
                int idResponsable = ObtenerIdResponsable();

                await _servicioUsuarios.RegistrarUsuarioAsync(modelo, idResponsable);

                TempData["SuccessMessage"] = $"El usuario {modelo.Nombre} fue registrado exitosamente.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View(modelo);
            }
        }

        // GET: /Usuarios/Editar/5
        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            try
            {
                // Buscamos al usuario existente
                var usuario = await _servicioUsuarios.ObtenerUsuarioPorIdAsync(id);
                if (usuario == null)
                {
                    TempData["ErrorMessage"] = "El usuario que intenta editar no existe.";
                    return RedirectToAction(nameof(Index));
                }

                // Llenamos el DTO de actualización con los datos actuales
                var modelo = new SIGEBI.Application.DTOs.UsuarioUpdateRequestDTO
                {
                    Nombre = usuario.Nombre,
                    Email = usuario.Email,
                    Estado = usuario.Estado,
                    Matricula = usuario.Matricula,
                    NumeroEmpleado = usuario.NumeroEmpleado
                };

                // Guardamos el ID y el Tipo de Usuario en el ViewBag porque el DTO de Update no los contiene
                ViewBag.IdUsuario = id;
                ViewBag.TipoUsuario = usuario.TipoUsuario;

                return View(modelo);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: /Usuarios/Editar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, SIGEBI.Application.DTOs.UsuarioUpdateRequestDTO modelo)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.IdUsuario = id;
                // Si hay un error, necesitamos volver a mandar el tipo de usuario a la vista
                ViewBag.TipoUsuario = string.IsNullOrWhiteSpace(modelo.Matricula) ? "Docente" : "Estudiante";
                return View(modelo);
            }

            try
            {
                int idResponsable = ObtenerIdResponsable();

                // Llamamos a tu gestor para que aplique los cambios
                await _servicioUsuarios.ActualizarUsuarioAsync(id, modelo, idResponsable);

                TempData["SuccessMessage"] = $"Los datos de {modelo.Nombre} fueron actualizados correctamente.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.IdUsuario = id;
                ViewBag.TipoUsuario = string.IsNullOrWhiteSpace(modelo.Matricula) ? "Docente" : "Estudiante";
                TempData["ErrorMessage"] = ex.Message;
                return View(modelo);
            }
        }

        // GET: /Usuarios/CambiarEstado/5
        [HttpGet]
        public async Task<IActionResult> CambiarEstado(int id)
        {
            try
            {
                var usuario = await _servicioUsuarios.ObtenerUsuarioPorIdAsync(id);
                if (usuario == null)
                {
                    TempData["ErrorMessage"] = "El usuario no existe.";
                    return RedirectToAction(nameof(Index));
                }

                int idResponsable = ObtenerIdResponsable();

                if (usuario.Estado == "Activo")
                {
                    await _servicioUsuarios.SuspenderUsuarioAsync(id, idResponsable);
                    TempData["SuccessMessage"] = $"Usuario {usuario.Nombre} suspendido exitosamente.";
                }
                else
                {
                    var updateDto = new SIGEBI.Application.DTOs.UsuarioUpdateRequestDTO
                    {
                        Nombre = usuario.Nombre,
                        Email = usuario.Email,
                        Estado = "Activo",
                        Matricula = usuario.Matricula,
                        NumeroEmpleado = usuario.NumeroEmpleado
                    };
                    await _servicioUsuarios.ActualizarUsuarioAsync(id, updateDto, idResponsable);
                    TempData["SuccessMessage"] = $"Usuario {usuario.Nombre} reactivado exitosamente.";
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }

            return RedirectToAction(nameof(Index));
        }

        private int ObtenerIdResponsable()
        {
            var claimId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return int.TryParse(claimId, out int id) ? id : 0;
        }
    }
}