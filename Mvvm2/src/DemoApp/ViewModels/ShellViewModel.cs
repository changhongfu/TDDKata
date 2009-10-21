using System.Collections.ObjectModel;
using System.Linq;
using Quark.Tools.Ioc;
using Quark.Tools.Wpf.Extension;
using Quark.Tools.Wpf.ViewModel;
using DemoApp.Messages;

namespace DemoApp.ViewModels
{
    public class ShellViewModel : ViewModelBase
    {
        private ObservableCollection<WorkspaceViewModel> workspaces;

        public ShellViewModel(IIocContainer iocContainer) : base(iocContainer)
        {
            workspaces = new ObservableCollection<WorkspaceViewModel> { iocContainer.Resolve<HomeViewModel>() };
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
            var workspace = FindWorkspace<SearchCustomerViewModel>() ??
                            AddWorkspace<SearchCustomerViewModel>();
            workspaces.SetCurrentView(workspace);
        }

        private void ShowAddCustomer()
        {
            var model = AddWorkspace<AddCustomerViewModel>();
            workspaces.SetCurrentView(model);
        }

        private void CloseWorkspace(WorkspaceViewModel viewModel)
        {
            workspaces.Remove(viewModel);
            workspaces.SetCurrentView(workspaces[0]);
        }

        private T FindWorkspace<T>() where T : WorkspaceViewModel
        {
            return workspaces.SingleOrDefault(w => w.GetType() == typeof(T)) as T;
        }

        private T AddWorkspace<T>() where T : WorkspaceViewModel
        {
            var workspace = CreateViewModel<T>();
            workspaces.Add(workspace);

            return workspace;
        }
    }
}