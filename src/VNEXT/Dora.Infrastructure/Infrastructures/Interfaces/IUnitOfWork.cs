namespace Dora.Infrastructure.Infrastructures.Interfaces
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IUnitOfWork : IDisposable
    {
        #region 更新
        void BeginTransaction();

        Task<int> ExecuteSqlCommandAsync(string sql, CancellationToken cancellationToken, params object[] parameters);

        Task<bool> RegisterNew<TEntity>(TEntity entity) where TEntity : class;

        Task<bool> RegisterDirty<TEntity>(TEntity entity) where TEntity : class;

        Task<bool> RegisterClean<TEntity>(TEntity entity) where TEntity : class;

        Task<bool> RegisterDeleted<TEntity>(TEntity entity) where TEntity : class;

        Task<bool> CommitAsync();

        void Rollback();
        #endregion
    }
}
