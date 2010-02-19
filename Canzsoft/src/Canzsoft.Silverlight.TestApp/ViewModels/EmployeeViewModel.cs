using System;
using System.Windows;
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
        private EmployeeDetails _employeeDetails;
        private bool _isLoadingList;
        private bool _isLoadingDetails;

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
                                      .BeforeExecute(() => IsLoadingList = true)
                                      .AfterExecute(() => { Employees = commandResult.Result; IsLoadingList = false; });

            var employeeDetailsResult = new CommandResult<EmployeeDetails>();
            LoadEmployeeDetailsCommand = new DelegateCommand(p => employeeDetailsResult.Result = _service.GetEmployee((Guid)p))
                                         .ExecuteAsync()
                                         .BeforeExecute(() => IsLoadingDetails = true)
                                         .AfterExecute(() => { CurrentEmployee = employeeDetailsResult.Result; IsLoadingDetails = false; });
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

        public EmployeeDetails CurrentEmployee
        {
            get { return _employeeDetails; }
            set
            {
                _employeeDetails = value;
                OnPropertyChanged("CurrentEmployee");
 ;           }
        }

        public bool IsLoadingList
        {
            get { return _isLoadingList; }
            set
            {
                _isLoadingList = value;
                OnPropertyChanged("IsLoadingList");
            }
        }

        public bool IsLoadingDetails
        {
            get { return _isLoadingDetails; }
            set
            {
                _isLoadingDetails = value;
                OnPropertyChanged("IsLoadingDetails");
            }
        }

        public ICommand LoadEmployeesCommand { get; private set; }

        public ICommand LoadEmployeeDetailsCommand { get; private set; }
    }
}