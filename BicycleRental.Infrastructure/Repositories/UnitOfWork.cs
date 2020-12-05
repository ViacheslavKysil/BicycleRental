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
        private readonly DatabaseContext _dbContext;

        private Repository<Bicycle> _bicycleRepository;
        private Repository<TypeBicycle> _typeBicycleRepository;

        public UnitOfWork(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IRepository<Bicycle> Bicycles => 
            _bicycleRepository ??= new Repository<Bicycle>(_dbContext);


        public IRepository<TypeBicycle> TypeBicycles => 
            _typeBicycleRepository ??= new Repository<TypeBicycle>(_dbContext);

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
