using System;

namespace Calculator
{
    public class MonthlyRentalPeriod : RentalPeriodBase
    {
        public bool PaidToLastDayOfMonth { get; set; }

        public override DateTime CalculateNextPeriodEndDateFrom(DateTime fromDate)
        {
            if (PeriodStartDate == null)
            {
                return fromDate;
            }

            if (PaidToLastDayOfMonth)
            {
                return new DateTime(fromDate.Year, fromDate.Month, fromDate.GetLastDayOfMonth());
            }

            int day = PeriodStartDate.Value.Day <= fromDate.GetLastDayOfMonth() ?
                                                                                    PeriodStartDate.Value.Day :
                                                                                                                  fromDate.GetLastDayOfMonth();

            var nextPeriodEndDate = new DateTime(fromDate.Year, fromDate.Month, day);
            bool inSameMonth = PeriodStartDate.Value.Day > fromDate.Day;
            if (!inSameMonth)
            {
                nextPeriodEndDate = nextPeriodEndDate.AddMonths(1);
            }
            return nextPeriodEndDate;
        }
    }
}