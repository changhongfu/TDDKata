using DemoApp.ViewModels;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class AllCustomersViewModelTest
    {
        [Test]
        public void TestCustomers()
        {
            var model = new AllCustomersViewModel();
            Assert.IsNotNull(model.Customers);
        }
    }
}