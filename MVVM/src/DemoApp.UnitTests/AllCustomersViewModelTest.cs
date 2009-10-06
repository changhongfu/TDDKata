using DemoApp.Models;
using DemoApp.Services;
using DemoApp.ViewModels;
using Moq;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class AllCustomersViewModelTest
    {
        [Test]
        public void TestConstructor_ShouldLoadAllCustomers()
        {
            var mock = new Mock<ICustomerService>();
            var customers = new[] {new Customer()};
            mock.Setup(m => m.GetAllCustomers()).Returns(customers);

            var model = new AllCustomersViewModel(mock.Object);

            Assert.AreEqual(customers[0], model.Customers[0].Customer);
        }
    }
}