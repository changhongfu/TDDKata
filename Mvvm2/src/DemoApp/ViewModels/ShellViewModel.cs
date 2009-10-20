using System.Collections.ObjectModel;
using Quark.Tools.Extensions;
using Quark.Tools.Wpf.Events;
using Quark.Tools.Wpf.Extension;
using Quark.Tools.Wpf.ViewModel;
using DemoApp.Messages;

namespace DemoApp.ViewModels
{
    public class ShellViewModel : ViewModelBase
    {
        private ObservableCollection<WorkspaceViewModel> workspaces;

        public ShellViewModel() : this(EventAggregator.Instance)
        {
        }

        public ShellViewModel(IEventAggregator eventAggregator) : base(eventAggregator)
        {
            workspaces = new ObservableCollection<WorkspaceViewModel> { new HomeViewModel() };
            SubscribeToMessage<OpenSearchCustomersWorkspaceMessage>(msg => ShowSearchCustomers());
            SubscribeToMessage<OpenAddCustomerWorkspaceMessage>(msg => ShowAddCustomer());
            SubscribeToMessage<CloseWorkspaceMessage>(msg => CloseWorkspace(msg.WorkspaceToClose));
        }

        public ObservableCollection<WorkspaceViewModel> Workspaces
        {
            get { return workspaces; }
            set
            {
                if (workspaces == null)
                {
                    workspaces = value;
                    OnPropertyChanged("Workspaces");
                }
            }
        }

        private void ShowSearchCustomers()
        {
            var model = workspaces.FindOrCreate<SearchCustomerViewModel, WorkspaceViewModel>();
            workspaces.SetCurrentView(model);
        }

        private void ShowAddCustomer()
        {
            var model = new AddCustomerViewModel();
            workspaces.Add(model);
            workspaces.SetCurrentView(model);
        }

        private void CloseWorkspace(WorkspaceViewModel viewModel)
        {
            workspaces.Remove(viewModel);
            workspaces.SetCurrentView(workspaces[0]);
        }
    }
}