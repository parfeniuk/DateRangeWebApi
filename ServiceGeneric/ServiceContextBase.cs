using EntityMapper;
using RepositoryGeneric;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceGeneric
{
    public class ServiceContextBase : IServiceContextBase
    {
        protected IRepositoryContextBase _repositoryContext;
        protected IEntityMapperContextBase _entityMapperContext;

        public ServiceContextBase(IRepositoryContextBase repositoryContext, IEntityMapperContextBase entityMapperContext)
        {
            _repositoryContext = repositoryContext;
            _entityMapperContext = entityMapperContext;
        }

        public IServiceBase<TDTO> Set<TEntity, TDTO>()
            where TEntity : class, new()
            where TDTO : class, new()
        {
            return new ServiceBase<TEntity,TDTO>(_repositoryContext,
                _entityMapperContext.Set<TEntity, TDTO>());
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing) _repositoryContext.Dispose();
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
