using AutoMapper;
using DateRangeWebApi.DataLayer.Entities;
using DateRangeWebApi.Service.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityMapper
{
    public interface IEntityMapperContextBase
    {
        IEntityMapperBase<TSource, TDestination> Set<TSource, TDestination>(Action<IMapperConfigurationExpression> cfg=null)
            where TSource : EntityBase
            where TDestination : DTOBase;
    }
}
