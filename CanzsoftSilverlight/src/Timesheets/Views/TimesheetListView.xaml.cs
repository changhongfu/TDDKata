using System;
using System.Windows;
using DemoApp.Shared.Events;

namespace Timesheets.Views
{
    public partial class TimesheetListView : ITimesheetListView
    {
        public event EventHandler<EventArgs<int>> EmployeeClicked;

        public TimesheetListView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var handler = EmployeeClicked;
            if (handler != null)
            {
                handler(this, new EventArgs<int>(1));
            }
        }
    }
}
