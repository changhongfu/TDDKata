using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Tests
{
    [TestClass]
    public class TenantEntityFixture
    {
        [TestMethod]
        public void TestGetRentalPeriod_ReturnMonthlyPeriod_IfPeriodTypeIsMonthly()
        {
            var tenant = new TenantEntity { PeriodType = RentPeriodType.Monthly, PaidTo = new DateTime(2009, 12, 1) };
            var rentalPeriod = tenant.GetRentalPeriod() as MonthlyRentalPeriod;
            Assert.IsNotNull(rentalPeriod);
            Assert.AreEqual(new DateTime(2009, 12, 1), rentalPeriod.PeriodStartDate);
        }

        [TestMethod]
        public void TestGetRentalPeriod_ReturnMonthlyPeriod_PaidToLastDay()
        {
            var tenant = new TenantEntity { PeriodType = RentPeriodType.Monthly, PaidTo = new DateTime(2009, 12, 1), PaidToLastDay = true };
            var rentalPeriod = tenant.GetRentalPeriod() as MonthlyRentalPeriod;
            Assert.IsTrue(rentalPeriod.PaidToLastDayOfMonth);
        }

        [TestMethod]
        public void TestGetRentalPeriod_Return1WeeklyPeriod_IfPeriodTypeIsWeekly()
        {
            var tenant = new TenantEntity { PeriodType = RentPeriodType.Weekly, PaidTo = new DateTime(2009, 12, 1) };
            var rentalPeriod = tenant.GetRentalPeriod() as WeeklyRentalPeriod;
            Assert.IsNotNull(rentalPeriod);
            Assert.AreEqual(new DateTime(2009, 12, 1), rentalPeriod.PeriodStartDate);
            Assert.AreEqual(1, rentalPeriod.NumberOfWeeksInPeriod);
        }

        [TestMethod]
        public void TestGetRentalPeriod_Return2WeeklyPeriod_IfPeriodTypeIsFortnightly()
        {
            var tenant = new TenantEntity { PeriodType = RentPeriodType.Fortnightly, PaidTo = new DateTime(2009, 12, 1) };
            var rentalPeriod = tenant.GetRentalPeriod() as WeeklyRentalPeriod;
            Assert.IsNotNull(rentalPeriod);
            Assert.AreEqual(new DateTime(2009, 12, 1), rentalPeriod.PeriodStartDate);
            Assert.AreEqual(2, rentalPeriod.NumberOfWeeksInPeriod);
        }

        [TestMethod]
        public void TestGetRentalPeriod_Return4WeeklyPeriod_IfPeriodTypeIsFourWeekly()
        {
            var tenant = new TenantEntity { PeriodType = RentPeriodType.FourWeekly, PaidTo = new DateTime(2009, 12, 1) };
            var rentalPeriod = tenant.GetRentalPeriod() as WeeklyRentalPeriod;
            Assert.IsNotNull(rentalPeriod);
            Assert.AreEqual(new DateTime(2009, 12, 1), rentalPeriod.PeriodStartDate);
            Assert.AreEqual(4, rentalPeriod.NumberOfWeeksInPeriod);
        }

        [TestMethod]
        public void TestVacatingBefore_ReturnFalse_IfVacatingDateIsNull()
        {
            var tenant = new TenantEntity { VacatingDate = null };

            bool result = tenant.VacatingBefore(new DateTime(2000, 1, 1));

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestVacatingBefore_ReturnTrue_IfVacatingDateLessThanGivenDate()
        {
            var tenant = new TenantEntity { VacatingDate = new DateTime(2000, 1, 1) };

            bool result = tenant.VacatingBefore(new DateTime(2000, 1, 2));

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestVacatingBefore_ReturnFalse_IfVacatingDateLessThanGivenDate()
        {
            var tenant = new TenantEntity { VacatingDate = new DateTime(2000, 1, 1) };

            bool result = tenant.VacatingBefore(new DateTime(1999, 12, 31));

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestVacatingBefore_ReturnFalse_IfVacatingDateEqualsToGivenDate()
        {
            var tenant = new TenantEntity { VacatingDate = new DateTime(2000, 1, 1) };

            bool result = tenant.VacatingBefore(new DateTime(2000, 1, 1));

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestVacatingBefore_ShouldIgnoreTime()
        {
            var tenant = new TenantEntity { VacatingDate = new DateTime(2000, 1, 1, 1, 0, 0) };

            bool result = tenant.VacatingBefore(new DateTime(2000, 1, 1, 12, 0, 0));

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestRentPerDay_Weekly_RentDivideBy7()
        {
            var tenant = new TenantEntity { PeriodType = RentPeriodType.Weekly, Rent = 100 };

            var rentPerDay = tenant.RentPerDay;

            Assert.AreEqual((decimal)100 / 7, rentPerDay);
        }

        [TestMethod]
        public void TestRentPerDay_Fortnightly_RentDivideBy14()
        {
            var tenant = new TenantEntity { PeriodType = RentPeriodType.Fortnightly, Rent = 100 };

            var rentPerDay = tenant.RentPerDay;

            Assert.AreEqual((decimal)100 / 14, rentPerDay);
        }

        [TestMethod]
        public void TestRentPerDay_FourWeekly_RentDivideBy28()
        {
            var tenant = new TenantEntity { PeriodType = RentPeriodType.FourWeekly, Rent = 100 };

            var rentPerDay = tenant.RentPerDay;

            Assert.AreEqual((decimal)100 / 28, rentPerDay);
        }

        [TestMethod]
        public void TestRentPerDay_Monthly_12MonthRentDivideBy365()
        {
            var tenant = new TenantEntity { PeriodType = RentPeriodType.Monthly, Rent = 100 };

            var rentPerDay = tenant.RentPerDay;

            Assert.AreEqual((decimal)100 * 12 / 365 , rentPerDay);
        }

        [TestMethod]
        public void TestCreditedDays_Return0_IfCreditIs0()
        {
            var tenant = new TenantEntity { Credit = 0 };
            Assert.AreEqual(0, tenant.CreditedDays);
        }

        [TestMethod]
        public void TestCreditedDays_ReturnCreditDividByRentPerDay()
        {
            var tenant = new TenantEntity { Credit = 3, PeriodType = RentPeriodType.Weekly, Rent = 7 };
            Assert.AreEqual(3, tenant.CreditedDays);
        }
    }
}