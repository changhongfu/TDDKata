using System.Windows;
using System.Windows.Controls;
using Canzsoft.Silverlight.TestApp.ViewModels;

namespace Canzsoft.Silverlight.TestApp.Views
{
    public partial class EmployeeForm 
    {
        public EmployeeForm()
        {
            InitializeComponent();

            ViewModel = new EmployeeViewModel();
        }

        private EmployeeViewModel ViewModel
        {
            get { return DataContext as EmployeeViewModel; }
            set { DataContext = value; }
        }

        private void EmployeeButtonOnClick(object sender, RoutedEventArgs e)
        {
            ViewModel.LoadEmployeeDetailsCommand.Execute(((Button)sender).Tag);
        }
    }
}


