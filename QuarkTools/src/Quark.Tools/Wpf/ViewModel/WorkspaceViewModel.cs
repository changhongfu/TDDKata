using System;
using System.Windows.Input;
using Quark.Tools.Wpf.Command;
using Quark.Tools.Wpf.Events;

namespace Quark.Tools.Wpf.ViewModel
{
    public class WorkspaceViewModel : ViewModelBase
    {
        private readonly IEventAggregator eventAggregator;
        private readonly ICommand closeCommand;

        public WorkspaceViewModel() : this (EventAggregator.Instance)
        {
        }

        public WorkspaceViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;

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

        protected void PublishMessage<T>(T message) where T : IMessage
        {
            eventAggregator.SendMessage(message);
        }

        protected void SubscribeToMessage<T>(Action<T> action) where T : IMessage
        {
            eventAggregator.AddListener(action);
        }
    }
}