using System.Linq;
using DemoApp.ViewModels;
using Moq;
using NUnit.Framework;
using Quark.Tools.Ioc;

namespace DemoApp.UnitTests
{
    [TestFixture]
    public class SearchViewModelTest : BaseViewModelTest<SearchCustomerViewModel>
    {
        [Test]
        public void DisplayName_ShouldBeSearchCustomers()
        {
            var model = CreateViewModel();
            string displayName = model.DisplayName;
            Assert.AreEqual("Search Customers", displayName);
        }

        [Test]
        public void HasSearchCriteriaViewModel()
        {
            var mock  = new Mock<IIocContainer>();
            var expected = new SearchCriteriaViewModel(mock.Object);
            mock.Setup(ioc => ioc.Resolve<SearchCriteriaViewModel>()).Returns(expected);

            var model = CreateViewModel(mock);

            Assert.AreEqual(expected, model.SearchCriteriaViewModel);
        }

        [Test]
        public void SearchCriteriaViewModel_ShouldHaveBoundTypeAsCustomer()
        {
            var mock = new Mock<IIocContainer>();
            var expected = new SearchCriteriaViewModel(mock.Object);
            mock.Setup(ioc => ioc.Resolve<SearchCriteriaViewModel>()).Returns(expected);

            var model = CreateViewModel(mock);

            Assert.That(model.SearchCriteriaViewModel.AvailableProperties.Any(p => p.Name == "CustomerId"));
        }

        protected override SearchCustomerViewModel CreateViewModel(IIocContainer iocContainer)
        {
            return new SearchCustomerViewModel(iocContainer);
        }
    }
}