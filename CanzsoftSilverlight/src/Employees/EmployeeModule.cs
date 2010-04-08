using System;
using System.Windows.Media.Imaging;
using DemoApp.Shared.ViewModels;
using DemoApp.Shared.Views;
using Employees.ViewModels;
using Employees.Views;
using Microsoft.Practices.Composite.Events;
using Microsoft.Practices.Composite.Modularity;
using Microsoft.Practices.Composite.Regions;
using Microsoft.Practices.Unity;

namespace Employees
{
    public class EmployeeModule : IModule
    {
        private readonly IUnityContainer _container;
        private readonly IRegionManager _regionManager;

        private readonly MenuViewModel _menuViewModel;

        public EmployeeModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;

            var image = new BitmapImage(new Uri("/Employees;component/Images/employee.png", UriKind.Relative));
            _menuViewModel = new MenuViewModel(_regionManager, _container) { ModuleImage = image, ModuleName = "Employees" };
        }

        public void Initialize()
        {
            RegisterViewsAndServices();

            _regionManager.AddToRegion("MainMenuRegion", new MenuView { ViewModel = _menuViewModel });
            _regionManager.RegisterViewWithRegion("WorkspaceRegion", InitializeView);
        }

        private EmployeeList InitializeView()
        {
            var view = _container.Resolve<IModuleView>("Employees") as EmployeeList;
            view.ViewModel = new EmployeeListViewModel(_container,  _regionManager, _container.Resolve<IEventAggregator>());

            return view;
        }

        protected void RegisterViewsAndServices()
        {
            _container.RegisterType<IModuleView, EmployeeList>("Employees", new ContainerControlledLifetimeManager());
            _container.RegisterType<IModuleView, EmployeeDetails>("EmployeeDetails");
        }
    }
}