using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityMapper
{
    public interface IEntityMapperContextBase
    {
        IEntityMapperBase<TSource, TDestination> Set<TSource, TDestination>(Action<IMapperConfigurationExpression> cfg=null)
            where TSource : class, new()
            where TDestination : class, new();
    }
}
