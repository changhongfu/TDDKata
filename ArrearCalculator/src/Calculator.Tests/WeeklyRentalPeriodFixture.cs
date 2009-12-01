using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Tests
{
    [TestClass]
    public class WeeklyRentalPeriodFixture
    {
        [TestMethod]
        public void TestCalculateNextPeriodEndDateFrom_ReturnFromDate_IfStartDateIsNUll()
        {
            var period = new WeeklyRentalPeriod(1) { PeriodStartDate = null };

            DateTime periodEndDate = period.CalculateNextPeriodEndDateFrom(new DateTime(2009, 12, 1));

            Assert.AreEqual(new DateTime(2009, 12, 1), periodEndDate);
        }

        [TestMethod]
        public void TestCalculateNextPeriodEndDateFrom_1WeekPeriod()
        {
            var period = new WeeklyRentalPeriod(1) { PeriodStartDate = new DateTime(2009, 11, 30) };

            DateTime periodEndDate = period.CalculateNextPeriodEndDateFrom(new DateTime(2009, 12, 1));

            Assert.AreEqual(new DateTime(2009, 12, 7), periodEndDate);
        }

        [TestMethod]
        public void TestCalculateNextPeriodEndDateFrom_2WeekPeriod()
        {
            var period = new WeeklyRentalPeriod(2) { PeriodStartDate = new DateTime(2009, 11, 30) };

            DateTime periodEndDate = period.CalculateNextPeriodEndDateFrom(new DateTime(2009, 12, 1));

            Assert.AreEqual(new DateTime(2009, 12, 14), periodEndDate);
        }

        [TestMethod]
        public void TestCalculateNextPeriodEndDateFrom_4WeekPeriod()
        {
            var period = new WeeklyRentalPeriod(4) { PeriodStartDate = new DateTime(2009, 11, 30) };

            DateTime periodEndDate = period.CalculateNextPeriodEndDateFrom(new DateTime(2009, 12, 1));

            Assert.AreEqual(new DateTime(2009, 12, 28), periodEndDate);
        }

        [TestMethod]
        public void TestCalculateNextPeriodEndDateFrom_ReturnFromDate_IfFromDateIsPeriodEnd()
        {
            var period = new WeeklyRentalPeriod(1) { PeriodStartDate = new DateTime(2009, 11, 30) };

            DateTime periodEndDate = period.CalculateNextPeriodEndDateFrom(new DateTime(2009, 12, 7));

            Assert.AreEqual(new DateTime(2009, 12, 7), periodEndDate);
        }
    }
}