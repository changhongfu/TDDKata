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
            ICommand command = model.OpenSearchCommand;
            Assert.IsNotNull(command);
        }

        [Test]
        public void OpenSearchCommand_ShouldSendMessageToEventAggregator_WhenExecute()
        {
            var mock = new Mock<IEventAggregator>();
            var model = new HomeViewModel(mock.Object);

            model.OpenSearchCommand.Execute(null);

            mock.Verify(e => e.SendMessage(It.IsAny<OpenSearchCustomerWorkspaceMessage>()));
        }
    }
}