using BicycleRental.Domain.Entities;
using BicycleRental.Infrastructure.Database.Seeds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BicycleRental.Infrastructure.Database.Configurations
{
    /// <summary>
    /// Class containing configurations for table TypeBicycle.
    /// </summary>
    public class TypeBicycleConfiguration : IEntityTypeConfiguration<TypeBicycle>
    {
        public void Configure(EntityTypeBuilder<TypeBicycle> builder)
        {
            builder.HasData(TypeBicycleSeed.DataToSeed);
        }
    }
}
