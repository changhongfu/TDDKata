using System;
using System.Linq;
using DemoApp.Messages;
using DemoApp.ViewModels;
using Moq;
using NUnit.Framework;
using Quark.Tools.Wpf.Events;

namespace DemoApp.UnitTests
{
    [TestFixture]
    public class ShellViewModelTest
    {
        [Test]
        public void WorkspacesFirstElement_ShouldBe_HomeViewModel()
        {
            var model = new ShellViewModel();
            var homeViewModel = model.Workspaces[0];
            Assert.AreEqual(typeof(HomeViewModel), homeViewModel.GetType());
        }

        [Test]
        public void ShellViewModel_ShouldSubscribeOpenSearchEvent()
        {
            var mock = new Mock<IEventAggregator>();

            new ShellViewModel(mock.Object);

            mock.Verify(e => e.AddListener(It.IsAny<Action<OpenSearchCustomerWorkspaceMessage>>()));
        }

        [Test]
        public void ShellViewModel_ShouldAddSearchViewModelToWorkspaces_WhenOpenSearchMessagePublished()
        {
            var aggregator = new EventAggregator();
            var model = new ShellViewModel(aggregator);

            aggregator.SendMessage(new OpenSearchCustomerWorkspaceMessage());

            var searchViewModel = (SearchCustomerViewModel)model.Workspaces[1];
            Assert.IsNotNull(searchViewModel);
        }

        [Test]
        public void ShellViewModel_ShouldNotAddSearchViewModelToWorkspaces_IfSearchViewModelAlreadyInWorkspaces()
        {
            var aggregator = new EventAggregator();
            var model = new ShellViewModel(aggregator);
            model.Workspaces.Add(new SearchCustomerViewModel());

            aggregator.SendMessage(new OpenSearchCustomerWorkspaceMessage());

            var searchModels = model.Workspaces.Where(m => m.GetType() == typeof(SearchCustomerViewModel)).ToArray();     
            Assert.AreEqual(1, searchModels.Length);
        }

        [Test]
        public void ShellViewModel__ShouldSubscribeCloseWorkspaceEvent()
        {
            var mock = new Mock<IEventAggregator>();

            new ShellViewModel(mock.Object);

            mock.Verify(e => e.AddListener(It.IsAny<Action<CloseWorkspaceMessage>>()));
        }

        [Test]
        public void ShellViewModel_ShouldRemoveWorkspace_WhenCloseWorkspaceMessagePublished()
        {
            var aggregator = new EventAggregator();
            var model = new ShellViewModel(aggregator);
            var viewModel = new SearchCustomerViewModel();
            model.Workspaces.Add(viewModel);

            aggregator.SendMessage(new CloseWorkspaceMessage(viewModel));

            var exists = model.Workspaces.Contains(viewModel);
            Assert.IsFalse(exists);
        }
    }
}