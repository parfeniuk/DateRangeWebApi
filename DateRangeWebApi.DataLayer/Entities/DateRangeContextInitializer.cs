using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateRangeWebApi.DataLayer.Entities
{
    public static class DateRangeContextInitializer
    {
        public static void Initialize(DateRangeContext context)
        {
            context.Database.Migrate();
            // Seed initial data
            if (context.DateRanges.Any())
            {
                return;
            }
            else
            {
                List<DateRange> seedList = new List<DateRange>
                {
                    new DateRange
                    {
                        DateStart=DateTime.Parse("2018.04.01"),
                        DateEnd=DateTime.Parse("2018.04.05"),
                    },
                    new DateRange
                    {
                        DateStart=DateTime.Parse("2018.04.01"),
                        DateEnd=DateTime.Parse("2018.04.12"),
                    },
                    new DateRange
                    {
                        DateStart=DateTime.Parse("2018.04.03"),
                        DateEnd=DateTime.Parse("2018.04.05"),
                    },
                    new DateRange
                    {
                        DateStart=DateTime.Parse("2018.04.01"),
                        DateEnd=DateTime.Parse("2018.04.02"),
                    },
                    new DateRange
                    {
                        DateStart=DateTime.Parse("2018.04.05"),
                        DateEnd=DateTime.Parse("2018.04.10"),
                    }
                };
                context.DateRanges.AddRange(seedList);
                context.SaveChanges();
            }
        }
    }
}
