using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace BicycleRental.Web
{
    /// <summary>
    /// Contains the Main method, which is the entry point to the application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The starting point of application.
        /// </summary>
        /// <param name="args">The args.</param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
