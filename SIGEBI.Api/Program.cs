using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using QuestPDF.Infrastructure;
using SIGEBI.Application.Interfaces;
using SIGEBI.Application.Services;
using SIGEBI.Infrastructure.Persistence;
using SIGEBI.Infrastructure.Services;
using SIGEBI.Application.DependencyInyeccion;
using SIGEBI.Infrastructure.DependencyInjection;

namespace SIGEBI.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            var builder = WebApplication.CreateBuilder(args);

            QuestPDF.Settings.License = LicenseType.Community;

            builder.Services.AddControllers();


            builder.Services.AddApplication();
            builder.Services.AddInfrastructure(builder.Configuration);
          
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
            app.UseHttpsRedirection();

            app.Run();
        }
    }
}