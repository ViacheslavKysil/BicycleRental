using BicycleRental.Infrastructure.Entities;
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

        public DbSet<Bicycle> Bicycles { get; set; }
        public DbSet<TypeBicycle> TypeBicycles { get; set; }
        public DbSet<RentalStatus> RentalStatuses { get; set; }
    }
}
