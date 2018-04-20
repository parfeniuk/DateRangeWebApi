using EntityMapper;
using RepositoryGeneric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ServiceGeneric
{
    public class ServiceBase<TEntity,TDTO> : IServiceBase<TDTO>
        where TEntity : class, new()
        where TDTO : DTOBase
    {
        protected IRepositoryBase<TEntity> _repository;
        protected IEntityMapperBase<TEntity,TDTO> _entityMapper;

        public ServiceBase(IRepositoryContextBase repositoryContext, IEntityMapperBase<TEntity, TDTO> entityMapper)
        {
            _repository = repositoryContext.Set<TEntity>();
            _entityMapper = entityMapper;
        }

        public TDTO Add(TDTO dto)
        {
            if (dto == null) return null;
            var entity= _repository.Add(_entityMapper.Map(dto));
            //dto.Id=entity.
            return dto;
        }

        public TDTO Delete(TDTO dto)
        {
            if (dto == null) return null;
            _repository.Delete(_entityMapper.Map(dto));
            return dto;
        }

        public IQueryable<TDTO> FindBy(Expression<Func<TDTO, bool>> predicate)
        {
            return _repository.FindBy(_entityMapper.MapExpression(predicate)).Select(entity => _entityMapper.Map(entity));
        }

        public IQueryable<TDTO> GetAll()
        {
            return _repository.GetAll().Select(entity=>_entityMapper.Map(entity));
        }

        public TDTO Update(TDTO dto)
        {
            if (dto == null) return null;
            _repository.Update(_entityMapper.Map(dto));
            return dto;
        }
    }
}
