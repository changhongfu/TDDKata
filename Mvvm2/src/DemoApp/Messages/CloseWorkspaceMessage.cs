using Quark.Tools.Wpf.Events;
using Quark.Tools.Wpf.ViewModel;

namespace DemoApp.Messages
{
    public class CloseWorkspaceMessage : IMessage
    {
        private readonly ViewModelBase workspaceToClose;

        public CloseWorkspaceMessage(ViewModelBase workspaceToClose)
        {
            this.workspaceToClose = workspaceToClose;
        }

        public ViewModelBase WorkspaceToClose
        {
            get { return workspaceToClose; }
        }
    }
}