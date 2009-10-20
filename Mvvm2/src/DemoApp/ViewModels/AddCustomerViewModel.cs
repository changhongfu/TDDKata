using System.Windows.Input;
using DemoApp.Messages;
using Quark.Tools.Wpf.Command;
using Quark.Tools.Wpf.Events;
using Quark.Tools.Wpf.ViewModel;

namespace DemoApp.ViewModels
{
    public class AddCustomerViewModel : ViewModelBase
    {
        private readonly ICommand closeCommand;

        public AddCustomerViewModel() : this(EventAggregator.Instance)
        {
        }

        public AddCustomerViewModel(IEventAggregator eventAggregator)
        {
            closeCommand = new RelayCommand(delegate { eventAggregator.SendMessage(new CloseWorkspaceMessage(this)); });
        }

        public string DisplayName
        {
            get { return "Add Customer"; }
        }

        public bool IsClosable
        {
            get { return true; }
        }

        public ICommand CloseCommand
        {
            get { return closeCommand; }
        }
    }
}