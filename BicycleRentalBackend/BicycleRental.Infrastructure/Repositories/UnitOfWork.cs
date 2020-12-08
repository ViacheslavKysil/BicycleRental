using BicycleRental.Domain.Entities;
using BicycleRental.Infrastructure.Database;
using BicycleRental.Infrastructure.Repositories.Interfaces;
using System.Threading.Tasks;

namespace BicycleRental.Infrastructure.Repositories
{
    /// <summary>
    /// Implementation of the <see cref="IUnitOfWork" /> interface.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _dbContext;

        private Repository<Bicycle> _bicycleRepository;
        private Repository<TypeBicycle> _typeBicycleRepository;

        /// <summary>
        /// A constructor with parameter in which the database context is initialized.
        /// </summary>
        public UnitOfWork(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Gets bicycles repository.
        /// </summary>
        public IRepository<Bicycle> Bicycles => 
            _bicycleRepository ??= new Repository<Bicycle>(_dbContext);

        /// <summary>
        /// Gets type of bicycles repository.
        /// </summary>
        public IRepository<TypeBicycle> TypeBicycles => 
            _typeBicycleRepository ??= new Repository<TypeBicycle>(_dbContext);

        /// <summary>
        /// Method for saving database changes.
        /// </summary>
        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
