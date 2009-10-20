using Quark.Tools.Wpf.Events;

namespace Quark.Tools.Wpf.ViewModel
{
    public class CloseWorkspaceMessage : IMessage
    {
        private readonly WorkspaceViewModel workspaceToClose;

        public CloseWorkspaceMessage(WorkspaceViewModel workspaceToClose)
        {
            this.workspaceToClose = workspaceToClose;
        }

        public WorkspaceViewModel WorkspaceToClose
        {
            get { return workspaceToClose; }
        }
    }
}