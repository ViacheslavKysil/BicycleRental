using BicycleRental.Infrastructure.Database;
using BicycleRental.Infrastructure.Entities;
using BicycleRental.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BicycleRental.Infrastructure.Repositories
{
    internal class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly ApplicationContext _applicationContext;

        public Repository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, 
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

            return queryable;
        }

        public void Create(TEntity entity)
        {
            throw new NotImplementedException();
        }
       
        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
