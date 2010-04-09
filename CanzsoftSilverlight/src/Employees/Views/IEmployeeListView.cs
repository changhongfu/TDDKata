using System;
using DemoApp.Shared.Events;
using Employees.Models;

namespace Employees.Views
{
    public interface IEmployeeListView
    {
        event EventHandler<EventArgs<int>> EmployeeSelected;
        void SetEmployees(Employee[] employees);
    }
}