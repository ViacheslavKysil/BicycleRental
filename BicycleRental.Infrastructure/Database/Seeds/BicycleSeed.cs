using BicycleRental.Domain.Entities;
using BicycleRental.Infrastructure.Helpers.Randoms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BicycleRental.Infrastructure.Database.Seeds
{
    /// <summary>
    /// Static class that generates values for seeding Bicycle table.
    /// </summary>
    internal static class BicycleSeed
    {
        internal static readonly ICollection<Bicycle> DataToSeed;

        static BicycleSeed()
        {
            const int bicycleCount = 5;

            DataToSeed = new Collection<Bicycle>();

            for (int i = 0; i < bicycleCount; i++)
            {
                var bicycle = new Bicycle
                {
                    Id = Guid.NewGuid(),
                    Name = $"Bicycle abc{i + 1}",
                    RentalStatus = RandomHelpers.GetRentalStatus(),
                    Price = 11999 + (i * 500),
                    TypeBicycleId = TypeBicycleSeed.DataToSeed.GetRandomElement().Id
                };

                DataToSeed.Add(bicycle);
            }
        }
    }
}
