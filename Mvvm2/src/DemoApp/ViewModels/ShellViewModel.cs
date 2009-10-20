using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using DemoApp.Messages;
using Quark.Tools.Extensions;
using Quark.Tools.Wpf.Events;
using Quark.Tools.Wpf.Extension;
using Quark.Tools.Wpf.ViewModel;

namespace DemoApp.ViewModels
{
    public class ShellViewModel : ViewModelBase
    {
        private ObservableCollection<ViewModelBase> workspaces;

        public ShellViewModel() : this(EventAggregator.Instance)
        {
        }

        public ShellViewModel(IEventAggregator eventAggregator)
        {
            workspaces = new ObservableCollection<ViewModelBase> { new HomeViewModel() };
            eventAggregator.AddListener<OpenSearchCustomerWorkspaceMessage>(ShowSearchCustomers);
            eventAggregator.AddListener<CloseWorkspaceMessage>(m => CloseWorkspace(m.WorkspaceToClose));
        }

        private void CloseWorkspace(ViewModelBase viewModel)
        {
            workspaces.Remove(viewModel);
            workspaces.SetCurrentView(workspaces[0]);
        }

        private void ShowSearchCustomers(OpenSearchCustomerWorkspaceMessage obj)
        {
            var model = workspaces.FindOrCreate<SearchCustomerViewModel, ViewModelBase>();
            workspaces.SetCurrentView(model);
        }

        public ObservableCollection<ViewModelBase> Workspaces
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
    }
}