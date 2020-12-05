using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BicycleRental.Core.AutoMapper;
using BicycleRental.Core.Services;
using BicycleRental.Core.Services.Interfaces;
using BicycleRental.Infrastructure.Database;
using BicycleRental.Infrastructure.Repositories;
using BicycleRental.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BicycleRental.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureSqlServer(services);
            ConfigureServiceScope(services);

            services.AddControllers();

            services.AddAutoMapper(typeof(CoreMapperProfile));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
