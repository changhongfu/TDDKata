using Quark.Tools.Wpf.Events;
using Quark.Tools.Wpf.ViewModel;

namespace DemoApp.ViewModels
{
    public class AddCustomerViewModel : WorkspaceViewModel
    {
        public AddCustomerViewModel() : this(EventAggregator.Instance)
        {
        }

        public AddCustomerViewModel(IEventAggregator eventAggregator) : base(eventAggregator)
        {
            DisplayName = "Add Customer";
        }
    }
}