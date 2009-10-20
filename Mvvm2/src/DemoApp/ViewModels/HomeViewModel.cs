using System.Windows.Input;
using DemoApp.Messages;
using Quark.Tools.Wpf.Command;
using Quark.Tools.Wpf.Events;
using Quark.Tools.Wpf.ViewModel;

namespace DemoApp.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly ICommand openSearchCommand;
        private readonly IEventAggregator eventAggregator;



        public HomeViewModel() : this(EventAggregator.Instance)
        {
            
        }

        public HomeViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
            openSearchCommand = new RelayCommand(delegate { eventAggregator.SendMessage(new OpenSearchCustomerWorkspaceMessage()); });
        }

        public string DisplayName { get { return "Home"; } }

        public bool IsCloseable { get { return false; } }

        public ICommand OpenSearchCommand
        {
            get { return openSearchCommand; }
        }
    }
}