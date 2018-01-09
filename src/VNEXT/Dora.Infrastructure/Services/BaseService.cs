namespace Dora.Infrastructure.Services
{
    using Domains;
    using Infrastructures.Interfaces;
    using Interfaces;
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public abstract class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
    {
        protected IUnitOfWork _unitOfWork { get; private set; }

        public BaseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #region 查询
        bool IBaseService<TEntity>.Contains(Expression<Func<TEntity, bool>> predicate)
        {
            return _unitOfWork.Contains<TEntity>(predicate);
        }

        TEntity IBaseService<TEntity>.Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _unitOfWork.Find<TEntity>(predicate);
        }

        IQueryable<TEntity> IBaseService<TEntity>.GetAll()
        {
            return _unitOfWork.GetAll<TEntity>();
        }

        IQueryable<TEntity> IBaseService<TEntity>.Where(Expression<Func<TEntity, bool>> predicate)
        {
            return _unitOfWork.Where<TEntity>(predicate);
        }
        #endregion

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
