using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DemoApp.Models;
using Quark.Tools.Mvvm;

namespace DemoApp.ViewModels
{
    public class AllCustomersViewModel : WorkspaceViewModel
    {
        private readonly ObservableCollection<CustomerViewModel> customers;

        public AllCustomersViewModel()
        {
            customers = new ObservableCollection<CustomerViewModel>();
        }

        public ObservableCollection<CustomerViewModel> Customers
        {
            get { return customers; }
        }
    }
}