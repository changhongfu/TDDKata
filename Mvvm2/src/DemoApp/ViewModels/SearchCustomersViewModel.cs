using System;
using System.Collections.Generic;
using DemoApp.Messages;
using DemoApp.Models;
using DemoApp.Services;
using Quark.Tools.Ioc;
using Quark.Tools.Wpf.Events;
using Quark.Tools.Wpf.ViewModel;

namespace DemoApp.ViewModels
{
    public class SearchCustomerViewModel : WorkspaceViewModel, ISubscriber<SearchCustomersMessage>
    {
        private ICustomerService customerService;
        private IEnumerable<Customer> matchedCustomers;

        public SearchCustomerViewModel(IIocContainer iocContainer) : base(iocContainer)
        {
            customerService = IocContainer.Resolve<ICustomerService>();
            DisplayName = "Search Customers";
            SearchCriteriaViewModel = CreateViewModel<SearchCriteriaViewModel>();
            SearchCriteriaViewModel.SetBoundType<Customer>();
            Subscribe(this);
        }

        public SearchCriteriaViewModel SearchCriteriaViewModel { get; set; }

        public IEnumerable<Customer> MatchedCustomers
        {
            get { return matchedCustomers;  }
            set
            {
                matchedCustomers = value;
                OnPropertyChanged("MatchedCustomers");
            }
        }

        public void Handle(SearchCustomersMessage message)
        {
            MatchedCustomers = customerService.GetCustomers();
        }
    }
}