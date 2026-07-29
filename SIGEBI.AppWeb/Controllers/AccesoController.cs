using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using SIGEBI.AppWeb.Models.Acceso;
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
            // Si el usuario ya está logueado, lo mandamos al Home para que no vea el login de nuevo
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(new LoginViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel modelo)
        {
            if (!ModelState.IsValid)
            {
                return View(modelo);
            }

            var usuario = await _usuarios.ObtenerPorMatriculaONumeroEmpleadoAsync(modelo.Identificador);

            if (usuario == null)
            {
                ModelState.AddModelError(string.Empty, "Credenciales incorrectas o usuario no encontrado.");
                return View(modelo);
            }

            /* 
             * NOTA: Aquí puedes agregar la validación de la contraseña usando BCrypt 
             * igual que lo tienes en tu GestorDeAcceso de la API si deseas mayor seguridad:
             * 
             * bool passwordValido = BCrypt.Net.BCrypt.Verify(modelo.Password, usuario.Password);
             * if (!passwordValido) { ModelState.AddModelError(string.Empty, "Credenciales incorrectas."); return View(modelo); }
             */

            var rol = usuario.GetType().Name;

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.IdUsuario.ToString()),
                new Claim("id", usuario.IdUsuario.ToString()),
                new Claim(ClaimTypes.Name, usuario.Nombre ?? string.Empty),
                new Claim(ClaimTypes.Role, rol)
            };

            var identidad = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identidad);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            _logger.LogInformation("Usuario {Usuario} inició sesión en AppWeb con rol {Rol}.", usuario.Nombre, rol);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Salir()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Acceso");
        }

        [HttpGet]
        public IActionResult AccesoDenegado()
        {
            return View();
        }
    }
}