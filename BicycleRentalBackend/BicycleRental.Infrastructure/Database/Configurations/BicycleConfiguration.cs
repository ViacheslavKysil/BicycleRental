using BicycleRental.Domain.Entities;
using BicycleRental.Infrastructure.Database.Seeds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BicycleRental.Infrastructure.Database.Configurations
{
    /// <summary>
    /// Class containing configurations for table Bicycle.
    /// </summary>
    public class BicycleConfiguration : IEntityTypeConfiguration<Bicycle>
    {
        public void Configure(EntityTypeBuilder<Bicycle> builder)
        {
            builder.HasData(BicycleSeed.DataToSeed);
        }
    }
}
