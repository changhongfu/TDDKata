using System;

namespace Calculator
{
    public class WeeklyRentalPeriod : RentalPeriodBase
    {
        public WeeklyRentalPeriod(int numberOfWeeks)
        {
            NumberOfWeeksInPeriod = numberOfWeeks;
        }

        public int NumberOfWeeksInPeriod { get; private set; }

        public override DateTime CalculateNextPeriodEndDateFrom(DateTime fromDate)
        {
            if (PeriodStartDate == null)
            {
                return fromDate;
            }

            var totalDays = (fromDate - PeriodStartDate.Value).Days;

            int fullPeriodDays = NumberOfWeeksInPeriod * 7;
            int daysNotInFullPeriod = totalDays % fullPeriodDays;
            int daysToMakeFullPeriod = daysNotInFullPeriod == 0 ? 0 : fullPeriodDays - daysNotInFullPeriod;
            return fromDate.AddDays(daysToMakeFullPeriod);
        }
    }
}