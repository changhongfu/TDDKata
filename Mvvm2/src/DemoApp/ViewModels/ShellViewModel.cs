using System;
using System.Collections.ObjectModel;
using System.Linq;
using DemoApp.Messages;
using Quark.Tools.Ioc;
using Quark.Tools.Wpf.Events;
using Quark.Tools.Wpf.Extension;
using Quark.Tools.Wpf.ViewModel;

namespace DemoApp.ViewModels
{
    public class ShellViewModel : ViewModelBase, 
        ISubscriber<OpenSearchCustomersWorkspaceMessage>, 
        ISubscriber<OpenAddCustomerWorkspaceMessage>, 
        ISubscriber<CloseWorkspaceMessage>
    {
        private ObservableCollection<WorkspaceViewModel> workspaces;

        public ShellViewModel(IIocContainer iocContainer) : base(iocContainer)
        {
            workspaces = new ObservableCollection<WorkspaceViewModel> { iocContainer.Resolve<HomeViewModel>() };
            Subscribe<OpenSearchCustomersWorkspaceMessage>(this);
            Subscribe<OpenAddCustomerWorkspaceMessage>(this);
            Subscribe<CloseWorkspaceMessage>(this);
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

        public void Handle(OpenSearchCustomersWorkspaceMessage message)
        {
            var workspace = FindWorkspace<SearchCustomerViewModel>() ??
                            AddWorkspace<SearchCustomerViewModel>();
            workspaces.SetCurrentView(workspace);
        }

        public void Handle(OpenAddCustomerWorkspaceMessage message)
        {
            var model = AddWorkspace<AddCustomerViewModel>();
            workspaces.SetCurrentView(model);
        }

        public void Handle(CloseWorkspaceMessage message)
        {
            workspaces.Remove(message.WorkspaceToClose);
            workspaces.SetCurrentView(workspaces[0]);
        }
    }
}