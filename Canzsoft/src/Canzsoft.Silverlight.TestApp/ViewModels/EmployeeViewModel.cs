using System.Windows.Input;
using Canzsoft.Silverlight.TestApp.Models;
using Canzsoft.Silverlight.TestApp.Services;
using Canzsoft.Silverlight.Tools;
using Canzsoft.Silverlight.Tools.Commands;

namespace Canzsoft.Silverlight.TestApp.ViewModels
{
    public class EmployeeViewModel : ViewModelBase
    {
        private readonly IEmployeeService _service;

        private EmployeeInfo[] _employees;
        private bool _isLoading;

        public EmployeeViewModel() : this(new EmployeeService())
        {
        }

        public EmployeeViewModel(IEmployeeService service)
        {
            _service = service;
           // LoadEmployeesCommand = new DelegateCommand(p => LoadEmployees());
            var commandResult = new CommandResult<EmployeeInfo[]>();
            LoadEmployeesCommand = new DelegateCommand(p => commandResult.Result = _service.GetEmployees())
                                      .ExecuteAsync()
                                      .BeforeExecute(() => IsLoading = true)
                                      .AfterExecute(() => { Employees = commandResult.Result; IsLoading = false; });
        }

        //Can also use AyncRunner do same thing, which is better?
        private void LoadEmployees()
        {
            new AsyncRunner()
                .Run((sender, args) => args.Result = _service.GetEmployees())
                .WhenComplete((sender, args) => Employees = (EmployeeInfo[])args.Result)
                .Execute();
        }

        public EmployeeInfo[] Employees
        {
            get { return _employees; }
            set
            {
                _employees = value;
                OnPropertyChanged("Employees");
            }
        }

        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                _isLoading = value;
                OnPropertyChanged("IsLoading");
            }
        }

        public ICommand LoadEmployeesCommand { get; private set; }
    }
}