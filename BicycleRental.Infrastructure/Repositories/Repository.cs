using BicycleRental.Domain.Entities;
using BicycleRental.Infrastructure.Database;
using BicycleRental.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BicycleRental.Infrastructure.Repositories
{
    internal class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly ApplicationContext _applicationContext;

        public Repository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null)
        {
            var queryable = _applicationContext.Set<TEntity>().AsQueryable()
                .Where(e => !e.IsDeleted);

            if (includes != null)
            {
                queryable = includes(queryable);
            }

            return await queryable.ToListAsync();
        }

        public async Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate,
           Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null,
           bool enableAsNoTracking = false)
        {
            var queryable = _applicationContext.Set<TEntity>().AsQueryable();

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

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, 
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null, 
            bool enableAsNoTracking = false)
        {
            var queryable = _applicationContext.Set<TEntity>().AsQueryable()
                .Where(e => !e.IsDeleted);

            if(enableAsNoTracking)
            {
                queryable = queryable.AsNoTracking();
            }

            if(includes != null)
            {
                queryable = includes(queryable);
            }

            if(predicate != null)
            {
                queryable = queryable.Where(predicate);
            }

            return await queryable.ToListAsync();
        }

        public async Task CreateAsync(TEntity entity)
        {
            await _applicationContext.Set<TEntity>().AddAsync(entity);
        }
       
        public void Update(TEntity entity)
        {
            _applicationContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            entity.IsDeleted = true;

            _applicationContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
