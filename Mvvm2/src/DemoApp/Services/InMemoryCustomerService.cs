using System;
using System.Collections.Generic;
using DemoApp.Models;

namespace DemoApp.Services
{
    public class InMemoryCustomerService : ICustomerService
    {
        public IEnumerable<Customer> GetCustomers()
        {
            return new []
                       {
                           new Customer
                               {
                                   CustomerId = 1,
                                   FirstName = "Jane",
                                   LastName = "Smith"
                               },
                               new Customer
                               {
                                   CustomerId = 2,
                                   FirstName = "Joe",
                                   LastName = "Smith"
                               },
                       };
        }
    }
}