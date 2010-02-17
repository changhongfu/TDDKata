using System;
using Canzsoft.Silverlight.TestApp.Models;

namespace Canzsoft.Silverlight.TestApp.Services
{
    public interface IEmployeeService 
    {
        EmployeeInfo[] GetEmployees();

        EmployeeInfo GetEmployee(Guid id);
    }
}