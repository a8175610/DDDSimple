using System;
using System.Linq;
using System.Linq.Expressions;
using DDD.Sample.Infrastructure.Interface.DomainCore;

namespace DDD.Sample.Domain.Repository.Interface
{
    public interface IBaseRepository<TEntity> where TEntity : class, IAggregateRoot
    {
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetByExpression(Expression<Func<TEntity, bool>> expFunc);
        void Add(TEntity entity);
        void Modify(TEntity entity);
        void Delete(TEntity entity);
    }
}
