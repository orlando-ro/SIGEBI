using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SIGEBI.AppEscritorio.Services.Interfaces;
using SIGEBI.AppEscritorio.Services.Implementations;
using System;

namespace SIGEBI.AppEscritorio.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Obtenemos la URL base desde el appsettings.json
            var apiBaseUrl = configuration["ApiSettings:BaseUrl"] ?? "https://localhost:7291/api/";

            // 1. Registramos el servicio de Acceso conectado con la URL de la API
            services.AddHttpClient<IServicioAccesoApi, ServicioAccesoApi>(client => 
            {
                client.BaseAddress = new Uri(apiBaseUrl);
            });

            // Nota: Aquí abajo iremos agregando los demás servicios (Catálogo, Préstamos, etc.)
            // cuando toque inyectarles el token desde el SessionManager.

            return services;
        }
    }
}