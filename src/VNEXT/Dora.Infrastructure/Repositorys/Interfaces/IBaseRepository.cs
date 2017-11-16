namespace Dora.Infrastructure.Repositorys.Interfaces
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using Domains;

    public interface IBaseRepository<TEntity> : IDisposable where TEntity : BaseEntity
    {
        #region 检索
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
        TEntity Find(Expression<Func<TEntity, bool>> predicate);
        bool Contains(Expression<Func<TEntity, bool>> predicate);
        #endregion
    }
}
