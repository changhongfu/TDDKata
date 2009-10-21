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
    public class ShellViewModelTest
    {
        [Test]
        public void WorkspacesFirstElement_ShouldBe_HomeViewModel()
        {
            var model = CreateShellViewModel();
            var homeViewModel = model.Workspaces[0];
            Assert.AreEqual(typeof(HomeViewModel), homeViewModel.GetType());
        }

        [Test]
        public void ShellViewModel_ShouldSubscribeOpenSearchCustomersEvent()
        {
            var mock = new Mock<IEventAggregator>();

            CreateShellViewModel(mock.Object);

            mock.Verify(e => e.AddListener(It.IsAny<Action<OpenSearchCustomersWorkspaceMessage>>()));
        }

        [Test]
        public void ShellViewModel_ShouldAddSearchCustomersViewModelToWorkspaces_WhenOpenSearchCustomersMessagePublished()
        {
            var aggregator = new EventAggregator();
            var model = CreateShellViewModel(aggregator);

            aggregator.SendMessage(new OpenSearchCustomersWorkspaceMessage());

            var searchViewModel = (SearchCustomerViewModel)model.Workspaces[1];
            Assert.IsNotNull(searchViewModel);
        }

        [Test]
        public void ShellViewModel_ShouldNotAddSearchCustomersViewModelToWorkspaces_IfSearchCustomersViewModelAlreadyInWorkspaces()
        {
            var aggregator = new EventAggregator();
            var model = CreateShellViewModel(aggregator);
            model.Workspaces.Add(new SearchCustomerViewModel(new Mock<IIocContainer>().Object));

            aggregator.SendMessage(new OpenSearchCustomersWorkspaceMessage());

            var searchModels = model.Workspaces.Where(m => m.GetType() == typeof(SearchCustomerViewModel)).ToArray();     
            Assert.AreEqual(1, searchModels.Length);
        }

        [Test]
        public void ShellViewModel_ShouldSubscribeCloseWorkspaceEvent()
        {
            var mock = new Mock<IEventAggregator>();

            CreateShellViewModel(mock.Object);

            mock.Verify(e => e.AddListener(It.IsAny<Action<CloseWorkspaceMessage>>()));
        }

        [Test]
        public void ShellViewModel_ShouldRemoveWorkspace_WhenCloseWorkspaceMessagePublished()
        {
            var aggregator = new EventAggregator();
            var model = CreateShellViewModel(aggregator);
            var viewModel = new SearchCustomerViewModel(new Mock<IIocContainer>().Object);
            model.Workspaces.Add(viewModel);

            aggregator.SendMessage(new CloseWorkspaceMessage(viewModel));

            var exists = model.Workspaces.Contains(viewModel);
            Assert.IsFalse(exists);
        }

        [Test]
        public void ShellViewModel_ShouldSubscribeOpenAddCustomerEvent()
        {
            var mock = new Mock<IEventAggregator>();

            CreateShellViewModel(mock.Object);

            mock.Verify(e => e.AddListener(It.IsAny<Action<OpenAddCustomerWorkspaceMessage>>()));
        }

        [Test]
        public void ShellViewModel_ShouldAddAddCustomerViewModelToWorkspaces_WhenOpenAddCustomerMessagePublished()
        {
            var aggregator = new EventAggregator();
            var model = CreateShellViewModel(aggregator);

            aggregator.SendMessage(new OpenAddCustomerWorkspaceMessage());

            var searchViewModel = (AddCustomerViewModel)model.Workspaces[1];
            Assert.IsNotNull(searchViewModel);
        }

        private static ShellViewModel CreateShellViewModel()
        {
            return CreateShellViewModel(new Mock<IEventAggregator>().Object);
        }

        private static ShellViewModel CreateShellViewModel(IEventAggregator eventAggregator)
        {
            var iocMock = new Mock<IIocContainer>();
            iocMock.Setup(ioc => ioc.Resolve<IEventAggregator>()).Returns(eventAggregator);
            iocMock.Setup(ioc => ioc.Resolve<HomeViewModel>()).Returns(new HomeViewModel(iocMock.Object));
            iocMock.Setup(ioc => ioc.Resolve<AddCustomerViewModel>()).Returns(new AddCustomerViewModel(iocMock.Object));
            iocMock.Setup(ioc => ioc.Resolve<SearchCustomerViewModel>()).Returns(new SearchCustomerViewModel(iocMock.Object));
            return new ShellViewModel(iocMock.Object);
        }
    }
}