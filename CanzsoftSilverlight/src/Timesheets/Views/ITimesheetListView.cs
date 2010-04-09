using System;
using DemoApp.Shared.Events;

namespace Timesheets.Views
{
    public interface ITimesheetListView
    {
        event EventHandler<EventArgs<int>> EmployeeClicked;
    }
}