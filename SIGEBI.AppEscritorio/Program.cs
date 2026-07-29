using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SIGEBI.AppEscritorio.Extencions;
using SIGEBI.AppEscritorio.Forms.Auth;
using SIGEBI.AppEscritorio.Forms.Main;
using System;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace SIGEBI.AppEscritorio
{
    internal static class Program
    {
        // Contenedores globales para la app de escritorio
        public static IServiceProvider ServiceProvider { get; private set; } = null!;
        public static IConfiguration Configuration { get; private set; } = null!;

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // 1. Cargar el appsettings.json
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();

            // 2. Preparar la Inyección de Dependencias
            var services = new ServiceCollection();


            // llamamos a la extensión para registrar los servicios de la API
            services.AddApiServices(Configuration);

            // 3. Registrar los Formularios (Obligatorio para inyectarles cosas)
            services.AddTransient<FormLogin>();
            services.AddTransient<FormPrincipal>();

            // 4. Construir el motor y arrancar
            ServiceProvider = services.BuildServiceProvider();


            var loginForm = ServiceProvider.GetRequiredService<FormLogin>();

            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                Application.Run(ServiceProvider.GetRequiredService<FormPrincipal>());
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
