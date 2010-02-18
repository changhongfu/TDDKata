using System;
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

        public EmployeeInfo[] _employees;

        public EmployeeViewModel() : this(new EmployeeService())
        {
        }

        public EmployeeViewModel(IEmployeeService service)
        {
            _service = service;
            LoadEmployeesCommand = new DelegateCommand<object>(p => LoadEmployees(), p => true);
        }

        private void LoadEmployees()
        {
            new AsyncRunner()
                .Do((sender, args) => args.Result = _service.GetEmployees())
                .WhenComplete((sender, args) => Employees = (EmployeeInfo[])args.Result)
                .RunAsync();
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

        public ICommand LoadEmployeesCommand { get; private set; }
    }
}