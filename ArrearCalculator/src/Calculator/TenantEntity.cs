using System;

namespace Calculator
{
#warning These should come from LINQ2SQL design

    public class TenantEntity
    {
        public bool PaidToLastDay { get; set; }

        public DateTime? PaidTo { get; set; }

        public RentPeriodType PeriodType { get; set; }

        public DateTime? VacatingDate { get; set; }

        public decimal Rent { get; set; }

        public decimal RentPerDay
        {
            get
            {
                if (PeriodType == RentPeriodType.Monthly)
                {
                    return Rent * 12 / 365;
                }
                var numberOfWeeksInPeriod = GetNumberOfWeeksInPeriod(PeriodType);
                return Rent / (7 * numberOfWeeksInPeriod);
            }
        }

        public decimal Credit { get; set; }

        public int CreditedDays
        {
            get 
            {
                return Credit == 0 ? 0 : (int)(Credit / RentPerDay);
            }
        }

        public virtual IRentalPeriod GetRentalPeriod()
        {
            if (PeriodType == RentPeriodType.Monthly)
            {
                return new MonthlyRentalPeriod { PeriodStartDate = PaidTo, PaidToLastDayOfMonth = PaidToLastDay };
            }

            return new WeeklyRentalPeriod(GetNumberOfWeeksInPeriod(PeriodType)) { PeriodStartDate = PaidTo };
        }

        private static int GetNumberOfWeeksInPeriod(RentPeriodType periodType)
        {
            if (periodType == RentPeriodType.Weekly)
            {
                return 1;
            }
            if (periodType == RentPeriodType.Fortnightly)
            {
                return 2;
            }
            if (periodType == RentPeriodType.FourWeekly)
            {
                return 4;
            }
            throw new ArgumentException(string.Format("To GetNumberOfWeeksInPeriod, periodType must be {0}, {1} or {2}", RentPeriodType.Weekly, RentPeriodType.Fortnightly, RentPeriodType.FourWeekly));
        }

        public bool VacatingBefore(DateTime dateTime)
        {
            if (VacatingDate == null)
            {
                return false;
            }
            return VacatingDate.Value.AsDateOnly() < dateTime.AsDateOnly();
        }
    }
}