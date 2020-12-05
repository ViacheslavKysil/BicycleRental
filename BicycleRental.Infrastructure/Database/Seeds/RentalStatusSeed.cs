using BicycleRental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace BicycleRental.Infrastructure.Database.Seeds
{
    internal static class RentalStatusSeed
    {
        internal static readonly ICollection<RentalStatus> DataToSeed;

        static RentalStatusSeed()
        {
            DataToSeed = new Collection<RentalStatus>();

            var freeStatus = new RentalStatus
            {
                Id = Guid.NewGuid(),
                Name = "Free"
            };

            var rentedStatus = new RentalStatus
            {
                Id = Guid.NewGuid(),
                Name = "Rented"
            };

            DataToSeed.Add(freeStatus);
            DataToSeed.Add(rentedStatus);
        }
    }
}
