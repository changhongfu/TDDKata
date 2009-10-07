using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DemoApp.Models;
using Quark.Tools.Mvvm;
using Quark.Tools.Mvvm.Extensions;

namespace DemoApp.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IEnumerable<CommandViewModel> commands;
        private readonly ObservableCollection<WorkspaceViewModel> workspaces;
        private WorkspaceViewModel currentWorkspace;

        public MainWindowViewModel()
        {
            commands = new List<CommandViewModel>
            {
                new CommandViewModel(new RelayCommand(p => ShowAllCustomers()), "View all customers"),
                new CommandViewModel(new RelayCommand(p => CreateNewCustomer()), "Create new customer")
            };
            workspaces = new ObservableCollection<WorkspaceViewModel>();
        }

        public IEnumerable<CommandViewModel> Commands
        {
            get { return commands.AsEnumerable(); }
        }

        public ObservableCollection<WorkspaceViewModel> Workspaces
        {
            get { return workspaces; }
        }

        public WorkspaceViewModel CurrentWorkspace
        {
            get { return currentWorkspace; }
            set
            {
                if (currentWorkspace != value)
                {
                    currentWorkspace = value;
                    OnPropertyChanged("CurrentWorkspace");
                }
            }
        }

        private void ShowAllCustomers()
        {
            var workspace = FindExisting<AllCustomersViewModel>() ?? CreateAllCustomersViewModel();
            Workspaces.SetCurrentView(workspace);
        }

        private AllCustomersViewModel CreateAllCustomersViewModel()
        {
            var workspace = new AllCustomersViewModel();
            workspace.RequestClose += delegate { Workspaces.Remove(workspace); };
            workspace.CustomerSelected += (sender, args) => ShowCustomerDetails(args.Item);
            Workspaces.Add(workspace);
           
            return workspace;
        }

        private void ShowCustomerDetails(Customer customer)
        {
            var workspace = FindExisting<CustomerViewModel>(customer) ?? CreateCustomerViewModel(customer);
            Workspaces.SetCurrentView(workspace);
        }

        private WorkspaceViewModel CreateCustomerViewModel(Customer customer)
        {
            var workspace = new CustomerViewModel(customer);
            workspace.RequestClose += delegate { Workspaces.Remove(workspace); };
            Workspaces.Add(workspace);

            return workspace;
        }

        private WorkspaceViewModel FindExisting<T>(Customer customer) where T : WorkspaceViewModel
        {
            return Workspaces.FirstOrDefault(vm => vm is T && ((CustomerViewModel)vm).Customer == customer) as T;
        }

        private void CreateNewCustomer()
        {
            var workspace = new CustomerViewModel();
            workspace.RequestClose += delegate { Workspaces.Remove(workspace); };
            Workspaces.Add(workspace); 
            Workspaces.SetCurrentView(workspace);
        }

        private T FindExisting<T>() where T : WorkspaceViewModel
        {
            return Workspaces.FirstOrDefault(vm => vm is T) as T;
        }
    }
}