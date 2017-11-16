namespace Dora.Infrastructure.Repositorys
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using Domains;
    using Infrastructures.Interfaces;
    using Interfaces;

    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        public readonly IQueryable<TEntity> _entities;
        public readonly IDbContext _dbContext;

        public BaseRepository(IDbContext dbContext)
        {
            if (null == dbContext)
            {
                throw new ArgumentNullException("dbContext", "dbContext must be even");
            }
            _entities = dbContext.Set<TEntity>();
            _dbContext = dbContext;
        }

        public bool Contains(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.Count(predicate) > 0;
        }

        public TEntity Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.FirstOrDefault(predicate);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _entities;
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.Where(predicate);
        }

        public void Dispose()
        {
            if (null != _dbContext)
                _dbContext.Dispose();
        }

    }
}
