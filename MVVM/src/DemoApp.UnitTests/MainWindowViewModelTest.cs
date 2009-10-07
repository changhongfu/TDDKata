using System.Linq;
using DemoApp.ViewModels;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class MainWindowViewModelTest
    {
        [Test]
        public void HasCommandsForViewAllCustomerAndCreateNewCustomer_WhenCreated()
        {
            var model = new MainWindowViewModel();
            var commands = model.Commands.ToArray();
            Assert.AreEqual("View all customers", commands[0].DisplayName);
            Assert.AreEqual("Create new customer", commands[1].DisplayName);
        }

        [Test]
        public void HasEmptyListOfWorkspaces_WhenCreated()
        {
            var model = new MainWindowViewModel();
            var workspaces = model.Workspaces.ToArray();
            Assert.AreEqual(0, workspaces.Length);
        }

        [Test]
        public void ShouldAddAllCustomersViewModelToWorkspaces_WhenViewAllCustomersCommandExecuted()
        {
            var model = new MainWindowViewModel();
            var viewAllCommand = model.Commands.ToArray()[0].Command;

            viewAllCommand.Execute(null);

            Assert.AreEqual(1, model.Workspaces.Count);
            Assert.AreEqual(typeof(AllCustomersViewModel), model.Workspaces[0].GetType());
        }

        [Test]
        public void ExecuteViewAllCustomersCommandMoreThanOnce_ShouldOnlyHaveOneAllCustomersViewModelInWorkspaces()
        {
            var model = new MainWindowViewModel();
            var viewAllCommand = model.Commands.ToArray()[0].Command;

            viewAllCommand.Execute(null);
            viewAllCommand.Execute(null);

            Assert.AreEqual(1, model.Workspaces.Count);
        }

        [Test]
        public void ShouldAddCustomerViewModelToWorkspace_WhenCreateNewCustomerCommandExecuted()
        {
            var model = new MainWindowViewModel();
            var createNewCommand = model.Commands.ToArray()[1].Command;

            createNewCommand.Execute(null);

            Assert.AreEqual(1, model.Workspaces.Count);
            Assert.AreEqual(typeof(CustomerViewModel), model.Workspaces[0].GetType());
        }

        [Test]
        public void EverytimeExecuteCreateNewCustomer_ShouldCreateANewCustomerViewModel()
        {
            var model = new MainWindowViewModel();
            var createNewCommand = model.Commands.ToArray()[1].Command;

            createNewCommand.Execute(null);
            createNewCommand.Execute(null);

            var customerViewModels = model.Workspaces.Where(w => w is CustomerViewModel).ToArray();
            Assert.AreEqual(2, customerViewModels.Length);
        }

        [Test]
        public void ViewAllCustomersModelShouldHookupToRequestCloseEventToRemoveItFromWorkspaces_WhenItIsAddedToWorkspaces()
        {
            var model = new MainWindowViewModel();
            var viewAllCommand = model.Commands.ToArray()[0].Command;

            viewAllCommand.Execute(null);

            model.Workspaces[0].CloseCommand.Execute(null);
            Assert.AreEqual(0, model.Workspaces.Count);
        }

        [Test]
        public void CreateNewCustomerModelShouldHookupToRequestCloseEventToRemoveItFromWorkspaces_WhenItIsAddedToWorkspaces()
        {
            var model = new MainWindowViewModel();
            var createNewCommand = model.Commands.ToArray()[1].Command;

            createNewCommand.Execute(null);

            model.Workspaces[0].CloseCommand.Execute(null);
            Assert.AreEqual(0, model.Workspaces.Count);
        }
    }
}