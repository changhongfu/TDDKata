using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Tests
{
    [TestClass]
    public class DateTimeExtensionsFixture
    {
        [TestMethod]
        public void TestAsDateOnly()
        {
            var dateWithTime = new DateTime(2009, 12, 1, 1, 1, 1);

            var dateOnly = dateWithTime.AsDateOnly();

            Assert.AreEqual(new DateTime(2009, 12, 1), dateOnly);
        }

        [TestMethod]
        public void TestLastDayOfMonth_2009_1_1()
        {
            TestLastDayOfMonth(new DateTime(2009, 1, 1), 31);
        }

        [TestMethod]
        public void TestLastDayOfMonth_2009_1_15()
        {
            TestLastDayOfMonth(new DateTime(2009, 1, 15), 31);
        }

        [TestMethod]
        public void TestLastDayOfMonth_2009_1_31()
        {
            TestLastDayOfMonth(new DateTime(2009, 1, 31), 31);
        }

        [TestMethod]
        public void TestLastDayOfMonth_2009_2_15()
        {
            TestLastDayOfMonth(new DateTime(2009, 2, 15), 28);
        }

        [TestMethod]
        public void TestLastDayOfMonth_2009_3_31()
        {
            TestLastDayOfMonth(new DateTime(2009, 3, 31), 31);
        }

        [TestMethod]
        public void TestLastDayOfMonth_2009_4_15()
        {
            TestLastDayOfMonth(new DateTime(2009, 4, 15), 30);
        }

        [TestMethod]
        public void TestLastDayOfMonth_2009_12_31()
        {
            TestLastDayOfMonth(new DateTime(2009, 12, 31), 31);
        }

        private void TestLastDayOfMonth(DateTime testingDate, int expectedLastDay)
        {
            int lastDayOfMonth = testingDate.GetLastDayOfMonth();
            Assert.AreEqual(expectedLastDay, lastDayOfMonth);
        }
    }
}