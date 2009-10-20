using DemoApp.ViewModels;
using NUnit.Framework;

namespace DemoApp.UnitTests
{
    [TestFixture]
    public class AddCustomerViewModelTest
    {
        [Test]
        public void DisplayName_ShouldBe_AddCustomer()
        {
            var model = new AddCustomerViewModel();
            string displayName = model.DisplayName;
            Assert.AreEqual("Add Customer", displayName);
        }

        [Test]
        public void AddCustomerViewModel_IsClosable()
        {
            var model = new AddCustomerViewModel();
            bool closable = model.IsClosable;
            Assert.IsTrue(closable);
        }
    }
}