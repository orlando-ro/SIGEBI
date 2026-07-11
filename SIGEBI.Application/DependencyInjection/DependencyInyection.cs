using Microsoft.Extensions.DependencyInjection;
using SIGEBI.Application.Interfaces;
using SIGEBI.Application.Services;

namespace SIGEBI.Application.DependencyInyeccion
{
    public static class DependencyInyection
    {
        public static IServiceCollection AddApplication(this IServiceCollection service) {

            // Gestores
            service.AddScoped<IservicioPrestamo, GestorPrestamos>();
            service.AddScoped<IServicioSolicitud, GestorSolicitudes>();
            service.AddScoped<IServicioDevolucion, GestorDevoluciones>();
            service.AddScoped<IServicioPenalizacion, GestorPenalizaciones>();
            service.AddScoped<IServicioUsuarios, GestorUsuarios>();
            service.AddScoped<IServicioAcceso, GestorDeAcceso>();



            // Servicios
            service.AddScoped<IServicioPoliticaNegocio, ServicioPoliticaNegocio>();
            service.AddScoped<IServiciosObtenerBibliotecario, ServicioObtenerBibliotecario>();


            return service;
        }

    }
}
