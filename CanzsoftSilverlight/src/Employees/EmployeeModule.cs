using System;
using Employees.Views;
using Microsoft.Practices.Composite.Modularity;
using Microsoft.Practices.Composite.Regions;
using Microsoft.Practices.Unity;

namespace Employees
{
    public class EmployeeModule : IModule
    {
        private readonly IUnityContainer _container;
        private readonly IRegionManager _regionManager;

        public EmployeeModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            RegisterViewsAndServices();

            _regionManager.RegisterViewWithRegion("MainMenuRegion", () => new EmployeeMenu());
            _regionManager.RegisterViewWithRegion("WorkspaceRegion", () => new EmployeeList());
        }

        protected void RegisterViewsAndServices()
        {
            
        }
    }
}