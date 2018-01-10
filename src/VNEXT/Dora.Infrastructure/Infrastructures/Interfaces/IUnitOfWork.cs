namespace Dora.Infrastructure.Infrastructures.Interfaces
{
    using Dora.Infrastructure.Domains;
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using System;
    using System.Collections.Generic;
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
        #region Attach 附加
        #endregion

        #region Add 添加
        EntityEntry<TEntity> Add<TEntity>(TEntity entity) where TEntity : class;
        void AddRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;
        Task<EntityEntry<TEntity>> AddAsync<TEntity>(TEntity entity) where TEntity : class;
        Task AddRangeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;
        #endregion

        #region Remove 删除
        EntityEntry<TEntity> Remove<TEntity>(TEntity entity) where TEntity : class;
        void RemoveRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;
        #endregion

        #region Update 更新
        EntityEntry<TEntity> Update<TEntity>(TEntity entity) where TEntity : class;
        void UpdateRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;
        #endregion

        Task<bool> CommitAsync();

        void Rollback();
        #endregion
    }
}
