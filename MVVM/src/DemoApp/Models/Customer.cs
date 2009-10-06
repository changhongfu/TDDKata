using System;

namespace DemoApp.Models
{
    public class Customer
    {
        public string Email { get; set; }

        public Customer()
        {
            FirstName = String.Empty;
            LastName = String.Empty;
            Email = String.Empty;
            Type = CustomerType.Person;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public CustomerType Type { get; set; }

        public decimal TotalSales { get; set; }
    }
}