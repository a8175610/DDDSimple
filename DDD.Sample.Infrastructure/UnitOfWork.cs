using System.Data.Entity;
using System.Threading.Tasks;
using DDD.Sample.Infrastructure.Interface;

namespace DDD.Sample.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContextTransaction _transaction;
        private readonly IDbContext _dbContext;

        public UnitOfWork(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void BeginTransaction()
        {
            _transaction = _dbContext.Database.BeginTransaction();
        }


        public bool Commit()
        {
            var result = false;
            if (_transaction != null)
            {
                _transaction.Commit();
                result = true;
                _transaction.Dispose();
                _transaction = null;
            }
            else
            {
                result = _dbContext.SaveChanges() > 0;
            }

            return result;
        }

        public async Task<bool> CommitAsync()
        {
            return await Task.Run(() => Commit());
        }

        public void Rollback()
        {
            _transaction?.Rollback();
        }
    }
}
