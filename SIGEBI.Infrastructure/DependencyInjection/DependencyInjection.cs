using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SIGEBI.Infrastructure.Persistence;
using SIGEBI.Infrastructure.Persistence.Repositories;
using SIGEBI.Application.Interfaces;
using SIGEBI.Infrastructure.Services;
using SIGEBI.Application.Services;
using SIGEBI.Infrastructure.Repositories.SIGEBI.Infrastructure.Repositories;
using SIGEBI.Infrastructure.Repositories;

namespace SIGEBI.Infrastructure.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration) {

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<SIGEBIDbContext>(optionsAction => optionsAction.UseSqlServer(connectionString));

            // Repositorios
            services.AddScoped<IRepositorioPrestamo, RepositorioPrestamo>();
            services.AddScoped<IRepoSolicitud, RepositorioSolicitudes>();
            services.AddScoped<IRepositorioDevolucion, RepositorioDevoluciones>();
            services.AddScoped<IRepoPenalizacion, RepositorioPenalizacion>();
            services.AddScoped<IRepositorioAuditoria, RepositorioAuditoria>();
            services.AddScoped<IRepositorioReporte, RepositorioReporte>();
            services.AddScoped<IUsuarios, RepositorioUsuario>();
            services.AddScoped<IRepositorioLibro, RepositorioLibro>();
            services.AddScoped<IRepositorioEjemplar, RepositorioEjemplar>();
            services.AddScoped<IRepositorioCategoria, RepositorioCategoria>();
            services.AddScoped<IRepositorioNotificacion, RepositorioNotificaciones>();



            // Servicios de Infraestructura
            services.AddScoped<IPDFService, GeneradorReportePDF>();
            services.AddScoped<IServicioAuditoria, ServicioAuditoria>();
            services.AddScoped<IStorageService, LocalStorageService>();
            services.AddScoped<IServicioNotificacion, ServicioNotificaciones>();
            services.AddScoped<IServicioJwt, ServicioJwt>();


            return services;
        }
    }
}
