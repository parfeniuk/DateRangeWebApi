using RepositoryGeneric;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace EntityMapper
{
    public interface IEntityMapperBase<TSource,TDestination>
        where TSource : EntityBase
        where TDestination : DTOBase
    {
        TDestination Map(TSource entity);
        TSource Map(TDestination dto);
        Expression<Func<TDestination, bool>> MapExpression(Expression<Func<TSource, bool>> predicate);
        Expression<Func<TSource, bool>> MapExpression(Expression<Func<TDestination, bool>> predicate);
    }
}