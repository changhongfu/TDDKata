using System;

namespace Calculator
{
    public abstract class RentalPeriodBase : IRentalPeriod
    {
        private DateTime? _periodStartDate;

        public DateTime? PeriodStartDate
        {
            get { return _periodStartDate; }
            set
            {
                if (value == null)
                {
                    _periodStartDate = value;
                }
                else
                {
                    _periodStartDate = value.Value.AsDateOnly();
                }
            }
        }

        public abstract DateTime CalculateNextPeriodEndDateFrom(DateTime fromDate);
    }
}