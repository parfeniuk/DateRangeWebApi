using DateRangeWebApi.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace RepositoryGeneric
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity>
        where TEntity : EntityBase
    {
        private DbContext _context;
        private DbSet<TEntity> _set;

        public RepositoryBase(DbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _set=_context.Set<TEntity>()?? throw new ArgumentNullException(nameof(_set));
        }

        public IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            return _set.Where(predicate);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _set;
        }

        public TEntity Add(TEntity entity)
        {
            if (entity == null) return null;
            _set.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public TEntity Delete(TEntity entity)
        {
            if (entity == null) return null;
            _set.Remove(entity);
            _context.SaveChanges();
            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            if (entity == null) return null;
            _context.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
