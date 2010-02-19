using System;
using Canzsoft.Silverlight.Rpc;
using Canzsoft.Silverlight.TestApp.Messaging;
using Canzsoft.Silverlight.TestApp.Models;

namespace Canzsoft.Silverlight.TestApp.Services
{
    public class EmployeeService : IEmployeeService
    {
        public EmployeeInfo[] GetEmployees()
        {
            var proxy = new ServiceProxy();
            var response = proxy.Invoke<GetEmployeesResponse>(new GetEmployeesRequest());
            return response.Employees;
        }

        public EmployeeDetails GetEmployee(Guid id)
        {
            var proxy = new ServiceProxy();
            var response = proxy.Invoke<GetEmployeeResponse>(new GetEmployeeRequest { Id = id });
            return response.Employee;
        }
    }
}