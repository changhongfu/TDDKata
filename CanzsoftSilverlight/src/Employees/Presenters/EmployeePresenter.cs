using DemoApp.Shared.Messaging;
using DemoApp.Shared.Views;
using Employees.Models;
using Employees.Views;
using Microsoft.Practices.Composite.Events;
using Microsoft.Practices.Composite.Regions;
using Microsoft.Practices.Unity;

namespace Employees.Presenters
{
    public class EmployeePresenter
    {
        private readonly IModuleMenuItemView _menuItemView;
        private readonly IEmployeeListView _employeeListView;

        private readonly IUnityContainer _container;
        private readonly IRegionManager _regionManager;

        public EmployeePresenter(IUnityContainer container, IModuleMenuItemView menuItemView, IEmployeeListView employeeListView)
        {
            _container = container;
            _menuItemView = menuItemView;
            _employeeListView = employeeListView;
            _regionManager = _container.Resolve<IRegionManager>();

            var eventAggregator = _container.Resolve<IEventAggregator>();
            eventAggregator.GetEvent<OpenEmployeeEvent>().Subscribe(OpenEmployeeDetails);
        }

        public void InitialiseView()
        {
            _regionManager.RegisterViewWithRegion("MainMenuRegion", () => _menuItemView);
            _regionManager.RegisterViewWithRegion("WorkspaceRegion", () => _employeeListView);
            _regionManager.Regions["WorkspaceRegion"].Deactivate(_employeeListView);

            _menuItemView.Clicked += (sender, args) => OpenEmployeeList();
            _employeeListView.EmployeeSelected += (sender, args) => OpenEmployeeDetails(args.Item);
        }

        private void OpenEmployeeList()
        {
            _regionManager.Regions["WorkspaceRegion"].Activate(_employeeListView);
            _employeeListView.SetEmployees(new Employee[]
                                               {
                                                   new Employee {FullName = "Jane Smith"},
                                                   new Employee {FullName = "Jack Smith"}
                                               });
        }

        public void OpenEmployeeDetails(int employeeId)
        {
            var presenter = _container.Resolve<EmployeeDetailsPresenter>();
            presenter.ShowView();
        }
    }
}