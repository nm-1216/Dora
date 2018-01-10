namespace Dora.Infrastructure.Infrastructures
{
    using Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using Microsoft.EntityFrameworkCore.Storage;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public class UnitOfWork : IUnitOfWork
    {
        #region private

        private readonly DbContext _dbContext;
        private IDbContextTransaction _dbTransaction;

        #endregion

        public UnitOfWork(DbContext dbContext)
        {
            if (null == dbContext)
            {
                throw new ArgumentNullException("dbContext", "dbContext must be even");
            }
            else
            {
                _dbContext = dbContext;
            }
        }

        #region 检索

        IQueryable<TEntity> IUnitOfWork.GetAll<TEntity>()
        {
            return _dbContext.Set<TEntity>();
        }

        IQueryable<TEntity> IUnitOfWork.Where<TEntity>(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().Where(predicate);
        }

        TEntity IUnitOfWork.Find<TEntity>(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().FirstOrDefault(predicate);
        }

        bool IUnitOfWork.Contains<TEntity>(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().Count(predicate) > 0;
        }

        #endregion

        #region 更新

        void IUnitOfWork.BeginTransaction()
        {
            _dbTransaction = _dbContext.Database.BeginTransaction();
        }

        //async Task<int> IUnitOfWork.ExecuteSqlCommandAsync(string sql, CancellationToken cancellationToken, params object[] parameters)
        //{
        //    return await _dbContext.Database.ExecuteSqlCommandAsync(sql, cancellationToken, parameters);
        //}

        #region Add
        EntityEntry<TEntity> IUnitOfWork.Add<TEntity>(TEntity entity)
        {
            try
            {
                return _dbContext.Set<TEntity>().Add(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        void IUnitOfWork.AddRange<TEntity>(IEnumerable<TEntity> entities)
        {
            try
            {
                _dbContext.Set<TEntity>().AddRange(entities);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        async Task<EntityEntry<TEntity>> IUnitOfWork.AddAsync<TEntity>(TEntity entity)
        {
            try
            {
                return await _dbContext.Set<TEntity>().AddAsync(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        async Task IUnitOfWork.AddRangeAsync<TEntity>(IEnumerable<TEntity> entities)
        {
            try
            {
                await _dbContext.Set<TEntity>().AddRangeAsync(entities);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Remove 删除
        EntityEntry<TEntity> IUnitOfWork.Remove<TEntity>(TEntity entity)
        {
            try
            {
                return _dbContext.Set<TEntity>().Remove(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        void IUnitOfWork.RemoveRange<TEntity>(IEnumerable<TEntity> entities)
        {
            try
            {
                _dbContext.Set<TEntity>().RemoveRange(entities);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Update 更新
        EntityEntry<TEntity> IUnitOfWork.Update<TEntity>(TEntity entity)
        {
            try
            {
                return _dbContext.Set<TEntity>().Update(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        void IUnitOfWork.UpdateRange<TEntity>(IEnumerable<TEntity> entities)
        {
            try
            {
                _dbContext.Set<TEntity>().UpdateRange(entities);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        async Task<bool> IUnitOfWork.CommitAsync()
        {
            try
            {
                if (_dbTransaction == null)
                    return await _dbContext.SaveChangesAsync() > 0;
                else
                    _dbTransaction.Commit();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        void IUnitOfWork.Rollback()
        {
            if (_dbTransaction != null)
                _dbTransaction.Rollback();
        }

        void IDisposable.Dispose()
        {
            if (null != _dbContext)
                _dbContext.Dispose();

            if (null != _dbTransaction)
                _dbTransaction.Dispose();
        }

        #endregion

    }
}
