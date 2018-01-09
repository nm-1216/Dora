namespace Dora.Infrastructure.Infrastructures.Interfaces
{
    using Dora.Infrastructure.Domains;
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public interface IUnitOfWork : IDisposable
    {
        #region 检索
        IQueryable<TEntity> GetAll<TEntity>() where TEntity : BaseEntity;

        IQueryable<TEntity> Where<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : BaseEntity;

        TEntity Find<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : BaseEntity;

        bool Contains<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : BaseEntity;
        #endregion

        #region 更新
        void BeginTransaction();

        //Task<int> ExecuteSqlCommandAsync(string sql, CancellationToken cancellationToken, params object[] parameters);

        Task<bool> RegisterNew<TEntity>(TEntity entity) where TEntity : class;

        Task<bool> RegisterDirty<TEntity>(TEntity entity) where TEntity : class;

        Task<bool> RegisterClean<TEntity>(TEntity entity) where TEntity : class;

        Task<bool> RegisterDeleted<TEntity>(TEntity entity) where TEntity : class;

        Task<bool> CommitAsync();

        void Rollback();
        #endregion
    }
}
