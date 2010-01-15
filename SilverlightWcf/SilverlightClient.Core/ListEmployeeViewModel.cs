using System.ComponentModel;
using System.Threading;
using System.Windows;
using Contract;

namespace SilverlightClient.Core
{
    public class ListEmployeeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly IAsyncRunner _asyncRunner;

        private EmployeeInfo[] _employees;
        private Visibility _employeeListVisibility;
        private Visibility _loadIndictorVisibility;

        public ListEmployeeViewModel()
        {
            _asyncRunner = new AsyncRunner();

            _employees = new[]
            {
                new EmployeeInfo { Id = 1, FirstName = "Jack", LastName = "Smith", Position = "Developer" },
                new EmployeeInfo { Id = 2, FirstName = "James", LastName = "Smith", Position = "Designer" }
            };

            _employeeListVisibility = Visibility.Visible;
            _loadIndictorVisibility = Visibility.Collapsed;
        }

        public void RefreshEmployeeList()
        {
            EmployeeListVisibility = Visibility.Collapsed;
            LoadIndictorVisibility = Visibility.Visible;

            _asyncRunner.Do(ReloadData)
                        .WhenComplete(ReloadEmployeeList)
                        .RunAsync();
        }

        public EmployeeInfo[] Employees
        {
            get { return _employees; }
            set 
            { 
                _employees = value;
                RaisePropertyChangedEvent("Employees");
            }
        }

        public Visibility EmployeeListVisibility
        {
            get { return _employeeListVisibility; }
            set
            {
                _employeeListVisibility = value;
                RaisePropertyChangedEvent("EmployeeListVisibility");
            }
        }

        public Visibility LoadIndictorVisibility
        {
            get { return _loadIndictorVisibility; }
            set
            {
                _loadIndictorVisibility = value;
                RaisePropertyChangedEvent("LoadIndictorVisibility");
            }
        }

        private void RaisePropertyChangedEvent(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void ReloadData(object sender, DoWorkEventArgs e)
        {
            e.Result = new MyEmployeeService().LoadEmployee();
        }

        private void ReloadEmployeeList(object sender, RunWorkerCompletedEventArgs e)
        {
            EmployeeListVisibility = Visibility.Visible;
            LoadIndictorVisibility = Visibility.Collapsed;
            Employees = e.Result as EmployeeInfo[];
        }
    }

    public class MyEmployeeService
    {
        public EmployeeInfo[] LoadEmployee()
        {
            Thread.Sleep(5000);
            return new[]
            {
                new EmployeeInfo { Id = 1, FirstName = "Joe", LastName = "Smith", Position = "Developer" },
                new EmployeeInfo { Id = 2, FirstName = "Jane", LastName = "Smith", Position = "Designer" }
            }; 
        }
    }

}