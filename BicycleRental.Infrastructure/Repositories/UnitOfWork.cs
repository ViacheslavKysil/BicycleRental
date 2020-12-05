using BicycleRental.Domain.Entities;
using BicycleRental.Infrastructure.Database;
using BicycleRental.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BicycleRental.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _applicationContext;

        private Repository<Bicycle> _bicycleRepository;
        private Repository<RentalStatus> _rentalStatusRepository;
        private Repository<TypeBicycle> _typeBicycleRepository;

        public UnitOfWork(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public IRepository<Bicycle> Bicycles => _bicycleRepository ??= new Repository<Bicycle>(_applicationContext);

        public IRepository<RentalStatus> RentalStatuses => 
           _rentalStatusRepository ??= new Repository<RentalStatus>(_applicationContext);

        public IRepository<TypeBicycle> TypeBicycles => 
            _typeBicycleRepository ??= new Repository<TypeBicycle>(_applicationContext);

        public async Task SaveAsync()
        {
            await _applicationContext.SaveChangesAsync();
        }
    }
}
