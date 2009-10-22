using System.Collections.Generic;
using DemoApp.Models;

namespace DemoApp.Services
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetCustomers();
    }
}