using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeLog
{
    public static class TimeHelper
    {
        public static string Timespan2String(TimeSpan time)
        {
            return time.Hours.ToString("00") + ":" + time.Minutes.ToString("00") + ":" + time.Seconds.ToString("00");
        }

        public static TimeSpan String2Timespan(string time)
        {
            int hours = int.Parse(time.Substring(0, 2));
            int minutes = int.Parse(time.Substring(3, 2));
            int seconds = int.Parse(time.Substring(6, 2));
            TimeSpan timespan = new TimeSpan(hours, minutes, seconds);
            return timespan;
        }

        public static DateTime Null()
        {
            // Minvalue of SQL Server Ce 4.0
            return new DateTime(1753, 1, 1);
        }
    }
}
