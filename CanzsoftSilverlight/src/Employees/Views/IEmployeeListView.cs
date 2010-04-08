using System;
using DemoApp.Shared.Events;

namespace Employees.Views
{
    public interface IEmployeeListView
    {
        event EventHandler<EventArgs<int>> EmployeeSelected;
    }
}