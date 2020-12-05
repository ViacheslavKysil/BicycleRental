using BicycleRental.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BicycleRental.Infrastructure.Helpers.Randoms
{
    public static class RandomHelpers
    {
        public static TEntity GetRandomElement<TEntity>(this IEnumerable<TEntity> elements)
        {
            return elements.GetRandomElementUsing(new Random());
        }

        public static TEntity GetRandomElementUsing<TEntity>(this IEnumerable<TEntity> elements, Random rand)
        {
            var elementsList = elements.ToList();

            var index = rand.Next(0, elementsList.Count);

            return elementsList.ElementAt(index);
        }

        public static RentalStatus GetRentalStatus()
        {
            Random rand = new Random();

            var randNumber = rand.Next(0, 3);

            if(randNumber == 2)
            {
                return RentalStatus.Rented;
            }
            else
            {
                return RentalStatus.Free;
            }
        }
    }
}
