using DateRangeWebApi.DataLayer.Entities;
using DateRangeWebApi.Service.DTO;
using EntityMapper;
using ServiceGeneric;
using System;
using System.Collections.Generic;
using System.Text;

namespace DateRangeWebApi.Service.ServiceMapper
{
    public class DateRangeMapper:EntityMapperBase<DateRange, DateRangeDto>, IDateRangeMapper
    {
        public DateRangeMapper():base(cfg=> 
        {
            cfg.CreateMap<DateRange, DateRangeDto>();
            cfg.CreateMap<DateRangeDto,DateRange>();
        })
        { }
    }
}
