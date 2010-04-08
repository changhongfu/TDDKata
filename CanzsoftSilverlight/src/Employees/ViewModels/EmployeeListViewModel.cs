using System;
using System.Windows.Input;
using DemoApp.Shared.Extensions;
using DemoApp.Shared.Messaging;
using DemoApp.Shared.Views;
using Microsoft.Practices.Composite.Events;
using Microsoft.Practices.Composite.Presentation.Commands;
using Microsoft.Practices.Composite.Regions;
using Microsoft.Practices.Unity;

namespace Employees.ViewModels
{
    public class EmployeeListViewModel
    {
        private readonly IUnityContainer _container;
        private readonly IRegionManager _regionManager;
        private readonly IEventAggregator _eventAggregator;

        public EmployeeListViewModel(IUnityContainer container)
        {
            _container = container;
            _regionManager = _container.Resolve<IRegionManager>();
            _eventAggregator = _container.Resolve<IEventAggregator>();

            _eventAggregator.GetEvent<OpenEmployeeEvent>().Subscribe(OpenEmployee);

            OpenEmployeeDetailsCommand = new DelegateCommand<int>(OpenEmployee);
        }

        public void OpenEmployee(int employeeId)
        {
            var viewModel = new EmployeeDetailsViewModel();
            var view = _container.Resolve<IModuleView>("EmployeeDetails");
           // view.ViewModel = viewModel;

            _regionManager.AddToRegion("WorkspaceRegion", view);
            _regionManager.Regions["WorkspaceRegion"].Activate(view);

        }

        public ICommand OpenEmployeeDetailsCommand { get; set; }
    }
}