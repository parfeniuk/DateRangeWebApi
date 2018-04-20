using DateRangeWebApi.Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DateRangeWebApi.Helpers
{
    public static class DateRangeExtentions
    {
         public static bool IsIntersectedRange(this DateRangeDto range, DateRangeDto other)
        {
            return range.DateStart <= other.DateEnd && range.DateEnd >= other.DateStart;
        }

        public static bool IsValidRange(this DateRangeDto range)
        {
            return range.DateStart < range.DateEnd;
        }
    }
}
