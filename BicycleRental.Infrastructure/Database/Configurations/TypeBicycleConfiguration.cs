using BicycleRental.Domain.Entities;
using BicycleRental.Infrastructure.Database.Seeds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BicycleRental.Infrastructure.Database.Configurations
{
    public class TypeBicycleConfiguration : IEntityTypeConfiguration<TypeBicycle>
    {
        public void Configure(EntityTypeBuilder<TypeBicycle> builder)
        {
            builder.HasData(TypeBicycleSeed.DataToSeed);
        }
    }
}
