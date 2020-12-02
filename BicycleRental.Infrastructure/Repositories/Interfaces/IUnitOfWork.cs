using BicycleRental.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BicycleRental.Infrastructure.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Bicycle> Bicycles { get; }

        IRepository<RentalStatus> RentalStatuses { get; }

        IRepository<TypeBicycle> TypeBicycles { get; }
    }
}
