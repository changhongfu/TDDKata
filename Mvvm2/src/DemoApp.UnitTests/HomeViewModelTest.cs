using System.Windows.Input;
using DemoApp.Messages;
using DemoApp.ViewModels;
using Moq;
using NUnit.Framework;
using Quark.Tools.Wpf.Events;

namespace DemoApp.UnitTests
{
    [TestFixture]
    public class HomeViewModelTest
    {
        [Test]
        public void DisplayName_ShouldBe_Home()
        {
            var model = new HomeViewModel();
            var displayName = model.DisplayName;
            Assert.AreEqual("Home", displayName);
        }

        [Test]
        public void HomeViewModel_IsNotCloseable()
        {
            var model = new HomeViewModel();
            bool canClose = model.IsCloseable;
            Assert.IsFalse(canClose);
        }

        [Test]
        public void HomeViewModel_ShouldHaveOpenSearchCommand()
        {
            var model = new HomeViewModel();
            ICommand command = model.OpenSearchCustomersCommand;
            Assert.IsNotNull(command);
        }

        [Test]
        public void OpenSearchCustomerCommand_ShouldSendMessageToEventAggregator_WhenExecute()
        {
            var mock = new Mock<IEventAggregator>();
            var model = new HomeViewModel(mock.Object);

            model.OpenSearchCustomersCommand.Execute(null);

            mock.Verify(e => e.SendMessage(It.IsAny<OpenSearchCustomersWorkspaceMessage>()));
        }

        [Test]
        public void HomeViewModel_HasOpenAddCustomerCommand()
        {
            var model = new HomeViewModel(null);
            ICommand command = model.OpenAddCustomerCommand;
            Assert.IsNotNull(command);
        }

        [Test]
        public void OpenAddCustomerCommand_ShouldSendMessageToEventAggregator_WhenExecute()
        {
            var mock = new Mock<IEventAggregator>();
            var model = new HomeViewModel(mock.Object);

            model.OpenAddCustomerCommand.Execute(null);

            mock.Verify(e => e.SendMessage(It.IsAny<OpenAddCustomerWorkspaceMessage>()));
        }
    }
}