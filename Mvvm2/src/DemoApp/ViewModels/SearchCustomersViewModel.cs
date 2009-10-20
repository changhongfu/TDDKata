using Quark.Tools.Wpf.Events;
using Quark.Tools.Wpf.ViewModel;

namespace DemoApp.ViewModels
{
    public class SearchCustomerViewModel : WorkspaceViewModel
    {

        public SearchCustomerViewModel() : this(EventAggregator.Instance)
        {
        }

        public SearchCustomerViewModel(IEventAggregator eventAggregator) : base(eventAggregator)
        {
            DisplayName = "Search Customers";
        }
    }
}