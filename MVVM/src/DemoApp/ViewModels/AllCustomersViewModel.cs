using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using DemoApp.Models;
using DemoApp.Services;
using Quark.Tools;
using Quark.Tools.Mvvm;

namespace DemoApp.ViewModels
{
    public class AllCustomersViewModel : WorkspaceViewModel
    {
        public event EventHandler<EventArgs<Customer>> CustomerSelected;

        private readonly ObservableCollection<CustomerViewModel> customers;

        public AllCustomersViewModel() : this(new InMemoryCustomerService())
        {
        }

        public AllCustomersViewModel(ICustomerService service)
        {
            customers = new ObservableCollection<CustomerViewModel>();
            foreach (var customer in service.GetAllCustomers())
            {
                customers.Add(new CustomerViewModel(customer));
            }
            SelectCustomerCommand = new RelayCommand(OnCustomerSelected);
        }

        public override string DisplayName
        {
            get { return "All Customers"; }
        }

        public ObservableCollection<CustomerViewModel> Customers
        {
            get { return customers; }
        }

        public ICommand SelectCustomerCommand { get; set; }

        private void OnCustomerSelected(object selected)
        {
            var viewModel = (CustomerViewModel)selected;
            var handler = CustomerSelected;
            if (handler != null)
            {
                handler(this, new EventArgs<Customer>(viewModel.Customer));
            }
        }
    }
}