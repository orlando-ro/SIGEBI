using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using SIGEBI.AppWeb.Handlers;
using SIGEBI.AppWeb.Services;
using SIGEBI.AppWeb.Services.Interfaces;



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

            // 2. Registro de Servicios con sus Interfaces y el Handler de Token

            services.AddHttpClient<IServicioAccesoApi, ServicioAccesoApi>(client =>
            {
                client.BaseAddress = new Uri(apiBaseUrl);
            });

            services.AddHttpClient<IServicioCatalogoApi, ServicioCatalogoApi>(client =>
            {
                client.BaseAddress = new Uri(apiBaseUrl);
            })
            .AddHttpMessageHandler<JwtTokenHandler>();

            services.AddHttpClient<IServicioSolicitudApi, ServicioSolicitudApi>(client =>
            {
                client.BaseAddress = new Uri(apiBaseUrl);
            })
            .AddHttpMessageHandler<JwtTokenHandler>();

            services.AddHttpClient<IServicioPrestamoApi, ServicioPrestamoApi>(client =>
            {
                client.BaseAddress = new Uri(apiBaseUrl);
            })
            .AddHttpMessageHandler<JwtTokenHandler>();

            services.AddHttpClient<IServicioPenalizacionesApi, ServicePenalizacionesApi>(client =>
            {
                client.BaseAddress = new Uri(apiBaseUrl);
            })
            .AddHttpMessageHandler<JwtTokenHandler>();

            services.AddHttpClient<IServicioNotificacionesApi, ServicioNotificacionesApi>(client =>
            {
                client.BaseAddress = new Uri(apiBaseUrl);
            })
            .AddHttpMessageHandler<JwtTokenHandler>();

            return services;
        }
    }
}