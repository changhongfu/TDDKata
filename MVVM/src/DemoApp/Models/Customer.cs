using System;

namespace DemoApp.Models
{
    public class Customer
    {
        public Customer()
        {
            FirstName = String.Empty;
            LastName = String.Empty;
            Email = String.Empty;
            Type = CustomerType.Person;
        }

        public CustomerType Type { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public decimal TotalSales { get; set; }
    }
}