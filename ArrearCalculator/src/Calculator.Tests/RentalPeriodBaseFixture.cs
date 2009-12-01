using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Tests
{
    [TestClass]
    public class RentalPeriodBaseFixture
    {
        [TestMethod]
        public void TestPeriodStartDate_CanAssignNull()
        {
            var period = new MyRentalPeriod { PeriodStartDate = null };
            Assert.IsNull(period.PeriodStartDate);
        }

        [TestMethod]
        public void TestPeriodStartDate_ShouldRemoveTimeWhenAssigned()
        {
            var period = new MyRentalPeriod
                             {
                                 PeriodStartDate = new DateTime(2009, 12, 1, 1, 1, 1)
                             };
            Assert.AreEqual(new DateTime(2009, 12, 1), period.PeriodStartDate);
        }

        private class MyRentalPeriod : RentalPeriodBase
        {
            public override DateTime CalculateNextPeriodEndDateFrom(DateTime fromDate)
            {
                throw new NotImplementedException();
            }
        }
    }
}