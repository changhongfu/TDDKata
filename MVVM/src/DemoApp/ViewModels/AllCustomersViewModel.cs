using System.Collections.ObjectModel;
using DemoApp.Services;

namespace DemoApp.ViewModels
{
    public class AllCustomersViewModel : WorkspaceViewModel
    {
        private readonly ObservableCollection<CustomerViewModel> customers;

        public AllCustomersViewModel() : this(new InMemoryCustomerService())
        {
            DisplayName = "All Customers";
        }

        public AllCustomersViewModel(ICustomerService service)
        {
            customers = new ObservableCollection<CustomerViewModel>();
            foreach (var customer in service.GetAllCustomers())
            {
                customers.Add(new CustomerViewModel(customer));
            }
        }

        public ObservableCollection<CustomerViewModel> Customers
        {
            get { return customers; }
        }
    }
}