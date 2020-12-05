using BicycleRental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace BicycleRental.Infrastructure.Database.Seeds
{
    internal static class TypeBicycleSeed
    {
        internal static readonly ICollection<TypeBicycle> DataToSeed;

        static TypeBicycleSeed()
        {
            DataToSeed = new Collection<TypeBicycle>();

            var mountainBicycle = new TypeBicycle
            {
                Id = Guid.NewGuid(),
                Name = "Custom"
            };

            var customBicycle = new TypeBicycle
            {
                Id = Guid.NewGuid(),
                Name = "Mountain"
            };

            var racingBicycle = new TypeBicycle
            {
                Id = Guid.NewGuid(),
                Name = "Racing"
            };

            DataToSeed.Add(mountainBicycle);
            DataToSeed.Add(customBicycle);
            DataToSeed.Add(racingBicycle);
        }
    }
}
