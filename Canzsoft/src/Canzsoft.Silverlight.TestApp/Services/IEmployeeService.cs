using System;
using Canzsoft.Silverlight.TestApp.Models;

namespace Canzsoft.Silverlight.TestApp.Services
{
    public interface IEmployeeService 
    {
        EmployeeInfo[] GetEmployees();

        EmployeeDetails GetEmployee(Guid id);
    }
}