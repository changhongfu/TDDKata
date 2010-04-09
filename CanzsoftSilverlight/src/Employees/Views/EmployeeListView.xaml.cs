using System;
using System.Windows.Controls;
using System.Windows.Input;
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
                var emp = (Employee)e.AddedItems[0];
                handler(this, new EventArgs<int>(emp.Id));
            }
        }

        private void AddImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
