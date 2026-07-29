using Microsoft.Extensions.DependencyInjection; 
using Microsoft.Extensions.Configuration;
using System;
using SIGEBI.AppWeb.Handlers;
using SIGEBI.AppWeb.Services;

namespace SIGEBI.AppWeb.Extencions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
        {
            var apiBaseUrl = configuration["ApiSettings:BaseUrl"] ?? "https://localhost:7291/api/"; 

            // 1. Registramos el handler del token jwt como transitorio
            services.AddTransient<JwtTokenHandler>();
            services.AddHttpContextAccessor();

            // 2. Registramos el servicio HttpClient conectandolo con el handler y la URL base de la API
            services.AddHttpClient<ServicioSolicitudApi>(client =>
            {
                client.BaseAddress = new Uri(apiBaseUrl);
            })
            .AddHttpMessageHandler<JwtTokenHandler>(); // sirve para inyectar el token automáticamente en cada petición

            services.AddHttpClient<ServicioPrestamoApi>(Client =>
            {
                Client.BaseAddress = new Uri(apiBaseUrl);
            }).AddHttpMessageHandler<JwtTokenHandler>();

            services.AddHttpClient<ServicePenalizacionesApi>(Client =>
            {
                Client.BaseAddress = new Uri(apiBaseUrl);

            }).AddHttpMessageHandler<JwtTokenHandler>();



            return services;
        }
    }
}
