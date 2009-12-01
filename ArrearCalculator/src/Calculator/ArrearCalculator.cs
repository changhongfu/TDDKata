using System;

namespace Calculator
{
    public class ArrearCalculator
    {
        public bool UseFullPeriod { get; set; }

        public int CalculateDays(TenantEntity tenant)
        {
            DateTime today = Today();

            DateTime fromDate = CalculateFromDate(tenant, today);
            DateTime toDate = CalculateToDate(tenant, today);

            var days =  (toDate - fromDate).Days;

            return days - tenant.CreditedDays;
        }

        private static DateTime CalculateFromDate(TenantEntity tenant, DateTime today)
        {
            return tenant.PaidTo == null ? today : tenant.PaidTo.AsDateOnly();
        }

        private DateTime CalculateToDate(TenantEntity tenant, DateTime today)
        {
            var toDate = UseFullPeriod ? GetPeriodEndDate(tenant, today) : today;

            if (tenant.VacatingBefore(toDate))
            {
                toDate = tenant.VacatingDate.AsDateOnly();
            }

            return toDate;
        }

        private static DateTime GetPeriodEndDate(TenantEntity tenant, DateTime today)
        {
            var rentalPeriod = tenant.GetRentalPeriod();
            return rentalPeriod.CalculateNextPeriodEndDateFrom(today);
        }

        protected virtual DateTime Today()
        {
            return DateTime.Today;
        }
    }
}