using BicycleRental.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BicycleRental.Core.Services.Interfaces
{
    public interface IBicycleService
    {
        Task<IEnumerable<BicycleDto>> GetAvailableBicycles();

        Task<IEnumerable<BicycleDto>> GetRentedBicycles();

        Task CreateAsync(BicycleDto bicycleDto);

        Task UpdateAsync(BicycleDto bicycleDto);

        Task DeleteAsync(Guid id);

        Task RentBicycleAsync(Guid id);

        Task CancelRentBicycleAsync(Guid id);
    }
}
