using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace Calculator.Tests
{
    [TestClass]
    public class ArrearCalculatorFixture
    {
        private static readonly DateTime CalculationDate = new DateTime(2009, 12, 1); 

        [TestMethod]
        public void NotUseFullPeriod_TenantHasNoPaidTo_Return0()
        {
            var calculator = new MyArrearCalculator { UseFullPeriod = false };
            var tenant = new TenantEntity { PaidTo = null };

            int days = calculator.CalculateDays(tenant);

            Assert.AreEqual(0, days);
        }

        [TestMethod]
        public void NotUseFullPeriod_TenantHasPaidTo_ReturnTodayMinusPaidTo()
        {
            var calculator = new MyArrearCalculator { CalculatingDate = CalculationDate, UseFullPeriod = false };
            var tenant = new TenantEntity { PaidTo = new DateTime(2009, 11, 30) };

            int days = calculator.CalculateDays(tenant);

            Assert.AreEqual(1, days);
        }

        [TestMethod]
        public void ShouldIgnoreTimePartOfPaidToDate()
        {
            var calculator = new MyArrearCalculator { CalculatingDate = CalculationDate, UseFullPeriod = false };
            var tenant = new TenantEntity { PaidTo = new DateTime(2009, 11, 30, 23, 59, 59) };

            int days = calculator.CalculateDays(tenant);

            Assert.AreEqual(1, days);
        }

        [TestMethod]
        public void UseFullPeriod_ShouldReturnPeriodEndDateMinusPaidTo()
        {
            var tenant = MockRepository.GenerateStub<TenantEntity>();
            var period = MockRepository.GenerateStub<IRentalPeriod>();

            tenant.PaidTo = new DateTime(2009, 11, 30);
            tenant.Stub(t => t.GetRentalPeriod()).Return(period);
            
            period.Stub(p => p.CalculateNextPeriodEndDateFrom(CalculationDate)).Return(new DateTime(2009, 12, 2));

            var calculator = new MyArrearCalculator { CalculatingDate = CalculationDate, UseFullPeriod = true };

            int days = calculator.CalculateDays(tenant);

            Assert.AreEqual(2, days);
        }

        [TestMethod]
        public void HasVacatingDate_ShouldUseVacatingDate_IfVacatingDateIsLessThanCalculationDate()
        {
            var calculator = new MyArrearCalculator { CalculatingDate = CalculationDate, UseFullPeriod = false };
            var tenant = new TenantEntity { PaidTo = new DateTime(2009, 11, 29), VacatingDate = new DateTime(2009, 11, 30) };

            int days = calculator.CalculateDays(tenant);

            Assert.AreEqual(1, days);
        }

        [TestMethod]
        public void CreditPaid_ShouldTakeAwayDaysCoveredByCreditPaid()
        {
            var calculator = new MyArrearCalculator { CalculatingDate = CalculationDate, UseFullPeriod = false };
            var tenant = new TenantEntity { PaidTo = new DateTime(2009, 11, 29), PeriodType = RentPeriodType.Weekly, Credit = 1, Rent = 7 };

            int days = calculator.CalculateDays(tenant);

            Assert.AreEqual(1, days);   //2 days from 2009-11-29 to 2009-12-1, 1 day covered by credit, 
        }

        private class MyArrearCalculator : ArrearCalculator
        {
            public MyArrearCalculator()
            {
                CalculatingDate = new DateTime(2009, 12, 1);
            }

            public DateTime CalculatingDate { get; set; }

            protected override DateTime Today()
            {
                return CalculatingDate;
            }
        }
    }
}