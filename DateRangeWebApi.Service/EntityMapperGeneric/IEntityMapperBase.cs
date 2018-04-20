using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace EntityMapper
{
    public interface IEntityMapperBase<TSource,TDestination>
    {
        TDestination Map(TSource entity);
        TSource Map(TDestination dto);
    }
}