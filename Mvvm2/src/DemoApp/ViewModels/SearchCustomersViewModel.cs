using Quark.Tools.Ioc;
using Quark.Tools.Wpf.ViewModel;

namespace DemoApp.ViewModels
{
    public class SearchCustomerViewModel : WorkspaceViewModel
    {
        public SearchCustomerViewModel(IIocContainer iocContainer) : base(iocContainer)
        {
            DisplayName = "Search Customers";
        }
    }
}