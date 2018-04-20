using DateRangeWebApi.DataLayer.Entities;
using DateRangeWebApi.Service.DTO;
using DateRangeWebApi.Service.ServiceMapper;
using EntityMapper;
using RepositoryGeneric;
using ServiceGeneric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DateRangeWebApi.Service.ServiceStorage
{
    public class DateRangeService : ServiceBase<DateRange, DateRangeDto>, IDateRangeService
    {
        public DateRangeService(IRepositoryContextBase repositoryContext,
            IDateRangeMapper entityMapper):base(repositoryContext,entityMapper)
        {
        }
    }
}
