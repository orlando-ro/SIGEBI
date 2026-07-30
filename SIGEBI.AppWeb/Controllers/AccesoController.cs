using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using SIGEBI.AppWeb.Models.Acceso;
using SIGEBI.AppWeb.Models.DTOs.Acceso;
using SIGEBI.AppWeb.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SIGEBI.AppWeb.Controllers
{
    public class AccesoController : Controller
    {
        private readonly IServicioAccesoApi _servicioAccesoApi;
        private readonly ILogger<AccesoController> _logger;

        public AccesoController(IServicioAccesoApi servicioAccesoApi, ILogger<AccesoController> logger)
        {
            _servicioAccesoApi = servicioAccesoApi;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Login()
        {
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

            try
            {
                var requestDto = new LoginRequestDTO
                {
                    Identificador = modelo.Identificador,
                    Password = modelo.Password
                };

                // Hacemos la petición a la API
                string token = await _servicioAccesoApi.IniciarSesionAsync(requestDto);

                // Guardamos el token en la sesión para el JwtTokenHandler
                HttpContext.Session.SetString("TokenJwt", token);

                // Decodificamos el JWT para crear la Cookie de sesión
                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadJwtToken(token);

                var identidad = new ClaimsIdentity(jwtToken.Claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identidad);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Intento de login fallido.");
                ModelState.AddModelError(string.Empty, "Credenciales incorrectas o servidor no disponible.");
                return View(modelo);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Salir()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Remove("TokenJwt");
            return RedirectToAction("Login", "Acceso");
        }

        [HttpGet]
        public IActionResult AccesoDenegado()
        {
            return View();
        }
    }
}