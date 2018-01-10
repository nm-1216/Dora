namespace Dora.Infrastructure.Services
{
    using Domains;
    using Infrastructures.Interfaces;
    using Interfaces;
    using System;
    using System.Collections.Generic;
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

        #region Add 添加
        async Task<bool> IBaseService<TEntity>.Add(TEntity entity)
        {
            _unitOfWork.Add(entity);
            return await _unitOfWork.CommitAsync();
        }

        async Task<bool> IBaseService<TEntity>.AddRange(IEnumerable<TEntity> entities)
        {
            _unitOfWork.AddRange(entities);
            return await _unitOfWork.CommitAsync();
        }

        async Task<bool> IBaseService<TEntity>.AddAsync(TEntity entity)
        {
            await _unitOfWork.AddAsync(entity);
            return await _unitOfWork.CommitAsync();
        }

        async Task<bool> IBaseService<TEntity>.AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _unitOfWork.AddRangeAsync(entities);
            return await _unitOfWork.CommitAsync();
        }
        #endregion

        #region Remove 删除
        async Task<bool> IBaseService<TEntity>.Remove(TEntity entity)
        {
            _unitOfWork.Remove(entity);
            return await _unitOfWork.CommitAsync();
        }

        async Task<bool> IBaseService<TEntity>.RemoveRange(IEnumerable<TEntity> entities)
        {
            _unitOfWork.RemoveRange(entities);
            return await _unitOfWork.CommitAsync();
        }
        #endregion

        #region Update 更新
        async Task<bool> IBaseService<TEntity>.Update(TEntity entity)
        {
            _unitOfWork.Update(entity);
            return await _unitOfWork.CommitAsync();
        }

        async Task<bool> IBaseService<TEntity>.UpdateRange(IEnumerable<TEntity> entities)
        {
            _unitOfWork.UpdateRange(entities);
            return await _unitOfWork.CommitAsync();
        }
        #endregion

        #endregion

        public void Dispose()
        {
            if (null != _unitOfWork)
                _unitOfWork.Dispose();
        }
    }
}
