using DDD.Sample.Domain.Repository.Interface;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using DDD.Sample.Infrastructure.Interface;
using DDD.Sample.Infrastructure.Interface.DomainCore;

namespace DDD.Sample.Infrastructure.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, IAggregateRoot
    {
        private readonly IDbContext _dbContext;
        private readonly IQueryable<TEntity> _entities;

        public BaseRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
            _entities = _dbContext.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _entities;
        }

        public IQueryable<TEntity> GetByExpression(Expression<Func<TEntity, bool>> expFunc)
        {
            return _entities.Where(expFunc);
        }

        public void Add(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Added;
        }

        public void Modify(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Deleted;
        }
    }
}
