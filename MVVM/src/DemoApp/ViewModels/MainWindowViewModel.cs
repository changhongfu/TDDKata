using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using System.Windows.Input;
using Quark.Tools.Mvvm;

namespace DemoApp.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IEnumerable<CommandViewModel> commands;
        private readonly ObservableCollection<WorkspaceViewModel> workspaces;

        public MainWindowViewModel()
        {
            commands = new List<CommandViewModel>
            {
                new CommandViewModel(new RelayCommand(ShowAllCustomers), "View all customers"),
                new CommandViewModel(new RelayCommand(delegate { }), "Create new customer")
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

        private void ShowAllCustomers()
        {
            var workspace = FindExisting<AllCustomersViewModel>() ?? CreateAllCustomersViewModel();

            SetActiveWorkspace(workspace);
        }

        private T FindExisting<T>() where T : WorkspaceViewModel
        {
            return Workspaces.FirstOrDefault(vm => vm is T) as T;
        }

        private AllCustomersViewModel CreateAllCustomersViewModel()
        {
            var workspace = new AllCustomersViewModel();
            Workspaces.Add(workspace);
            return workspace;
        }

        private void SetActiveWorkspace(WorkspaceViewModel workspace)
        {
            var collectionView = CollectionViewSource.GetDefaultView(Workspaces);
            if (collectionView != null)
            {
                collectionView.MoveCurrentTo(workspace);
            }
        }

    }
}