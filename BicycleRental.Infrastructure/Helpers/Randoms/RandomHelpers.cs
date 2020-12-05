using BicycleRental.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BicycleRental.Infrastructure.Helpers.Randoms
{
    /// <summary>
    /// Static class containing methods for creating and getting random elements
    /// </summary>
    public static class RandomHelpers
    {
        /// <summary>
        /// Extension method that gets random element from <see cref="IEnumerable{TEntity}" />
        /// </summary>
        /// <typeparam name="TEntity"> The type of elements. </typeparam>
        /// <param name="elements"> A <see cref="IEnumerable{TEntity}" /> from which to get the item. </param>
        /// <returns> Random <see cref="TEntity" />. </returns>
        public static TEntity GetRandomElement<TEntity>(this IEnumerable<TEntity> elements)
        {
            return elements.GetRandomElementUsing(new Random());
        }

        /// <summary>
        /// Helper extension method that gets a random element from <see cref="IEnumerable{TEntity}" />.
        /// Receives a random object as a parameter, which ensures that you get a different value each time.
        /// </summary>
        /// <typeparam name="TEntity"> The type of elements. </typeparam>
        /// <param name="elements"> A <see cref="IEnumerable{TEntity}" /> from which to get the item. </param>
        /// <param name="rand"> <see cref="Random" /> object for getting a random number. </param>
        /// <returns> Random <see cref="TEntity" />. </returns>
        public static TEntity GetRandomElementUsing<TEntity>(this IEnumerable<TEntity> elements, Random rand)
        {
            var elementsList = elements.ToList();

            var index = rand.Next(0, elementsList.Count);

            return elementsList.ElementAt(index);
        }

        /// <summary>
        /// Method for getting random rental status (free or rented).
        /// </summary>
        /// <returns>Rental status.</returns>
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
