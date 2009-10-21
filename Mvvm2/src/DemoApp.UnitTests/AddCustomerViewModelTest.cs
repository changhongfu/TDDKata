using DemoApp.ViewModels;
using Moq;
using NUnit.Framework;
using Quark.Tools.Ioc;

namespace DemoApp.UnitTests
{
    [TestFixture]
    public class AddCustomerViewModelTest
    {
        [Test]
        public void DisplayName_ShouldBe_AddCustomer()
        {
            var model = CreateAddCustomerViewModel();
            string displayName = model.DisplayName;
            Assert.AreEqual("Add Customer", displayName);
        }

        private static AddCustomerViewModel CreateAddCustomerViewModel()
        {
            var mock = new Mock<IIocContainer>();
            return new AddCustomerViewModel(mock.Object);
        }
    }
}