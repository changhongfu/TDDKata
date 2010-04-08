using System;
using System.Windows;
using DemoApp.Shared.Events;

namespace Employees.Views
{
    public partial class EmployeeListView : IEmployeeListView
    {
        public event EventHandler<EventArgs<int>> EmployeeSelected;

        public EmployeeListView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var handler = EmployeeSelected;
            if (handler != null)
            {
                handler(this, new EventArgs<int>(1));
            }
        }
    }
}
