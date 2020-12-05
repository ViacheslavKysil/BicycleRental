using BicycleRental.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BicycleRental.Infrastructure.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> GetAllAsync(Func<IQueryable<TEntity>,
            IIncludableQueryable<TEntity, object>> includes = null);

        Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate,
           Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null,
           bool enableAsNoTracking = false);

        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null,
            bool enableAsNoTracking = false);

        Task CreateAsync(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);
    }
}
