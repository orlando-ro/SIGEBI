using System.Net;
using System.Text.Json;
using SIGEBI.Domain.Exceptions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace SIGEBI.Api.Middleware
{
    public class ManejadorExcepcionesMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ManejadorExcepcionesMiddleware> _logger;
        private readonly IWebHostEnvironment _env;

        public ManejadorExcepcionesMiddleware(
            RequestDelegate next,
            ILogger<ManejadorExcepcionesMiddleware> logger,
            IWebHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);

                if (context.Response.StatusCode == (int)HttpStatusCode.Forbidden)
                {
                    var idUsuario = context.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
                    _logger.LogWarning("Acceso denegado (403). Usuario ID: {IdUsuario}, Ruta: {Path}", idUsuario, context.Request.Path);

                    if (!context.Response.HasStarted)
                    {
                        await ManejarExcepcionAsync(context, HttpStatusCode.Forbidden, "No tienes los permisos necesarios para realizar esta acción.");
                    }
                }
                else if (context.Response.StatusCode == (int)HttpStatusCode.Unauthorized)
                {
                    _logger.LogWarning("Acceso no autorizado (401) en la ruta: {Path}", context.Request.Path);

                    if (!context.Response.HasStarted)
                    {
                        await ManejarExcepcionAsync(context, HttpStatusCode.Unauthorized, "Debe iniciar sesión o el token ha expirado.");
                    }
                }
            }
            catch (NegocioExeption ex)
            {
                _logger.LogWarning(ex, "Error de regla de negocio.");
                await ManejarExcepcionAsync(context, HttpStatusCode.BadRequest, ex.Message);
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, "Recurso no encontrado.");
                await ManejarExcepcionAsync(context, HttpStatusCode.NotFound, ex.Message);
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning(ex, "Argumento inválido proporcionado por el cliente.");
                await ManejarExcepcionAsync(context, HttpStatusCode.BadRequest, ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                _logger.LogWarning(ex, "Acceso no autorizado.");
                await ManejarExcepcionAsync(context, HttpStatusCode.Unauthorized, "No estás autorizado para realizar esta acción.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrió un error inesperado.");

                // Si estamos desarrollando, mostramos el error real. Si es prod, mostramos el genérico.
                string mensaje = _env.IsDevelopment()
                    ? ex.Message
                    : "Ocurrió un error interno en el servidor.";

                string? detalle = _env.IsDevelopment() ? ex.StackTrace : null;

                await ManejarExcepcionAsync(context, HttpStatusCode.InternalServerError, mensaje, detalle);
            }
        }

        private static async Task ManejarExcepcionAsync(
            HttpContext context,
            HttpStatusCode statusCode,
            string mensaje,
            string? detalle = null)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            // Agregamos el TraceId y el detalle opcional
            var respuesta = new
            {
                statusCode = context.Response.StatusCode,
                mensaje,
                detalle,
                traceId = context.TraceIdentifier
            };

            var opcionesJson = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
            };

            var json = JsonSerializer.Serialize(respuesta, opcionesJson);

            await context.Response.WriteAsync(json);
        }
    }
}