using System.Linq;
using DemoApp.Messages;
using DemoApp.Models;
using DemoApp.Services;
using DemoApp.ViewModels;
using Moq;
using NUnit.Framework;
using Quark.Tools.Ioc;
using Quark.Tools.Testing.Extensions;
using Quark.Tools.Wpf.Events;

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
            var model = CreateViewModel();

            Assert.IsNotNull(model.SearchCriteriaViewModel);
        }

        [Test]
        public void SearchCriteriaViewModel_ShouldHaveBoundTypeAsCustomer()
        {
            var model = CreateViewModel();

            Assert.That(model.SearchCriteriaViewModel.AvailableProperties.Any(p => p.Name == "CustomerId"));
        }

        [Test]
        public void ShouldSubscribeToSearchCustomersMessage()
        {
            var mock = new Mock<IEventAggregator>();
            var model = CreateViewModel(new Mock<IIocContainer>(), mock);

            mock.Verify(e => e.Subscribe(model));
        }

        [Test]
        public void ShouldSearchCustomers_WhenSearchCustomersMessageHandled()
        {
            var mock = new Mock<ICustomerService>();
            var iocMock = new Mock<IIocContainer>();
            iocMock.Setup(ioc => ioc.Resolve<ICustomerService>()).Returns(mock.Object);
            var model = CreateViewModel(iocMock);

            model.Handle(new SearchCustomersMessage());

            mock.Verify(s => s.GetCustomers());
        }

        [Test]
        public void ShouldAssignSearchResultToMatchedCustomers()
        {
            var mock = new Mock<ICustomerService>();
            var iocMock = new Mock<IIocContainer>();
            iocMock.Setup(ioc => ioc.Resolve<ICustomerService>()).Returns(mock.Object);
            var model = CreateViewModel(iocMock);

            var customers = new Customer[0];
            mock.Setup(s => s.GetCustomers()).Returns(customers);

            model.Handle(new SearchCustomersMessage());

            Assert.AreEqual(customers, model.MatchedCustomers);
        }

        [Test]
        public void ChangeMatchedCustomers_ShouldRaisePropertyChangedEvent()
        {
            var model = CreateViewModel();
            model.AssertEventWasRaised("MatchedCustomers", o => o.MatchedCustomers = new Customer[0]);
        }


        protected override SearchCustomerViewModel CreateViewModel(Mock<IIocContainer> iocMock, Mock<IEventAggregator> eventMock)
        {
            iocMock.Setup(ioc => ioc.Resolve<IEventAggregator>()).Returns(eventMock.Object);
            iocMock.Setup(ioc => ioc.Resolve<SearchCriteriaViewModel>()).Returns(new SearchCriteriaViewModel(iocMock.Object));
            return CreateViewModel(iocMock.Object);
        }

        protected override SearchCustomerViewModel CreateViewModel(IIocContainer iocContainer)
        {
            return new SearchCustomerViewModel(iocContainer);
        }
    }
}