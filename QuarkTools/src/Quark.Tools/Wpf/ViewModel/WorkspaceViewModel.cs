using System;
using System.Windows.Input;
using Quark.Tools.Ioc;
using Quark.Tools.Wpf.Command;
using Quark.Tools.Wpf.Events;

namespace Quark.Tools.Wpf.ViewModel
{
    public class WorkspaceViewModel : ViewModelBase
    {
        private readonly ICommand closeCommand;

        public WorkspaceViewModel() : this (null)
        {
        }

        public WorkspaceViewModel(IIocContainer iocContainer)
            : base(iocContainer)
        {
            DisplayName = "Workspace";
            IsCloseable = true;
            closeCommand = new RelayCommand(p => PublishMessage(new CloseWorkspaceMessage(this)));
        }

        public string DisplayName { get; set; }

        public bool IsCloseable { get; set; }

        public ICommand CloseCommand
        {
            get { return closeCommand; }
        }
    }
}