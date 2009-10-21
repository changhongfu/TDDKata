using DemoApp.ViewModels;
using NUnit.Framework;
using Quark.Tools.Ioc;

namespace DemoApp.UnitTests
{
    [TestFixture]
    public class AddCustomerViewModelTest : BaseViewModelTest<AddCustomerViewModel>
    {
        [Test]
        public void DisplayName_ShouldBe_AddCustomer()
        {
            var model = CreateViewModel();
            string displayName = model.DisplayName;
            Assert.AreEqual("Add Customer", displayName);
        }

        protected override AddCustomerViewModel CreateViewModel(IIocContainer iocContainer)
        {
            return new AddCustomerViewModel(iocContainer);
        }
    }
}