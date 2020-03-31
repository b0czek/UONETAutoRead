
using System;
using System.Collections.Generic;
using System.Text;

namespace UONETAutoRead.Utils
{
    static class DateUtils
    {
        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
            return dt.AddDays(-1 * diff).Date;
        }
        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }
        public static List<DateTime> GetWeekDays(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
            {
                Swap(ref startDate, ref endDate);
            }
            List<DateTime> days = new List<DateTime>();
            var ts = endDate - startDate;
            for (int i = 0; i <= ts.TotalDays; i++)
            {
                var cur = startDate.AddDays(i);
                //MessageBox.Show(Convert.ToString(ts.TotalDays));

                if (cur.DayOfWeek != DayOfWeek.Saturday && cur.DayOfWeek != DayOfWeek.Sunday)
                    days.Add(cur);
            }
            return days;
        }
        private static void Swap(ref DateTime startDate, ref DateTime endDate)
        {
            object a = startDate;
            startDate = endDate;
            endDate = (DateTime)a;
        }
    }
}
