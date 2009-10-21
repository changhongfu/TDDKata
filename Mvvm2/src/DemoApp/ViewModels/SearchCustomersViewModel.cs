using DemoApp.Models;
using Quark.Tools.Ioc;
using Quark.Tools.Wpf.ViewModel;

namespace DemoApp.ViewModels
{
    public class SearchCustomerViewModel : WorkspaceViewModel
    {
        public SearchCustomerViewModel(IIocContainer iocContainer) : base(iocContainer)
        {
            DisplayName = "Search Customers";
            SearchCriteriaViewModel = CreateViewModel<SearchCriteriaViewModel>();
            SearchCriteriaViewModel.SetBoundType<Customer>();
        }

        public SearchCriteriaViewModel SearchCriteriaViewModel { get; set; }
    }
}