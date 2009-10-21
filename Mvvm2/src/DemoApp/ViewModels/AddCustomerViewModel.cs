using Quark.Tools.Ioc;
using Quark.Tools.Wpf.ViewModel;

namespace DemoApp.ViewModels
{
    public class AddCustomerViewModel : WorkspaceViewModel
    {
        public AddCustomerViewModel(IIocContainer iocContainer) : base(iocContainer)
        {
            DisplayName = "Add Customer";
        }
    }
}