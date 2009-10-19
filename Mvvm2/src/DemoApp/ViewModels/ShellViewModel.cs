using System.Collections.ObjectModel;
using Quark.Tools.Wpf.ViewModel;

namespace DemoApp.ViewModels
{
    public class ShellViewModel : ViewModelBase
    {
        private ObservableCollection<ViewModelBase> workspaces;

        public ShellViewModel()
        {
            workspaces = new ObservableCollection<ViewModelBase> { new HomeViewModel() };
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