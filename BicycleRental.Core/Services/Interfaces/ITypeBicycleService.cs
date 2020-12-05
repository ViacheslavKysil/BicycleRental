using BicycleRental.Domain.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BicycleRental.Core.Services.Interfaces
{
    /// <summary>
    /// Provide interface for <see cref="ITypeBicycleService"/>.
    /// </summary>
    public interface ITypeBicycleService
    {
        /// <summary>
        /// Gets type of the bicycle.
        /// </summary>
        /// <param name="nameBicycle">The name of bicycle.</param>
        /// <returns> A <see cref="TypeBicycleDto"/>.</returns>
        Task<TypeBicycleDto> GetTypeBicycle(string nameBicycle);

        /// <summary>
        /// Gets types of the bicycles.
        /// </summary>
        /// <returns> A <see cref="IEnumerable"/> of <see cref="string"/>.</returns>
        Task<IEnumerable<string>> GetAvailableBicycles();
    }
}
