using DateRangeWebApi.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryGeneric
{
    public interface IRepositoryContextBase:IDisposable
    {
        IRepositoryBase<TEntity> Set<TEntity>()
            where TEntity : EntityBase;
    }
}
