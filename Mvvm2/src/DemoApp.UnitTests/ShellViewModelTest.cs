using System;
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

            CreateViewModel(mock);

            mock.Verify(e => e.AddListener(It.IsAny<Action<OpenSearchCustomersWorkspaceMessage>>()));
        }

        [Test]
        public void ShellViewModel_ShouldAddSearchCustomersViewModelToWorkspaces_WhenOpenSearchCustomersMessagePublished()
        {
            var mock = new Mock<IEventAggregator>();
            var model = CreateViewModel(mock); 

            mock.Object.SendMessage(new OpenSearchCustomersWorkspaceMessage());

            var searchViewModel = (SearchCustomerViewModel)model.Workspaces[1];
            Assert.IsNotNull(searchViewModel);
        }

        [Test]
        public void ShellViewModel_ShouldNotAddSearchCustomersViewModelToWorkspaces_IfSearchCustomersViewModelAlreadyInWorkspaces()
        {
            var mock = new Mock<IEventAggregator>();
            var model = CreateViewModel(mock); 
            model.Workspaces.Add(new SearchCustomerViewModel(new Mock<IIocContainer>().Object));

            mock.Object.SendMessage(new OpenSearchCustomersWorkspaceMessage());

            var searchModels = model.Workspaces.Where(m => m.GetType() == typeof(SearchCustomerViewModel)).ToArray();
            Assert.AreEqual(1, searchModels.Length);
        }

        [Test]
        public void ShellViewModel_ShouldSubscribeCloseWorkspaceEvent()
        {
            var mock = new Mock<IEventAggregator>();

            CreateViewModel(mock);

            mock.Verify(e => e.AddListener(It.IsAny<Action<CloseWorkspaceMessage>>()));
        }

        [Test]
        public void ShellViewModel_ShouldRemoveWorkspace_WhenCloseWorkspaceMessagePublished()
        {
            var mock = new Mock<IEventAggregator>();
            var model = CreateViewModel(mock); 
            var viewModel = new SearchCustomerViewModel(new Mock<IIocContainer>().Object);
            model.Workspaces.Add(viewModel);

            mock.Object.SendMessage(new CloseWorkspaceMessage(viewModel));

            var exists = model.Workspaces.Contains(viewModel);
            Assert.IsFalse(exists);
        }

        [Test]
        public void ShellViewModel_ShouldSubscribeOpenAddCustomerEvent()
        {
            var mock = new Mock<IEventAggregator>();

            CreateViewModel(mock);

            mock.Verify(e => e.AddListener(It.IsAny<Action<OpenAddCustomerWorkspaceMessage>>()));
        }

        [Test]
        public void ShellViewModel_ShouldAddAddCustomerViewModelToWorkspaces_WhenOpenAddCustomerMessagePublished()
        {
            var mock = new Mock<IEventAggregator>();
            var model = CreateViewModel(mock); 

            mock.Object.SendMessage(new OpenAddCustomerWorkspaceMessage());

            var searchViewModel = (AddCustomerViewModel)model.Workspaces[1];    //index 0 is taken by HomeViewModel
            Assert.IsNotNull(searchViewModel);
        }

        protected override ShellViewModel CreateViewModel(Mock<IEventAggregator> eventMock)
        {
            HookupMessage<OpenSearchCustomersWorkspaceMessage>(eventMock);
            HookupMessage<OpenAddCustomerWorkspaceMessage>(eventMock);
            HookupMessage<CloseWorkspaceMessage>(eventMock);

            var iocMock = new Mock<IIocContainer>();
            iocMock.Setup(ioc => ioc.Resolve<IEventAggregator>()).Returns(eventMock.Object);
            iocMock.Setup(ioc => ioc.Resolve<HomeViewModel>()).Returns(new HomeViewModel(iocMock.Object));
            iocMock.Setup(ioc => ioc.Resolve<AddCustomerViewModel>()).Returns(new AddCustomerViewModel(iocMock.Object));
            iocMock.Setup(ioc => ioc.Resolve<SearchCustomerViewModel>()).Returns(new SearchCustomerViewModel(iocMock.Object));
            return CreateViewModel(iocMock.Object);
        }

        protected override ShellViewModel CreateViewModel(IIocContainer iocContainer)
        {
            return new ShellViewModel(iocContainer);
        }
    }
}