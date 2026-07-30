using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
namespace SIGEBI.AppEscritorio.Extencions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
        {
            var apiBaseUrl = configuration["ApiSettings:BaseUrl"];
            // Register your API services here
            // Example:
            // services.AddHttpClient<IMyApiService, MyApiService>(client =>
            // {
            //     client.BaseAddress = new Uri(configuration["ApiSettings:BaseUrl"]);
            // });
            return services;
        }
    }
}
