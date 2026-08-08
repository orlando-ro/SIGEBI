using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIGEBI.AppWeb.Models.DTOs.Usuarios;
using SIGEBI.AppWeb.Models.ViewModels.Perfil;
using SIGEBI.AppWeb.Services.Interfaces;
using System.Security.Claims;

namespace SIGEBI.AppWeb.Controllers
{
    [Authorize]
    public class PerfilController : Controller
    {
        private readonly IServicioUsuarioApi _servicioUsuarioApi;

        public PerfilController(IServicioUsuarioApi servicioUsuarioApi)
        {
            _servicioUsuarioApi = servicioUsuarioApi;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var rol = User.FindFirst(ClaimTypes.Role)?.Value ?? "Desconocido";

            var nombre = User.FindFirst(ClaimTypes.Name)?.Value
                      ?? User.FindFirst(ClaimTypes.GivenName)?.Value
                      ?? User.FindFirst("Nombre")?.Value
                      ?? "Usuario";

            var email = User.FindFirst(ClaimTypes.Email)?.Value
                     ?? User.FindFirst("Email")?.Value
                     ?? "No disponible";

            string etiqueta = rol.Equals("Estudiante", StringComparison.OrdinalIgnoreCase)
                              ? "Matrícula"
                              : "Número de Empleado";

            string valor = User.FindFirst("Matricula")?.Value
                        ?? User.FindFirst("NumeroEmpleado")?.Value
                        ?? "No disponible";

            var model = new PerfilViewModel
            {
                Nombre = nombre,
                Email = email,
                Rol = rol,
                EtiquetaIdentificador = etiqueta,
                ValorIdentificador = valor
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CambiarPassword(PerfilViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }

            try
            {
                var identificador = User.FindFirst("Matricula")?.Value
                                 ?? User.FindFirst("NumeroEmpleado")?.Value;

                if (string.IsNullOrEmpty(identificador))
                {
                    throw new Exception("No se pudo obtener la matrícula o número de empleado del usuario.");
                }

                var dto = new PasswordUpdateDTO
                {
                    PasswordActual = model.PasswordActual,
                    NuevaPassword = model.NuevaPassword
                };

                await _servicioUsuarioApi.CambiarPropiaPasswordAsync(identificador, dto);

                TempData["MensajeExito"] = "Tu contraseña ha sido actualizada correctamente.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["MensajeError"] = ex.Message;
                return View("Index", model);
            }
        }
    }
}