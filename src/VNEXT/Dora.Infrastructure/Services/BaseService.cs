namespace Dora.Infrastructure.Services
{
    using System.Threading.Tasks;
    using Domains;
    using Infrastructures.Interfaces;
    using Interfaces;

    public abstract class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
    {
        protected IUnitOfWork _unitOfWork { get; private set; }

        public BaseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #region 更新
        async Task<bool> IBaseService<TEntity>.Add(TEntity entity)
        {
            await _unitOfWork.RegisterNew(entity);
            return await _unitOfWork.CommitAsync();
        }

        async Task<bool> IBaseService<TEntity>.Update(TEntity entity)
        {
            await _unitOfWork.RegisterDirty(entity);
            return await _unitOfWork.CommitAsync();
        }

        async Task<bool> IBaseService<TEntity>.Delete(TEntity entity)
        {
            await _unitOfWork.RegisterDeleted(entity);
            return await _unitOfWork.CommitAsync();
        }
        #endregion

        public void Dispose()
        {
            if (null != _unitOfWork)
                _unitOfWork.Dispose();
        }
    }
}
