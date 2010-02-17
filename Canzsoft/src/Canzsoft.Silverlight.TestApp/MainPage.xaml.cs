using System.Windows;
using Canzsoft.Silverlight.TestApp.Services;
using Canzsoft.Silverlight.Tools;

namespace Canzsoft.Silverlight.TestApp
{
    public partial class MainPage 
    {
        private readonly IEmployeeService _employeeService = new EmployeeService();

        public MainPage()
        {
            InitializeComponent();
        }

        private void GetEmployeesButtonClick(object sender, RoutedEventArgs e)
        {
            new AsyncRunner()
                .Do((obj, args) => args.Result = _employeeService.GetEmployees())
                .WhenComplete((obj, args) => lbEmployees.DataContext = args.Result)
                .RunAsync();
        }
    }
}
