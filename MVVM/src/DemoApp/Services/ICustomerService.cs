using System.Collections.Generic;
using DemoApp.Models;

namespace DemoApp.Services
{
    public interface ICustomerService
    {
        void SaveCustmer(Customer customer);
        IEnumerable<Customer> GetAllCustomers();
    }
}