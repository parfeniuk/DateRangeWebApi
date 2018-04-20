using DateRangeWebApi.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryGeneric
{
    public class RepositoryContextBase : IRepositoryContextBase
    {
        private DbContext _context;
        public RepositoryContextBase(DbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IRepositoryBase<TEntity> Set<TEntity>() where TEntity : EntityBase
        {
            return new RepositoryBase<TEntity>(_context);
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing) _context.Dispose();
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
