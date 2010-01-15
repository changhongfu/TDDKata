using System.Windows;
using SilverlightClient.Core;

//using SilverlightClient.Wcf;


namespace SilverlightClient
{
    public partial class MainPage 
    {
        private readonly ListEmployeeViewModel _viewModel;

        public MainPage()
        {
            InitializeComponent();
            _viewModel = new ListEmployeeViewModel();
            DataContext = _viewModel;
        }

        private void LoadButtonOnClick(object sender, RoutedEventArgs e)
        {
            //var proxy = new EmployeeServiceClient();
            //proxy.LoadEmployeesCompleted += RefreshEmployeeList;
            //proxy.LoadEmployeesAsync();
            _viewModel.RefreshEmployeeList();
        }

        private void RefreshEmployeeList(object sender, LoadEmployeesCompletedEventArgs e)
        {
            //var employees = e.Result;
        }
    }
}
