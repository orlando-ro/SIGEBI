
using Microsoft.EntityFrameworkCore;
using SIGEBI.Infrastructure.Persistence;

namespace SIGEBI.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            
            builder.Services.AddControllers();
            
            builder.Services.AddOpenApi();

            // ---> INICIO DE LA CONFIGURACIÓN DE BASE DE DATOS <---
            // 1. Leer el string de conexión desde appsettings.json
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            // 2. Registrar SIGEBIDbContext para usar SQL Server
            builder.Services.AddDbContext<SIGEBIDbContext>(options =>
                options.UseSqlServer(connectionString));

            // ---> FIN DE LA CONFIGURACIÓN DE BASE DE DATOS <---

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
