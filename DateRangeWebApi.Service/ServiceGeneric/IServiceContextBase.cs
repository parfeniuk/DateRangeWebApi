using DateRangeWebApi.DataLayer.Entities;
using DateRangeWebApi.Service.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceGeneric
{
    public interface IServiceContextBase:IDisposable
    {
        IServiceBase<TDTO> Set<TEntity,TDTO>()
            where TEntity : EntityBase
            where TDTO : DTOBase;
    }
}
