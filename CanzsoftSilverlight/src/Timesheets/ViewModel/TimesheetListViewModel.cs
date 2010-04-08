using System;
using System.Windows.Input;
using DemoApp.Shared.Messaging;
using Microsoft.Practices.Composite.Events;
using Microsoft.Practices.Composite.Presentation.Commands;

namespace Timesheets.ViewModel
{
    public class TimesheetListViewModel
    {
        private readonly IEventAggregator _eventAggregator;

        public TimesheetListViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;

            OpenEmployeeCommand = new DelegateCommand<int>(SendOpenEmployeeMessage);
        }

        private void SendOpenEmployeeMessage(int employeeId)
        {
            _eventAggregator.GetEvent<OpenEmployeeEvent>().Publish(employeeId);
        }

        public ICommand OpenEmployeeCommand { get; set; }
    }
}