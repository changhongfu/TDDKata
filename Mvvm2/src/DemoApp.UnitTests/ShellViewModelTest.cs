using System.Linq;
using DemoApp.Messages;
using DemoApp.ViewModels;
using Moq;
using NUnit.Framework;
using Quark.Tools.Ioc;
using Quark.Tools.Wpf.Events;
using Quark.Tools.Wpf.ViewModel;

namespace DemoApp.UnitTests
{
    [TestFixture]
    public class ShellViewModelTest : BaseViewModelTest<ShellViewModel>
    {
        [Test]
        public void Workspaces_FirstElementShouldBeHomeViewModel()
        {
            var mock = new Mock<IIocContainer>();
            var expectedHomeViewModel = new HomeViewModel(mock.Object);
            mock.Setup(ioc => ioc.Resolve<HomeViewModel>()).Returns(expectedHomeViewModel);

            var model = CreateViewModel(mock);

            var actualHomeViewModel = model.Workspaces[0];
            Assert.AreEqual(expectedHomeViewModel, actualHomeViewModel);
        }

        [Test]
        public void ShellViewModel_ShouldSubscribeOpenSearchCustomersEvent()
        {
            var mock = new Mock<IEventAggregator>();

            var model = CreateViewModel(mock);

            mock.Verify(e => e.Subscribe<OpenSearchCustomersWorkspaceMessage>(model));
        }

        [Test]
        public void ShellViewModel_ShouldAddSearchCustomersViewModelToWorkspaces_OpenSearchCustomersWorkspaceMessageHandled()
        {
            var model = CreateViewModel(); 

            model.Handle(new OpenSearchCustomersWorkspaceMessage());

            var searchViewModel = (SearchCustomerViewModel)model.Workspaces[1];
            Assert.IsNotNull(searchViewModel);
        }

        [Test]
        public void ShellViewModel_ShouldOnlyAddSearchCustomersViewModelOnce()
        {
            var model = CreateViewModel(); 

            model.Handle(new OpenSearchCustomersWorkspaceMessage());
            model.Handle(new OpenSearchCustomersWorkspaceMessage());

            var searchModels = model.Workspaces.Where(m => m.GetType() == typeof(SearchCustomerViewModel)).ToArray();
            Assert.AreEqual(1, searchModels.Length);
        }

        [Test]
        public void ShellViewModel_ShouldSubscribeCloseWorkspaceEvent()
        {
            var mock = new Mock<IEventAggregator>();

            var model = CreateViewModel(mock);

            mock.Verify(e => e.Subscribe<CloseWorkspaceMessage>(model));
        }

        [Test]
        public void ShellViewModel_ShouldRemoveWorkspace_CloseWorkspaceMessageHandled()
        {
            var mock = new Mock<IEventAggregator>();
            var model = CreateViewModel(mock);

            model.Handle(new OpenAddCustomerWorkspaceMessage());    //To cause AddCustomerViewModel to be added to workspaces
            var addCustomerModel = model.Workspaces.Single(w => w.GetType() == typeof (AddCustomerViewModel));
            model.Handle(new CloseWorkspaceMessage(addCustomerModel));

            var exists = model.Workspaces.Contains(addCustomerModel);
            Assert.IsFalse(exists);
        }

        [Test]
        public void ShellViewModel_ShouldSubscribeOpenAddCustomerEvent()
        {
            var mock = new Mock<IEventAggregator>();

            var model = CreateViewModel(mock);

            mock.Verify(e => e.Subscribe<OpenAddCustomerWorkspaceMessage>(model));
        }

        [Test]
        public void ShellViewModel_ShouldAddAddCustomerViewModelToWorkspaces_WhenOpenAddCustomerWorkspaceMessageHandled()
        {
            var mock = new Mock<IEventAggregator>();
            var model = CreateViewModel(mock); 

            model.Handle(new OpenAddCustomerWorkspaceMessage());

            var addCustomerModel = model.Workspaces.Single(w => w.GetType() == typeof(AddCustomerViewModel));
            Assert.IsNotNull(addCustomerModel);
        }

        [Test]
        public void ShellViewModel_ShouldAddNewAddCustomerViewModelToWorkspaces_EveryTimeOpenAddCustomerWorkspaceMessageHandled()
        {
            var mock = new Mock<IEventAggregator>();
            var model = CreateViewModel(mock);

            model.Handle(new OpenAddCustomerWorkspaceMessage());
            model.Handle(new OpenAddCustomerWorkspaceMessage());

            var numAddCustomerModel = model.Workspaces.Where(w => w.GetType() == typeof(AddCustomerViewModel)).Count();
            Assert.AreEqual(2, numAddCustomerModel);
        }

        protected override ShellViewModel CreateViewModel(Mock<IEventAggregator> eventMock)
        {
            var iocMock = new Mock<IIocContainer>();
            iocMock.Setup(ioc => ioc.Resolve<IEventAggregator>()).Returns(eventMock.Object);
            iocMock.Setup(ioc => ioc.Resolve<HomeViewModel>()).Returns(new HomeViewModel(iocMock.Object));
            iocMock.Setup(ioc => ioc.Resolve<AddCustomerViewModel>()).Returns(new AddCustomerViewModel(iocMock.Object));
            iocMock.Setup(ioc => ioc.Resolve<SearchCriteriaViewModel>()).Returns(new SearchCriteriaViewModel(iocMock.Object));
            iocMock.Setup(ioc => ioc.Resolve<SearchCustomerViewModel>()).Returns(new SearchCustomerViewModel(iocMock.Object));
            return CreateViewModel(iocMock.Object);
        }

        protected override ShellViewModel CreateViewModel(IIocContainer iocContainer)
        {
            return new ShellViewModel(iocContainer);
        }
    }
}