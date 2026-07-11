using Microsoft.Extensions.DependencyInjection;
using SIGEBI.Application.Interfaces;
using SIGEBI.Application.Services;

namespace SIGEBI.Application.DependencyInyeccion
{
    public static class DependencyInyection
    {
        public static IServiceCollection AddApplication(this IServiceCollection service) {

            //Gestor Prestamo
            service.AddScoped<IservicioPrestamo, GestorPrestamos>();
            

            //Gestor Solicitud
            service.AddScoped<IServicioSolicitud, GestorSolicitudes>();

            // Servicios
            service.AddScoped<IServicioPoliticaNegocio, ServicioPoliticaNegocio>();
            service.AddScoped<IServiciosObtenerBibliotecario, ServicioObtenerBibliotecario>();


            return service;
        }

    }
}
