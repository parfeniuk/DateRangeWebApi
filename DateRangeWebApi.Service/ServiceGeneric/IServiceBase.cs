using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ServiceGeneric
{
    public interface IServiceBase<TDTO>
    {
        IQueryable<TDTO> GetAll();
        IQueryable<TDTO> FindBy(Expression<Func<TDTO, bool>> predicate);
        TDTO Add(TDTO dto);
        TDTO Update(TDTO dto);
        TDTO Delete(TDTO dto);
    }
}