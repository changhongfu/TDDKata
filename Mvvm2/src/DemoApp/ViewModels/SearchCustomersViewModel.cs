using System.Windows.Input;
using DemoApp.Messages;
using Quark.Tools.Wpf.Command;
using Quark.Tools.Wpf.Events;
using Quark.Tools.Wpf.ViewModel;

namespace DemoApp.ViewModels
{
    public class SearchCustomerViewModel : ViewModelBase
    {
        private readonly ICommand closeCommand;

        public SearchCustomerViewModel() : this(EventAggregator.Instance)
        {
        }

        public SearchCustomerViewModel(IEventAggregator eventAggregator)
        {
            closeCommand = new RelayCommand(delegate { eventAggregator.SendMessage(new CloseWorkspaceMessage(this)); });
        }

        public string DisplayName { get { return "Search Customers"; }}

        public ICommand CloseCommand
        {
            get { return closeCommand; }
        }
    }
}