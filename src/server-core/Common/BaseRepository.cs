using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IdentityNS.Server.Core.Common
{
    internal class BaseRepository<TEntity> : IRepository<TEntity> where
        TEntity : class, new()
    {
        private readonly DbContext _ctx;

        public BaseRepository(DbContext ctx)
        {
            if (ctx == null)
                throw new ArgumentNullException("ctx");

            _ctx = ctx;
        }

        public virtual Task<int> Add(TEntity model)
        {
            var dbSet = _ctx.Set<TEntity>();
            dbSet.Add(model);
            return _ctx.SaveChangesAsync();
        }

        public virtual Task<int> Delete(Expression<Func<TEntity, bool>> where)
        {
            var dbSet = _ctx.Set<TEntity>();
            var matchs = dbSet.AsNoTracking().Where(where).ToList();
            dbSet.RemoveRange(matchs);
            return _ctx.SaveChangesAsync();
        }

        public virtual Task<int> Update(TEntity model)
        {
            _ctx.Entry(model).State = EntityState.Modified;
            return _ctx.SaveChangesAsync();
        }

        public IQueryable<TEntity> AsQueryable()
        {
            return _ctx.Set<TEntity>().AsNoTracking().AsQueryable();
        }

        public static IQueryable<TEntity> PerformInclusions(IQueryable<TEntity> query,
            IEnumerable<Expression<Func<TEntity, object>>> includeProperties)
        {
            return includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

        #region IDisposable implement

        // Flag: Has Dispose already been called? 
        private bool disposed;
        // Instantiate a SafeHandle instance.
        //SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        // Public implementation of Dispose pattern callable by consumers. 
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern. 
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                _ctx.Dispose();
                // Free any other managed objects here. 
                // ...
            }

            // Free any unmanaged objects here. 
            // ...

            disposed = true;
        }

        #endregion
    }
}