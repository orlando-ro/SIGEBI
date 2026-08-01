using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SIGEBI.AppEscritorio.Forms.Auth;
using SIGEBI.AppEscritorio.Forms.Catalogo;
using SIGEBI.AppEscritorio.Forms.Devoluciones;
using SIGEBI.AppEscritorio.Forms.Main;
using SIGEBI.AppEscritorio.Forms.Notificaciones;
using SIGEBI.AppEscritorio.Forms.Prestamos;
using SIGEBI.AppEscritorio.Forms.Solicitudes;
using SIGEBI.AppEscritorio.Forms.Usuarios;
//using SIGEBI.AppEscritorio.Forms.Solicitudes;
using SIGEBI.AppEscritorio.Handlers;
using SIGEBI.AppEscritorio.Services;
using SIGEBI.AppEscritorio.Services.Implementations;
using SIGEBI.AppEscritorio.Services.Interfaces;
using SIGEBI.AppEscritorio.Forms.Penalizaciones;
using SIGEBI.AppEscritorio.Forms.Auditoria;
using System;

namespace SIGEBI.AppEscritorio.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Obtenemos la URL base desde el appsettings.json
            var apiBaseUrl = configuration["ApiSettings:BaseUrl"] ?? "https://localhost:7291/api/";

            services.AddTransient<AuthHandler>();

            // 1. Registramos el servicio de Acceso conectado con la URL de la API
            services.AddHttpClient<IServicioAccesoApi, ServicioAccesoApi>(client => 
            {
                client.BaseAddress = new Uri(apiBaseUrl);
            });

            services.AddHttpClient<IServicioPrestamoApi, ServicioPrestamoApi>(client =>
            {

                client.BaseAddress = new Uri(apiBaseUrl);
            }
            ).AddHttpMessageHandler<AuthHandler>();

            services.AddHttpClient<IServicioSolicitudApi, ServicioSolicitudApi>(client =>
            {
                client.BaseAddress = new Uri(apiBaseUrl);
            })
            .AddHttpMessageHandler<AuthHandler>();

            services.AddHttpClient<IServicioUsuarioApi, ServicioUsuarioApi>(client =>
            {
                client.BaseAddress = new Uri(apiBaseUrl);
            })
            .AddHttpMessageHandler<AuthHandler>();

            services.AddHttpClient<IServicioCategoriaApi, ServicioCategoriaApi>(client =>
            {
                client.BaseAddress = new Uri(apiBaseUrl);
            }).AddHttpMessageHandler<AuthHandler>();

            services.AddHttpClient<IServicioCatalogoApi, ServicioCatalogoApi>(client =>
            {
                client.BaseAddress = new Uri(apiBaseUrl);
            }).AddHttpMessageHandler<AuthHandler>();

            services.AddHttpClient<IServicioNotificacionApi, ServicioNotificacionApi>(client =>
            {
                client.BaseAddress = new Uri(apiBaseUrl);
            }).AddHttpMessageHandler<AuthHandler>();


            services.AddHttpClient<IServicioDevolucionApi, ServicioDevolucionApi>(client =>
            {
                client.BaseAddress = new Uri(apiBaseUrl);
            })
            .AddHttpMessageHandler<AuthHandler>();

            services.AddHttpClient<IServicioPenalizacionApi, ServicioPenalizacionApi>(client =>
            {
                client.BaseAddress = new Uri(apiBaseUrl);
            })
            .AddHttpMessageHandler<AuthHandler>();


            services.AddHttpClient<IServicioAuditoriaApi, ServicioAuditoriaApi>(client =>
            {
                client.BaseAddress = new Uri(apiBaseUrl);
            }) .AddHttpMessageHandler<AuthHandler>();



            return services;
        }

        public static IServiceCollection AddFormServices(this IServiceCollection services)
        {
            services.AddTransient<FormLogin>();
            services.AddTransient<FormPrincipal>();
            services.AddTransient<FormAprobarSolicitudes>();
            services.AddTransient<FormConsultarActivos>();
            services.AddTransient<FormHistorialPrestamos>();
            services.AddTransient<FormGestionSolicitudes>();
            services.AddTransient<formGestionUsuarios>();
            services.AddTransient<FormUsuarioMantenimiento>();
            services.AddTransient<formGestionCatalogo>();
            services.AddTransient<FormLibroMantenimiento>();
            services.AddTransient<formGestionCategorias>();
            services.AddTransient<FormCategoriaMantenimiento>();
            services.AddTransient<formGestionNotificaciones>();
            services.AddTransient<FormProcesarDevolucion>();
            services.AddTransient<FormHistorialDevoluciones>();
            services.AddTransient<FormGestionPenalizaciones>();
            services.AddTransient<FormAuditoria>();

            return services;
        }
    }
}