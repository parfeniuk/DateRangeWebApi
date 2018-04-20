using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceGeneric
{
    public interface IServiceContextBase:IDisposable
    {
        IServiceBase<TDTO> Set<TEntity,TDTO>()
            where TEntity : class, new()
            where TDTO : class, new();
    }
}
