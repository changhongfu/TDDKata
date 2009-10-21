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
    public class HomeViewModelTest
    {
        [Test]
        public void DisplayName_ShouldBe_Home()
        {
            var model = CreateHomeViewModel();
            var displayName = model.DisplayName;
            Assert.AreEqual("Home", displayName);
        }

        [Test]
        public void HomeViewModel_IsNotCloseable()
        {
            var model = CreateHomeViewModel();
            bool canClose = model.IsCloseable;
            Assert.IsFalse(canClose);
        }

        [Test]
        public void HomeViewModel_ShouldHaveOpenSearchCommand()
        {
            var model = CreateHomeViewModel();
            ICommand command = model.OpenSearchCustomersCommand;
            Assert.IsNotNull(command);
        }

        [Test]
        public void OpenSearchCustomerCommand_ShouldSendMessageToEventAggregator_WhenExecute()
        {
            var mock = new Mock<IEventAggregator>();
            var model = CreateHomeViewModel(mock.Object);

            model.OpenSearchCustomersCommand.Execute(null);

            mock.Verify(e => e.SendMessage(It.IsAny<OpenSearchCustomersWorkspaceMessage>()));
        }

        [Test]
        public void HomeViewModel_HasOpenAddCustomerCommand()
        {
            var model = CreateHomeViewModel();
            ICommand command = model.OpenAddCustomerCommand;
            Assert.IsNotNull(command);
        }

        [Test]
        public void OpenAddCustomerCommand_ShouldSendMessageToEventAggregator_WhenExecute()
        {
            var mock = new Mock<IEventAggregator>();
            var model = CreateHomeViewModel(mock.Object);

            model.OpenAddCustomerCommand.Execute(null);

            mock.Verify(e => e.SendMessage(It.IsAny<OpenAddCustomerWorkspaceMessage>()));
        }

        private static HomeViewModel CreateHomeViewModel()
        {
            return CreateHomeViewModel(new Mock<IEventAggregator>().Object);
        }

        private static HomeViewModel CreateHomeViewModel(IEventAggregator eventAggregator)
        {
            var iocMock = new Mock<IIocContainer>();
            iocMock.Setup(ioc => ioc.Resolve<IEventAggregator>()).Returns(eventAggregator);
            return new HomeViewModel(iocMock.Object);
        }
    }
}