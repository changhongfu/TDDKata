using System;
using DemoApp.Models;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class CustomerTest
    {
        [Test]
        public void TestFirstName_DefaultToEmpty()
        {
            var customer = new Customer();
            Assert.AreEqual(String.Empty, customer.FirstName);
        }

        [Test]
        public void TestLastName_DefaultToEmpty()
        {
            var customer = new Customer();
            Assert.AreEqual(String.Empty, customer.LastName);
        }

        [Test]
        public void TestEmail_DefaultToEmpty()
        {
            var customer = new Customer();
            Assert.IsNotNull(customer.Email);
        }

        [Test]
        public void TestType_DefaultToPersonal()
        {
            var customer = new Customer();
            Assert.AreEqual(CustomerType.Person, customer.Type);
        }

        [Test]
        public void TestTotalSales_DefaultToZero()
        {
            var customer = new Customer();
            Assert.AreEqual(0, customer.TotalSales);
        }
    }
}
