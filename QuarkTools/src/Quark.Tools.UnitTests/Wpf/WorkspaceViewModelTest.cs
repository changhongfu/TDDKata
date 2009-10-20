using System.Windows.Input;
using Moq;
using NUnit.Framework;
using Quark.Tools.Wpf.Events;
using Quark.Tools.Wpf.ViewModel;

namespace Quark.Tools.UnitTests.Wpf
{
    [TestFixture]
    public class WorkspaceViewModelTest
    {
        [Test]
        public void Workspace_ShouldHaveDisplayName()
        {
            var model = new WorkspaceViewModel { DisplayName = "a" };
            string displayName = model.DisplayName;
            Assert.AreEqual("a", displayName);
        }

        [Test]
        public void IsCloseable_DefaultIsTrue()
        {
            var model = new WorkspaceViewModel();
            bool closable = model.IsCloseable;
            Assert.IsTrue(closable);
        }

        [Test]
        public void Workspace_ShouldHaveCloseCommand()
        {
            var model = new WorkspaceViewModel();
            ICommand command =  model.CloseCommand;
            Assert.IsNotNull(command);
        }

        [Test]
        public void CloseCommand_ShouldPublishCloseEvent_WhenExecute()
        {
            var mock = new Mock<IEventAggregator>();
            var model = new WorkspaceViewModel(mock.Object);

            model.CloseCommand.Execute(null);

            mock.Verify(e => e.SendMessage(It.IsAny<CloseWorkspaceMessage>()));
        }
    }
}