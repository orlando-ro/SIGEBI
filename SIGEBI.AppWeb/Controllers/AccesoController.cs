using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using SIGEBI.Application.Interfaces;
using System.Security.Claims;

namespace SIGEBI.AppWeb.Controllers
{
    public class AccesoController : Controller
    {
        private readonly IUsuarios _usuarios;
        private readonly ILogger<AccesoController> _logger;

        public AccesoController(
            IUsuarios usuarios,
            ILogger<AccesoController> logger)
        {
            _usuarios = usuarios;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string identificador)
        {
            if (string.IsNullOrWhiteSpace(identificador))
            {
                ModelState.AddModelError(string.Empty, "Debe ingresar su matrícula o número de empleado.");
                return View();
            }

            var usuario = await _usuarios.ObtenerPorMatriculaONumeroEmpleadoAsync(identificador);

            if (usuario == null)
            {
                ModelState.AddModelError(string.Empty, "Usuario no encontrado.");
                return View();
            }

            var rol = usuario.GetType().Name;

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.IdUsuario.ToString()),
                new Claim("id", usuario.IdUsuario.ToString()),
                new Claim(ClaimTypes.Name, usuario.Nombre ?? string.Empty),
                new Claim(ClaimTypes.Role, rol)
            };

            var identidad = new ClaimsIdentity(
                claims,
                CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identidad);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                principal);

            _logger.LogInformation(
                "Usuario {Usuario} inició sesión en AppWeb con rol {Rol}.",
                usuario.Nombre,
                rol);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login", "Acceso");
        }

        [HttpGet]
        public IActionResult AccesoDenegado()
        {
            return View();
        }
    }
}
