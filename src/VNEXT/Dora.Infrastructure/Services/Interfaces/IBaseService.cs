namespace Dora.Infrastructure.Services.Interfaces
{
    using Domains;
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    /// <summary>
    /// 基础服务 用于更新检索数据
    /// </summary>
    /// <typeparam name="TEntity">模型</typeparam>
    public interface IBaseService<TEntity> : IDisposable where TEntity : BaseEntity
    {
        #region 检索
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
        TEntity Find(Expression<Func<TEntity, bool>> predicate);
        bool Contains(Expression<Func<TEntity, bool>> predicate);
        #endregion

        #region 更新
        Task<bool> Add(TEntity entity);
        Task<bool> Update(TEntity entity);
        Task<bool> Delete(TEntity entity);
        #endregion
    }
}
