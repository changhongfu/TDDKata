using System.Windows;
using DemoApp.Shared.Views;
using Employees.ViewModels;

namespace Employees.Views
{
    public partial class EmployeeList : IModuleView
    {
        public EmployeeList()
        {
            InitializeComponent();
        }

        public EmployeeListViewModel ViewModel
        {
            get { return DataContext as EmployeeListViewModel; }
            set { DataContext = value; }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.OpenEmployeeDetailsCommand.Execute(1);
        }
    }
}
