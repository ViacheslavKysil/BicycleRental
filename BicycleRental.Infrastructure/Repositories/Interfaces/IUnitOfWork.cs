using BicycleRental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BicycleRental.Infrastructure.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Bicycle> Bicycles { get; }

        IRepository<TypeBicycle> TypeBicycles { get; }

        Task SaveAsync();
    }
}
