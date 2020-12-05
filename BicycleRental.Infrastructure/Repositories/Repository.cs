using BicycleRental.Domain.Entities;
using BicycleRental.Infrastructure.Database;
using BicycleRental.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BicycleRental.Infrastructure.Repositories
{
    /// <summary>
    /// Implementation of the <see cref="IRepository{TEntity}" /> interface.
    /// </summary>
    /// <typeparam name="TEntity"> The type of the entity. </typeparam>
    internal class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DatabaseContext _dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{TEntity}" /> class.
        /// </summary>
        /// <param name="dbContext"> The database context. </param>
        public Repository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

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
        public async Task<IEnumerable<TEntity>> GetAllAsync(
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null,
            bool enableAsNoTracking = false)
        {
            var queryable = _dbContext.Set<TEntity>().AsQueryable()
                .Where(e => !e.IsDeleted);

            if (enableAsNoTracking)
            {
                queryable = queryable.AsNoTracking();
            }

            if (includes != null)
            {
                queryable = includes(queryable);
            }

            return await queryable.ToListAsync();
        }

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
        public async Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate,
           Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null,
           bool enableAsNoTracking = false)
        {
            var queryable = _dbContext.Set<TEntity>().AsQueryable();

            if (enableAsNoTracking)
            {
                queryable = queryable.AsNoTracking();
            }

            if (includes != null)
            {
                queryable = includes(queryable);
            }

            return await queryable.SingleOrDefaultAsync(predicate);
        }

        /// <summary>
        /// Creates new entity.
        /// </summary>
        /// <param name="entity"> Any entity in project inherits from BaseEntity. </param>
        public async Task CreateAsync(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
        }

        /// <summary>
        /// Updates an existing entity.
        /// </summary>
        /// <param name="entity"> Any entity in project inherits from BaseEntity. </param>
        public void Update(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// Marks IsDeleted flag in entity to true, and updates entity.
        /// </summary>
        /// <param name="entity"> Any entity in project inherits from BaseEntity. </param>
        public void Delete(TEntity entity)
        {
            entity.IsDeleted = true;

            _dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
