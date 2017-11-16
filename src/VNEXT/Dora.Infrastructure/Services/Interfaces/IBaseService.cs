namespace Dora.Infrastructure.Services.Interfaces
{
    using System;
    using System.Threading.Tasks;
    using Domains;

    /// <summary>
    /// 基础服务 用于更新检索数据
    /// </summary>
    /// <typeparam name="TEntity">模型</typeparam>
    public interface IBaseService<TEntity> : IDisposable where TEntity : BaseEntity
    {
        #region 更新
        Task<bool> Add(TEntity entity);
        Task<bool> Update(TEntity entity);
        Task<bool> Delete(TEntity entity);
        #endregion
    }
}
