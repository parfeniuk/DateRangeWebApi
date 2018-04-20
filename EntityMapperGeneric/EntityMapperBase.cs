using System;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using RepositoryGeneric;

namespace EntityMapper
{
    public class EntityMapperBase<TSource,TDestination> : IEntityMapperBase<TSource,TDestination>
        where TSource:EntityBase
        where TDestination:DTOBase
    {
        private IMapper _mapper;
        protected Action<IMapperConfigurationExpression> _cfg;

        public EntityMapperBase(Action<IMapperConfigurationExpression> cfg=null)
        {
            _cfg = cfg;
            _mapper=MapConfigurate().CreateMapper();
        }
        protected virtual MapperConfiguration MapConfigurate()
        {
            if (_cfg == null)
            {
                return new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<TSource, TDestination>();
                    cfg.CreateMap<TDestination, TSource>();
                });
            }
            else
            {
                return new MapperConfiguration(_cfg);
            }
        }

        public TSource Map(TDestination dto)
        {
            return _mapper.Map<TDestination,TSource>(dto);
        }

        public TDestination Map(TSource entity)
        {
            return _mapper.Map<TSource,TDestination>(entity);
        }

        public Expression<Func<TDestination, bool>> MapExpression(Expression<Func<TSource, bool>> predicate)
        {
            var expression = _mapper.Map<Expression<Func<TDestination, bool>>>(predicate);
            return expression;
        }

        public Expression<Func<TSource, bool>> MapExpression(Expression<Func<TDestination, bool>> predicate)
        {
            var expression = _mapper.Map<Expression<Func<TSource, bool>>>(predicate);
            return expression;
        }
    }
}