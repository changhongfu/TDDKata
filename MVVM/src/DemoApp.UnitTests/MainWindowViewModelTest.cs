using System.Linq;
using DemoApp.ViewModels;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class MainWindowViewModelTest
    {
        [Test]
        public void TestConstructor_Create2Commands()
        {
            var model = new MainWindowViewModel();
            var commands = model.Commands.ToArray();
            Assert.AreEqual("View all customers", commands[0].DisplayName);
            Assert.AreEqual("Create new customer", commands[1].DisplayName);
        }

        [Test]
        public void TestConstructor_CreateEmptyListOfWorkspaces()
        {
            var model = new MainWindowViewModel();
            var workspaces = model.Workspaces.ToArray();
            Assert.AreEqual(0, workspaces.Length);
        }

        [Test]
        public void TestViewAllCommand_AddWorkspace_WhenExecute()
        {
            var model = new MainWindowViewModel();
            var commands = model.Commands.ToArray();

            commands[0].Command.Execute(null);
            
            Assert.AreEqual(1, model.Workspaces.Count);
        }
    }
}