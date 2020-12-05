using BicycleRental.Domain.Entities;
using System.Threading.Tasks;

namespace BicycleRental.Infrastructure.Repositories.Interfaces
{
    /// <summary>
    /// Interface for accessing database by repositories.
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Gets bicycles repository.
        /// </summary>
        IRepository<Bicycle> Bicycles { get; }

        /// <summary>
        /// Gets type of bicycles repository.
        /// </summary>
        IRepository<TypeBicycle> TypeBicycles { get; }

        /// <summary>
        /// Method for saving database changes.
        /// </summary>
        Task SaveAsync();
    }
}
