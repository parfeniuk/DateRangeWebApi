using DateRangeWebApi.DataLayer.Entities;
using DateRangeWebApi.Service.DTO;
using EntityMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace DateRangeWebApi.Service.ServiceMapper
{
    public interface IDateRangeMapper: IEntityMapperBase<DateRange, DateRangeDto>
    {
    }
}
