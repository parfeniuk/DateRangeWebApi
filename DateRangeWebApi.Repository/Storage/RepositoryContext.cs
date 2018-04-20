using DateRangeWebApi.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using RepositoryGeneric;
using System;
using System.Collections.Generic;
using System.Text;

namespace DateRangeWebApi.Repository.Storage
{
    public class RepositoryContext:RepositoryContextBase
    {
        private IRepositoryBase<DateRange> dateRange;

        public RepositoryContext(DbContext context):base(context)
        {
        }

        public IRepositoryBase<DateRange> DateRange
        {
            get
            {
                return dateRange!=null ? dateRange: dateRange =Set<DateRange>();
            }
        }

    }
}
