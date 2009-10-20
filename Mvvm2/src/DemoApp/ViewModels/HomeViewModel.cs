using System;
using System.Windows.Input;
using DemoApp.Messages;
using Quark.Tools.Wpf.Command;
using Quark.Tools.Wpf.Events;
using Quark.Tools.Wpf.ViewModel;

namespace DemoApp.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly ICommand openSearchCustomerCommand;
        private readonly ICommand openAddCustomerCommand;

        public HomeViewModel() : this(EventAggregator.Instance)
        {
            
        }

        public HomeViewModel(IEventAggregator eventAggregator)
        {
            openSearchCustomerCommand = new RelayCommand(delegate { eventAggregator.SendMessage(new OpenSearchCustomerWorkspaceMessage()); });
            openAddCustomerCommand = new RelayCommand(delegate { eventAggregator.SendMessage(new OpenAddCustomerWorkspaceMessage()); });
        }

        public string DisplayName { get { return "Home"; } }

        public bool IsCloseable { get { return false; } }

        public ICommand OpenSearchCustomerCommand
        {
            get { return openSearchCustomerCommand; }
        }

        public ICommand OpenAddCustomerCommand
        {
            get { return openAddCustomerCommand; }
        }
    }
}