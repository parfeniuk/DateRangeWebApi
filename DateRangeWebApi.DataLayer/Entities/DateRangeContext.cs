using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DateRangeWebApi.DataLayer.Entities
{
    public class DateRangeContext:DbContext
    {
        public DateRangeContext(DbContextOptions<DateRangeContext> options):base(options)
        {
        }
        public virtual DbSet<DateRange> DateRanges { get; set; }
    }
}
