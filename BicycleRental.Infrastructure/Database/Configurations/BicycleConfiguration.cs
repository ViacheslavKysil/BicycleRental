using BicycleRental.Domain.Entities;
using BicycleRental.Infrastructure.Database.Seeds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BicycleRental.Infrastructure.Database.Configurations
{
    public class BicycleConfiguration : IEntityTypeConfiguration<Bicycle>
    {
        public void Configure(EntityTypeBuilder<Bicycle> builder)
        {
            builder.HasData(BicycleSeed.DataToSeed);
        }
    }
}
