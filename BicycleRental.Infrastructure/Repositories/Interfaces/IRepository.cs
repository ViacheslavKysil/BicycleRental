using BicycleRental.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BicycleRental.Infrastructure.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null,
            bool enableAsNoTracking = false);

        void Create(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);
    }
}
