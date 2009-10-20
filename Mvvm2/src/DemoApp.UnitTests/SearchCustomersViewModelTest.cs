using System.Windows.Input;
using DemoApp.ViewModels;
using Moq;
using NUnit.Framework;
using Quark.Tools.Wpf.Events;
using Quark.Tools.Wpf.ViewModel;

namespace DemoApp.UnitTests
{
    [TestFixture]
    public class SearchViewModelTest
    {
        [Test]
        public void DisplayName_ShouldBe_SearchCustomers()
        {
            var model = new SearchCustomerViewModel();
            string displayName = model.DisplayName;
            Assert.AreEqual("Search Customers", displayName);
        }

        [Test]
        public void SearchViewMode_HasCloseCommand()
        {
            var model = new SearchCustomerViewModel();

            ICommand command = model.CloseCommand;

            Assert.IsNotNull(command);
        }

        [Test]
        public void ShouldSendMessageToEventAggregator_WhenCloseCommandExecute()
        {
            var mock = new Mock<IEventAggregator>();
            var model = new SearchCustomerViewModel(mock.Object);

            model.CloseCommand.Execute(null);

            mock.Verify(e => e.SendMessage(It.Is<CloseWorkspaceMessage>(m => m.WorkspaceToClose == model)));
        }
    }
}