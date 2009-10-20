using System.Windows.Input;
using DemoApp.Messages;
using Quark.Tools.Wpf.Command;
using Quark.Tools.Wpf.Events;
using Quark.Tools.Wpf.ViewModel;

namespace DemoApp.ViewModels
{
    public class HomeViewModel : WorkspaceViewModel
    {
        private readonly ICommand openSearchCustomersCommand;
        private readonly ICommand openAddCustomerCommand;

        public HomeViewModel() : this(EventAggregator.Instance)
        {
        }

        public HomeViewModel(IEventAggregator eventAggregator) : base(eventAggregator)
        {
            DisplayName = "Home";
            IsCloseable = false;
            openSearchCustomersCommand = new RelayCommand(p => PublishMessage(new OpenSearchCustomersWorkspaceMessage()));
            openAddCustomerCommand = new RelayCommand(p => PublishMessage(new OpenAddCustomerWorkspaceMessage()));
        }

        public ICommand OpenSearchCustomersCommand
        {
            get { return openSearchCustomersCommand; }
        }

        public ICommand OpenAddCustomerCommand
        {
            get { return openAddCustomerCommand; }
        }
    }
}