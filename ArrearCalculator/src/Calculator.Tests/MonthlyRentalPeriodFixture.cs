using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Tests
{
    [TestClass]
    public class MonthlyRentalPeriodFixture
    {
        [TestMethod]
        public void TestCalculateNextPeriodEndDateFrom_ReturnFromDate_IfStartDateIsNUll()
        {
            RunTest(new TestData { PeriodStartDate = null, FromDate = new DateTime(2009, 12, 1), ExpectedEndDate = new DateTime(2009, 12, 1) });
        }

        [TestMethod]
        public void TestCalculateNextPeriodEndDateFrom()
        {
            RunTest(new TestData { PeriodStartDate = new DateTime(2009, 11, 15), FromDate = new DateTime(2009, 12, 1), ExpectedEndDate = new DateTime(2009, 12, 15) });
        }

        [TestMethod]
        public void TestCalculateNextPeriodEndDateFrom2()
        {
            RunTest(new TestData { PeriodStartDate = new DateTime(2009, 10, 31), FromDate = new DateTime(2009, 11, 15), ExpectedEndDate = new DateTime(2009, 11, 30) });
        }

        [TestMethod]
        public void TestCalculateNextPeriodEndDateFrom3()
        {
            RunTest(new TestData { PeriodStartDate = new DateTime(2009, 10, 20), FromDate = new DateTime(2009, 11, 21), ExpectedEndDate = new DateTime(2009, 12, 20) });
        }

        [TestMethod]
        public void TestCalculateNextPeriodEndDateFrom4()
        {
            RunTest(new TestData { PeriodStartDate = new DateTime(2009, 2, 27), FromDate = new DateTime(2009, 3, 28), ExpectedEndDate = new DateTime(2009, 4, 27) });
        }

        [TestMethod]
        public void TestCalculateNextPeriodEndDateFrom5()
        {
            RunTest(new TestData { PeriodStartDate = new DateTime(2009, 1, 30), FromDate = new DateTime(2009, 2, 15), ExpectedEndDate = new DateTime(2009, 2, 28) });
        }

        [TestMethod]
        public void TestCalculateNextPeriodEndDateFrom6()
        {
            RunTest(new TestData { PeriodStartDate = new DateTime(2009, 11, 30), PaidToLastDayOfMonth = true, FromDate = new DateTime(2009, 12, 1), ExpectedEndDate = new DateTime(2009, 12, 31) });
        }

        private static void RunTest(TestData testData)
        {
            var period = new MonthlyRentalPeriod { PeriodStartDate = testData.PeriodStartDate, PaidToLastDayOfMonth = testData.PaidToLastDayOfMonth };

            DateTime periodEndDate = period.CalculateNextPeriodEndDateFrom(testData.FromDate);

            Assert.AreEqual(testData.ExpectedEndDate, periodEndDate);
        }

        private class TestData
        {
            public DateTime? PeriodStartDate { get; set; }
            public DateTime FromDate { get; set; }
            public DateTime ExpectedEndDate { get; set; }
            public bool PaidToLastDayOfMonth { get; set; }
        }
    }
}