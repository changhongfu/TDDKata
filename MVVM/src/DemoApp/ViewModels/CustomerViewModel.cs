using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using DemoApp.Models;
using DemoApp.Services;
using Quark.Tools;
using Quark.Tools.Mvvm;

namespace DemoApp.ViewModels
{
    public class CustomerViewModel : WorkspaceViewModel
    {
        private readonly ICustomerService service;
        private readonly ICommand saveCommand;
        private readonly Customer customer;
        private bool isNewCustomer;

        public CustomerViewModel() : this(new InMemoryCustomerService())
        {
        }

        public CustomerViewModel(Customer customer) : this(customer, new InMemoryCustomerService())
        {
        }

        public CustomerViewModel(ICustomerService service)
        {
            this.service = service;
            isNewCustomer = true;
            customer = new Customer
            {
                FirstName = String.Empty,
                LastName = String.Empty,
                Email = String.Empty
            };
            saveCommand = new RelayCommand(p => Save(), p => CanSave());
        }

        public CustomerViewModel(Customer customer, ICustomerService service)
        {
            this.service = service;
            isNewCustomer = false;
            this.customer = customer;
            saveCommand = new RelayCommand(p => Save(), p => CanSave());
        }

        public Customer Customer
        {
            get { return customer; }
        }

        public string FirstName
        {
            get { return customer.FirstName; }
            set
            {
                if (customer.FirstName != value)
                {
                    customer.FirstName = value;
                    OnPropertyChanged("FirstName");
                }
            }
        }

        public string LastName
        {
            get { return customer.LastName; }
            set
            {
                if (customer.LastName != value)
                {
                    customer.LastName = value;
                    OnPropertyChanged("LastName");
                }
            }
        }

        public string Email
        {
            get { return customer.Email; }
            set
            {
                if (customer.Email != value)
                {
                    customer.Email = value;
                    OnPropertyChanged("Email");
                }
            }
        }

        public string Type
        {
            get { return customer.Type.ToString();  }
            set
            {
                var type = Enum<CustomerType>.Parse(value);
                if (type != customer.Type)
                {
                    customer.Type = type;
                    OnPropertyChanged("Type");
                }
            }
        }

        public override string DisplayName
        {
            get
            {
                return isNewCustomer ? "New Customer" :
                       customer.Type == CustomerType.Company ? FirstName :
                       FirstName + " " + LastName;
            }
        }

        public decimal TotalSales
        {
            get { return customer.TotalSales;  }
        }

        public IEnumerable<string> CustomerTypes
        {
            get { return Enum<CustomerType>.GetNames().AsEnumerable(); }
        }

        public ICommand SaveCommand
        {
            get { return saveCommand; }
        }

        private bool CanSave()
        {
            return true;
        }

        private void Save()
        {
            service.SaveCustmer(customer);
        }
    }
}