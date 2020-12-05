using BicycleRental.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BicycleRental.Core.Services.Interfaces
{
    /// <summary>
    /// Provide interface for <see cref="IBicycleService"/>.
    /// </summary>
    public interface IBicycleService
    {
        /// <summary>
        /// Gets available bicycles.
        /// </summary>
        /// <returns> A <see cref="IEnumerable"/> of <see cref="BicycleDto"/>.</returns>
        Task<IEnumerable<BicycleDto>> GetAvailableBicycles();

        /// <summary>
        /// Gets rented bicycles.
        /// </summary>
        /// <returns> A <see cref="IEnumerable"/> of <see cref="BicycleDto"/>.</returns>
        Task<IEnumerable<BicycleDto>> GetRentedBicycles();

        /// <summary>
        /// Creates a new bicyle.
        /// </summary>
        /// <param name="bicycleDto"></param>
        /// <returns>Task.</returns>
        Task CreateAsync(BicycleDto bicycleDto);

        /// <summary>
        /// Deletes the bicycle.
        /// </summary>
        /// <param name="bicycleId">The identifier of bicycle.</param>
        /// <returns>Task.</returns>
        Task DeleteAsync(Guid bicycleId);

        /// <summary>
        /// Rents of the bicycle.
        /// </summary>
        /// <param name="bicycleId">The identifier of bicycle.</param>
        /// <returns>Task.</returns>
        Task RentBicycleAsync(Guid bicycleId);

        /// <summary>
        /// Cancels rent of the bicycle.
        /// </summary>
        /// <param name="bicycleId">The identifier of bicycle.</param>
        /// <returns>Task.</returns>
        Task CancelRentBicycleAsync(Guid bicycleId);
    }
}
