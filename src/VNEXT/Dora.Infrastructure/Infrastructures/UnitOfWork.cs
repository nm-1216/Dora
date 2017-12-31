namespace Dora.Infrastructure.Infrastructures
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Storage;

    public class UnitOfWork : IUnitOfWork
    {
        #region private

        private readonly IDbContext _dbContext;
        private IDbContextTransaction _dbTransaction;

        #endregion

        public UnitOfWork(IDbContext dbContext)
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

        #region 更新

        void IUnitOfWork.BeginTransaction()
        {
            _dbTransaction = _dbContext.Database.BeginTransaction();
        }

        //async Task<int> IUnitOfWork.ExecuteSqlCommandAsync(string sql, CancellationToken cancellationToken, params object[] parameters)
        //{
            
        //    return await _dbContext.Database.ExecuteSqlCommandAsync(sql, cancellationToken, parameters);
        //}

        async Task<bool> IUnitOfWork.RegisterNew<TEntity>(TEntity entity)
        {
            try
            {
                _dbContext.Set<TEntity>().Add(entity);

                if (_dbTransaction != null)
                    return await _dbContext.SaveChangesAsync() > 0;
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        async Task<bool> IUnitOfWork.RegisterDirty<TEntity>(TEntity entity)
        {
            try
            {
                _dbContext.Entry<TEntity>(entity).State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            if (_dbTransaction != null)
                return await _dbContext.SaveChangesAsync() > 0;
            return true;
        }

        async Task<bool> IUnitOfWork.RegisterClean<TEntity>(TEntity entity)
        {
            _dbContext.Entry<TEntity>(entity).State = EntityState.Unchanged;

            if (_dbTransaction != null)
                return await _dbContext.SaveChangesAsync() > 0;
            return true;
        }

        async Task<bool> IUnitOfWork.RegisterDeleted<TEntity>(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);

            if (_dbTransaction != null)
                return await _dbContext.SaveChangesAsync() > 0;
            return true;
        }

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
