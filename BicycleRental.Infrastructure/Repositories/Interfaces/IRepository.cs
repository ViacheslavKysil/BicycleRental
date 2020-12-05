using BicycleRental.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BicycleRental.Infrastructure.Repositories.Interfaces
{
    /// <summary>
    /// Interface for generic repository.
    /// </summary>
    /// <typeparam name="TEntity"> The type of the entity. </typeparam>
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        /// <summary>
        /// Gets all entities.
        /// </summary>
        /// <param name="includes"> A function to include navigation properties. </param>
        /// <param name="enableAsNoTracking">
        /// A <see cref="bool" /> value which determines whether the return entity will be tracked by
        /// EF Core context or not. Default value is false i.e. tracking is not enabled by default.
        /// </param>
        /// <returns> A <see cref="IEnumerable{TEntity}" />. </returns>
        /// <remarks> This method default no-tracking query. </remarks>
        Task<IEnumerable<TEntity>> GetAllAsync(
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null,
            bool enableAsNoTracking = false);

        /// <summary>
        /// Gets entity that satisfies the specified <paramref name="predicate" />.
        /// </summary>
        /// <param name="predicate"> A function to test each element for a condition. </param>
        /// <param name="includes"> A function to include navigation properties. </param>
        /// <param name="enableAsNoTracking">
        /// A <see cref="bool" /> value which determines whether the return entity will be tracked by
        /// EF Core context or not. Default value is false i.e tracking is not enabled by default.
        /// </param>
        /// <returns>
        /// An <see cref="TEntity" /> that satisfy the condition specified by
        /// <paramref name="predicate" /> if entity is found; otherwise null.
        /// </returns>
        /// <remarks> This method default no-tracking query. </remarks>
        Task<TEntity> SingleAsync(
           Expression<Func<TEntity, bool>> predicate,
           Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null,
           bool enableAsNoTracking = false);

        /// <summary>
        /// Creates new entity.
        /// </summary>
        /// <param name="entity"> Any entity in project inherits from BaseEntity. </param>
        Task CreateAsync(TEntity entity);

        /// <summary>
        /// Updates an existing entity.
        /// </summary>
        /// <param name="entity"> Any entity in project inherits from BaseEntity. </param>
        void Update(TEntity entity);

        /// <summary>
        /// Marks IsDeleted flag in entity to true, and updates entity.
        /// </summary>
        /// <param name="entity"> Any entity in project inherits from BaseEntity. </param>
        void Delete(TEntity entity);
    }
}
