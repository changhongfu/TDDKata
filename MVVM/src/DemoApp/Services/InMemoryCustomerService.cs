using System.Collections.Generic;
using System.Linq;
using DemoApp.Models;

namespace DemoApp.Services
{
    public class InMemoryCustomerService : ICustomerService
    {
        #region Initial Data
        private static readonly List<Customer> Customers = new List<Customer>
        {
            new Customer
            {
               LastName = "Smith",
               FirstName = "Josh",
               Type = CustomerType.Person,
               Email = "josh@contoso.com",
               TotalSales = 32132.92m
            },
            new Customer
            {
               LastName = "Bujak",
               FirstName = "Greg",
               Type = CustomerType.Person,
               Email = "greg@contoso.com",
               TotalSales = 9848.06m
            },
            new Customer
            {
               LastName = "Crafton",
               FirstName = "Jim",
               Type = CustomerType.Person,
               Email = "crafton@contoso.com",
               TotalSales = 6132.34m
            },
            new Customer
            {
                LastName="Nolan" ,     
               Type = CustomerType.Person,
                FirstName="Jordan",   
                Email="jordan@contoso.com",  
                TotalSales=12993.01m
            },
            new Customer
            {
                LastName="Hinkson" ,   
                FirstName="Grant",   
                Type = CustomerType.Person,
                Email="hinkson@contoso.com", 
                TotalSales=4322.81m
            },
            new Customer
            {
                LastName="Shifflett" ,   
                FirstName="Karl",   
                Type = CustomerType.Person,
                Email="kdawg@contoso.com", 
                TotalSales=8821.87m
            },
            new Customer
            {
                LastName="Walker" ,   
                FirstName="Wilfred",   
                Type = CustomerType.Person,
                Email="will@contoso.com", 
                TotalSales=3509.37m
            },
            new Customer
            {
                LastName="McCort" ,   
                FirstName="Denise",   
                Type = CustomerType.Person,
                Email="denise@contoso.com", 
                TotalSales=2222.05m
            },

            new Customer
            {
                LastName="" ,   
                FirstName="Alfreds Futterkiste",   
                Type = CustomerType.Company,
                Email="maria@contoso.com", 
                TotalSales=8832.16m
            },
            new Customer
            {
                LastName="" ,   
                FirstName="Eastern Connection",   
                Type = CustomerType.Company,
                Email="ann@contoso.com", 
                TotalSales=12831.73m
            },
            new Customer
            {
                LastName="" ,   
                FirstName="Hanari Carnes",   
                Type = CustomerType.Company,
                Email="alex@contoso.com", 
                TotalSales=473764.02m
            },
            new Customer
            {
                LastName="" ,   
                FirstName="Königlich Essen",   
                Type = CustomerType.Company,
                Email="philip@contoso.com", 
                TotalSales=28112.50m
            }
        };
        #endregion

        public void SaveCustmer(Customer customer)
        {
            Customers.Add(customer);
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return Customers.AsEnumerable();
        }
    }
}