using System;

namespace Calculator
{
    public static class DateTimeExtensions
    {
        public static DateTime AsDateOnly(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day);
        }

        public static DateTime AsDateOnly(this DateTime? dateTime)
        {
            if (dateTime == null)
            {
                throw new ArgumentNullException("datetime", "To use AsDateOnly, dateTime cannot be null");
            }
            return new DateTime(dateTime.Value.Year, dateTime.Value.Month, dateTime.Value.Day);
        }

        public static int GetLastDayOfMonth(this DateTime dateTime)
        {
            dateTime = dateTime.AddMonths(1);
            dateTime = dateTime.AddDays(-dateTime.Day);
            return dateTime.Day;
        }
    }
}