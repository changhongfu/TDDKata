using System;

namespace Calculator
{
    public interface IRentalPeriod
    {
        DateTime CalculateNextPeriodEndDateFrom(DateTime fromDate);
    }
}