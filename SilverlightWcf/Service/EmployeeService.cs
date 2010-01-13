using System.Collections.Generic;
using Contract;

namespace Service
{
    public class EmployeeService : IEmployeeService
    {
        public EmployeeInfo[] LoadEmployees()
        {
            return new[]
            {
                new EmployeeInfo { Id = 1, FirstName = "Joe", LastName = "Smith", Position = "Developer" },
                new EmployeeInfo { Id = 2, FirstName = "Jane", LastName = "Smith", Position = "Designer" }
            };
        }
    }
}
