using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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

            
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Conexión a Base de Datos
            builder.Services.AddDbContext<SIGEBIDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            var app = builder.Build();

            using (var scope = app.Services.CreateScope()) {

                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<SIGEBIDbContext>();
                context.Database.EnsureCreated();
            }

           

            if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }

            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}