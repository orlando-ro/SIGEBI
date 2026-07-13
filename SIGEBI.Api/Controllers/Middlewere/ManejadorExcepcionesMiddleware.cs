using System.Net;
using System.Text.Json;
using SIGEBI.Domain.Exceptions;

namespace SIGEBI.Api.Middleware
{
    public class ManejadorExcepcionesMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ManejadorExcepcionesMiddleware> _logger;

        public ManejadorExcepcionesMiddleware(
            RequestDelegate next,
            ILogger<ManejadorExcepcionesMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);

                // NUEVO: Capturar las respuestas 401 y 403 generadas por el framework (no lanzan excepción)
                if (context.Response.StatusCode == (int)HttpStatusCode.Forbidden)
                {
                    var idUsuario = context.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
                    _logger.LogWarning("Acceso denegado (403). Usuario ID: {IdUsuario}, Ruta: {Path}", idUsuario, context.Request.Path);

                    // Verificamos que la respuesta no haya empezado a enviarse al cliente
                    if (!context.Response.HasStarted)
                    {
                        await ManejarExcepcionAsync(
                            context,
                            HttpStatusCode.Forbidden,
                            "No tienes los permisos necesarios para realizar esta acción.");
                    }
                }
                else if (context.Response.StatusCode == (int)HttpStatusCode.Unauthorized)
                {
                    _logger.LogWarning("Acceso no autorizado (401) en la ruta: {Path}", context.Request.Path);

                    if (!context.Response.HasStarted)
                    {
                        await ManejarExcepcionAsync(
                            context,
                            HttpStatusCode.Unauthorized,
                            "Debe iniciar sesión o el token ha expirado.");
                    }
                }
            }
            catch (NegocioExeption ex)
            {
                _logger.LogWarning(ex, "Error de regla de negocio.");

                await ManejarExcepcionAsync(
                    context,
                    HttpStatusCode.BadRequest,
                    ex.Message);
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, "Recurso no encontrado.");

                await ManejarExcepcionAsync(
                    context,
                    HttpStatusCode.NotFound,
                    ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                _logger.LogWarning(ex, "Acceso no autorizado.");

                await ManejarExcepcionAsync(
                    context,
                    HttpStatusCode.Unauthorized,
                    "No estás autorizado para realizar esta acción.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrió un error inesperado.");

                await ManejarExcepcionAsync(
                    context,
                    HttpStatusCode.InternalServerError,
                    "Ocurrió un error interno en el servidor.");
            }
        }

        private static async Task ManejarExcepcionAsync(
            HttpContext context,
            HttpStatusCode statusCode,
            string mensaje)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            var respuesta = new
            {
                statusCode = context.Response.StatusCode,
                mensaje
            };

            var json = JsonSerializer.Serialize(respuesta);

            await context.Response.WriteAsync(json);
        }
    }
}