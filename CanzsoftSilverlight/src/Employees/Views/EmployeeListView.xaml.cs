using System;
using System.Windows;
using System.Windows.Controls;
using DemoApp.Shared.Events;
using Employees.Models;

namespace Employees.Views
{
    public partial class EmployeeListView : IEmployeeListView
    {
        public event EventHandler<EventArgs<int>> EmployeeSelected;
        
        public EmployeeListView()
        {
            InitializeComponent();
        }

        public void SetEmployees(Employee[] employees)
        {
            employeeListBox.DataContext = employees;
        }


        private void EmployeeOnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var handler = EmployeeSelected;
            if (handler != null)
            {
                handler(this, new EventArgs<int>(1));
            }
        }
    }
}
