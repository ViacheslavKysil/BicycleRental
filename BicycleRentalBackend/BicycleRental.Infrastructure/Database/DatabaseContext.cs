using BicycleRental.Domain.Entities;
using BicycleRental.Infrastructure.Database.Configurations;
using Microsoft.EntityFrameworkCore;

namespace BicycleRental.Infrastructure.Database
{
    /// <summary>
    /// Provides access to database.
    /// </summary>
    public sealed class DatabaseContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseContext" /> class.
        /// </summary>
        /// <param name="options"> Options for connecting to database. </param>
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
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
