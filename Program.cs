using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace arusha
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>(); // Проверьте это место на правильность использования класса Startup
                });
    }
}
