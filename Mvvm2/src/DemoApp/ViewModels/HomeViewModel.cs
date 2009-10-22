using System.Windows.Input;
using DemoApp.Messages;
using Quark.Tools.Ioc;
using Quark.Tools.Wpf.Command;
using Quark.Tools.Wpf.ViewModel;

namespace DemoApp.ViewModels
{
    public class HomeViewModel : WorkspaceViewModel
    {
        private readonly ICommand openSearchCustomersCommand;
        private readonly ICommand openAddCustomerCommand;

        public HomeViewModel(IIocContainer iocContainer) : base(iocContainer)
        {
            DisplayName = "Home";
            IsCloseable = false;
            openSearchCustomersCommand = new RelayCommand(p => Publish(new OpenSearchCustomersWorkspaceMessage()));
            openAddCustomerCommand = new RelayCommand(p => Publish(new OpenAddCustomerWorkspaceMessage()));
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