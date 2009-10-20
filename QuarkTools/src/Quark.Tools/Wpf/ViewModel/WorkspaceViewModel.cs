using System;
using System.Windows.Input;
using Quark.Tools.Wpf.Command;
using Quark.Tools.Wpf.Events;

namespace Quark.Tools.Wpf.ViewModel
{
    public class WorkspaceViewModel : ViewModelBase
    {
        private readonly ICommand closeCommand;

        public WorkspaceViewModel() : this (EventAggregator.Instance)
        {
        }

        public WorkspaceViewModel(IEventAggregator eventAggregator) : base(eventAggregator)
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