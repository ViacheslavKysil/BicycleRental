using AutoMapper;
using BicycleRental.Core.AutoMapper;
using BicycleRental.Core.Services;
using BicycleRental.Core.Services.Interfaces;
using BicycleRental.Infrastructure.Database;
using BicycleRental.Infrastructure.Repositories;
using BicycleRental.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BicycleRental.Web
{
    /// <summary>
    /// Configures the application, configures the services that the application will use,
    /// and installs components to handle the request or middleware.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup" /> class.
        /// </summary>
        /// <param name="configuration"> Interface for configuration application properties. </param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // Adds services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureSqlServer(services);
            ConfigureServiceScope(services);

            services.AddControllers();

            services.AddAutoMapper(typeof(CoreMapperProfile));
        }

        // Configures the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void ConfigureSqlServer(IServiceCollection services)
        {
            var sqlServerConnectionString = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<DatabaseContext>(options => options
                .UseSqlServer(sqlServerConnectionString));
        }

        private void ConfigureServiceScope(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IBicycleService, BicycleService>();
            services.AddScoped<ITypeBicycleService, TypeBicycleService>();
        }
    }
}
