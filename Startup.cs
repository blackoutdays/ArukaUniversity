using System.Net;
using arusha.Data;
using arusha.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace arusha
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<StoredProcedureService>(); // Добавляем регистрацию сервиса

            services.AddControllersWithViews();

            ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "viewProcedure",
                    pattern: "StoredProcedures/View",
                    defaults: new { controller = "StoredProcedures", action = "ViewProcedure" });

                endpoints.MapControllerRoute(
                    name: "storedProcedure",
                    pattern: "storedProcedure",
                    defaults: new { controller = "StoredProcedure", action = "Index" });

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "catchAll",
                    pattern: "{*url}",
                    defaults: new { controller = "Home", action = "Index" }); // Ловит все остальные запросы и перенаправляет на домашнюю страницу
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "viewProcedure",
                    pattern: "StoredProcedures/View",
                    defaults: new { controller = "StoredProcedures", action = "ViewProcedure" });

                endpoints.MapControllerRoute(
                    name: "storedProcedure",
                    pattern: "storedProcedure",
                    defaults: new { controller = "StoredProcedure", action = "Index" });

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "catchAll",
                    pattern: "{*url}",
                    defaults: new { controller = "Home", action = "Index" }); // Ловит все остальные запросы и перенаправляет на домашнюю страницу
            });
        }
    }
}