using System;

namespace RSI
{
    public static class Extension
    {
        public static DateTime StartOfWeek(this DateTime dt, int startOfWeek)
        {
            int diff = (7 + (dt.DayOfWeek - (DayOfWeek)startOfWeek)) % 7;
            return dt.AddDays(-1 * diff).Date;
        }
    }
}