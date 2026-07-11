using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SIGEBI.Infrastructure.Persistence;
using SIGEBI.Infrastructure.Persistence.Repositories;
using SIGEBI.Application.Interfaces;
using SIGEBI.Infrastructure.Services;

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



            // Servicios de Infraestructura

            return services;
        }
    }
}
