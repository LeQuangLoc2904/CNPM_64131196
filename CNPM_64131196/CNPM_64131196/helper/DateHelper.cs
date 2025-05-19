using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CNPM_64131196.helper
{
    public class DateHelper
    {
        public static DateTime getNextDateByDayOfWeek(DayOfWeek targetDay)
        {
            DateTime today = DateTime.Today;
            int daysToAdd = ((int)targetDay - (int)today.DayOfWeek + 7) % 7;

            return today.AddDays(daysToAdd);
        }
    }
}