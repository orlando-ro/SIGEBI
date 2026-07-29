using Microsoft.Extensions.DependencyInjection; 
using Microsoft.Extensions.Configuration;
using System;

namespace SIGEBI.AppWeb.Extencions
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
