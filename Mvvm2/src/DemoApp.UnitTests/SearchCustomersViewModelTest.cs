using DemoApp.ViewModels;
using Moq;
using NUnit.Framework;
using Quark.Tools.Ioc;
using Quark.Tools.Wpf.Events;

namespace DemoApp.UnitTests
{
    [TestFixture]
    public class SearchViewModelTest
    {
        [Test]
        public void DisplayName_ShouldBe_SearchCustomers()
        {
            var model = CreateSearchCustomerViewModel();
            string displayName = model.DisplayName;
            Assert.AreEqual("Search Customers", displayName);
        }

        private static SearchCustomerViewModel CreateSearchCustomerViewModel()
        {
            return CreateSearchCustomerViewModel(new Mock<IEventAggregator>().Object);
        } 

        private static SearchCustomerViewModel CreateSearchCustomerViewModel(IEventAggregator eventAggregator)
        {
            var iocMock = new Mock<IIocContainer>();
            iocMock.Setup(ioc => ioc.Resolve<IEventAggregator>()).Returns(eventAggregator);
            return new SearchCustomerViewModel(iocMock.Object);
        }
    }
}