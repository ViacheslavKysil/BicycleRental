using BicycleRental.Domain.Entities;
using BicycleRental.Infrastructure.Database.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BicycleRental.Infrastructure.Database
{
    public sealed class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<TypeBicycle> TypeBicycles { get; set; }
        public DbSet<Bicycle> Bicycles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TypeBicycleConfiguration());
            modelBuilder.ApplyConfiguration(new BicycleConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
