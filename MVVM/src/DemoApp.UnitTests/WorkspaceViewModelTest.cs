using DemoApp.ViewModels;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class WorkspaceViewModelTest
    {
        [Test]
        public void HasCloseCommand()
        {
            WorkspaceViewModel model = new TestWorkspaceViewModel();
            Assert.IsNotNull(model.CloseCommand);
        }

        [Test]
        public void HasRequestCloseEvent()
        {
            WorkspaceViewModel model = new TestWorkspaceViewModel();
            model.RequestClose += delegate { };
        }

        [Test]
        public void ExecuteCloseEventWillRaiseRequestCloseEvent()
        {
            WorkspaceViewModel model = new TestWorkspaceViewModel();
            bool raised = false;
            model.RequestClose += delegate { raised = true; };
            model.CloseCommand.Execute(null);

            Assert.IsTrue(raised);
        }

        private class TestWorkspaceViewModel : WorkspaceViewModel
        {
            
        }
    }
}