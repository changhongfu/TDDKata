using System.Windows;
using SilverlightClient.Core;

//using SilverlightClient.Wcf;


namespace SilverlightClient
{
    public partial class MainPage 
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void LoadButtonOnClick(object sender, RoutedEventArgs e)
        {
            var proxy = new EmployeeServiceClient();
            proxy.LoadEmployeesCompleted += RefreshEmployeeList;
            proxy.LoadEmployeesAsync();
        }

        private void RefreshEmployeeList(object sender, LoadEmployeesCompletedEventArgs e)
        {
            var employees = e.Result;
            _textBlock1.Text = employees[0].FirstName;
            _textBlock2.Text = employees[1].FirstName;
        }
    }
}
