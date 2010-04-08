using System;
using System.Windows.Input;
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

        public EmployeeListViewModel(IUnityContainer container, IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            _container = container;
            _regionManager = regionManager;
            _eventAggregator = eventAggregator;

            _eventAggregator.GetEvent<OpenEmployeeEvent>().Subscribe(OpenEmployee);

            OpenEmployeeDetailsCommand = new DelegateCommand<int>(OpenEmployee);
        }

        public void OpenEmployee(int employeeId)
        {
            var viewModel = new EmployeeDetailsViewModel();
            var view = _container.Resolve<IModuleView>("EmployeeDetails");
           // view.ViewModel = viewModel;

            _regionManager.Regions["WorkspaceRegion"].DeactivateAll();
            _regionManager.AddToRegion("WorkspaceRegion", view);

        }

        public ICommand OpenEmployeeDetailsCommand { get; set; }
    }

    public static class RegionExtensions
    {
        public static void DeactivateAll(this IRegion region)
        {
            foreach (var v in region.Views)
            {
                region.Deactivate(v);
            }
        }
    }
}