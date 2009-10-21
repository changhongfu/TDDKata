using System.Windows.Input;
using DemoApp.Messages;
using DemoApp.ViewModels;
using Moq;
using NUnit.Framework;
using Quark.Tools.Ioc;
using Quark.Tools.Wpf.Events;

namespace DemoApp.UnitTests
{
    [TestFixture]
    public class HomeViewModelTest : BaseViewModelTest<HomeViewModel>
    {
        [Test]
        public void DisplayName_ShouldBe_Home()
        {
            var model = CreateViewModel();
            var displayName = model.DisplayName;
            Assert.AreEqual("Home", displayName);
        }

        [Test]
        public void HomeViewModel_IsNotCloseable()
        {
            var model = CreateViewModel();
            bool canClose = model.IsCloseable;
            Assert.IsFalse(canClose);
        }

        [Test]
        public void HomeViewModel_ShouldHaveOpenSearchCommand()
        {
            var model = CreateViewModel();
            ICommand command = model.OpenSearchCustomersCommand;
            Assert.IsNotNull(command);
        }

        [Test]
        public void OpenSearchCustomerCommand_ShouldSendMessageToEventAggregator_WhenExecute()
        {
            var mock = new Mock<IEventAggregator>();
            var model = CreateViewModel(mock);

            model.OpenSearchCustomersCommand.Execute(null);

            mock.Verify(e => e.SendMessage(It.IsAny<OpenSearchCustomersWorkspaceMessage>()));
        }

        [Test]
        public void HomeViewModel_HasOpenAddCustomerCommand()
        {
            var model = CreateViewModel();
            ICommand command = model.OpenAddCustomerCommand;
            Assert.IsNotNull(command);
        }

        [Test]
        public void OpenAddCustomerCommand_ShouldSendMessageToEventAggregator_WhenExecute()
        {
            var mock = new Mock<IEventAggregator>();
            var model = CreateViewModel(mock);

            model.OpenAddCustomerCommand.Execute(null);

            mock.Verify(e => e.SendMessage(It.IsAny<OpenAddCustomerWorkspaceMessage>()));
        }

        protected override HomeViewModel CreateViewModel(IIocContainer iocContainer)
        {
            return new HomeViewModel(iocContainer);
        }
    }
}