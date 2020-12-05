using BicycleRental.Domain.Contracts;
using BicycleRental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BicycleRental.Core.Services.Interfaces
{
    public interface ITypeBicycleService
    {
        Task<TypeBicycleDto> GetTypeBicycle(string name);
        Task<string> GetTypeBicycle2(Guid id);
        Task<IEnumerable<string>> GetAvailableBicycles();
    }
}
