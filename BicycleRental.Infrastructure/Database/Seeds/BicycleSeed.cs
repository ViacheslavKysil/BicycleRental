using BicycleRental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace BicycleRental.Infrastructure.Database.Seeds
{
    internal static class BicycleSeed
    {
        internal static readonly ICollection<Bicycle> DataToSeed;

        static BicycleSeed()
        {
            DataToSeed = new Collection<Bicycle>();
        }
    }
}
