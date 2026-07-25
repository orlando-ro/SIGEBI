using QuestPDF.Infrastructure;
using SIGEBI.Application.DependencyInyeccion;
using SIGEBI.Infrastructure.DependencyInjection;
using SIGEBI.Infrastructure.Persistence;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace SIGEBI.AppWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            QuestPDF.Settings.License = LicenseType.Community;

            builder.Services.AddControllersWithViews();

            builder.Services.AddHttpContextAccessor();

            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            
            builder.Services.AddApplication();
            builder.Services.AddInfrastructure(builder.Configuration);

           
            builder.Services
                .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Acceso/Login";
                    options.AccessDeniedPath = "/Acceso/AccesoDenegado";

                    options.Cookie.Name = "SIGEBI.AppWeb.Auth";
                    options.Cookie.HttpOnly = true;
                    options.Cookie.IsEssential = true;

                    options.ExpireTimeSpan = TimeSpan.FromHours(2);
                    options.SlidingExpiration = true;
                });

            builder.Services.AddAuthorization();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<SIGEBIDbContext>();
                context.Database.EnsureCreated();
            }

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();

            
            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}