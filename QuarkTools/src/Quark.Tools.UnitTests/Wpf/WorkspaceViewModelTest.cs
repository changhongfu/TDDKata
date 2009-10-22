using System.Windows.Input;
using Moq;
using NUnit.Framework;
using Quark.Tools.Ioc;
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
            var model = CreateWorkspaceViewModel();
            model.DisplayName = "a";
            string displayName = model.DisplayName;
            Assert.AreEqual("a", displayName);
        }

        [Test]
        public void IsCloseable_DefaultIsTrue()
        {
            var model = CreateWorkspaceViewModel();
            bool closable = model.IsCloseable;
            Assert.IsTrue(closable);
        }

        [Test]
        public void Workspace_ShouldHaveCloseCommand()
        {
            var model = CreateWorkspaceViewModel();
            ICommand command =  model.CloseCommand;
            Assert.IsNotNull(command);
        }

        [Test]
        public void CloseCommand_ShouldPublishCloseEvent_WhenExecute()
        {
            var mock = new Mock<IEventAggregator>();
            var model = CreateWorkspaceViewModel(mock.Object);

            model.CloseCommand.Execute(null);

            mock.Verify(e => e.Publish(It.IsAny<CloseWorkspaceMessage>()));
        }

        private static WorkspaceViewModel CreateWorkspaceViewModel()
        {
            return CreateWorkspaceViewModel(new Mock<IEventAggregator>().Object);
        }

        private static WorkspaceViewModel CreateWorkspaceViewModel(IEventAggregator eventAggregator)
        {
            var iocMock = new Mock<IIocContainer>();
            iocMock.Setup(ioc => ioc.Resolve<IEventAggregator>()).Returns(eventAggregator);

            return new WorkspaceViewModel(iocMock.Object);
        }
    }
}