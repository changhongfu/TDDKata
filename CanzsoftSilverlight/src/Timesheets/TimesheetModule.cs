using System;
using System.Windows.Media.Imaging;
using DemoApp.Shared.ViewModels;
using DemoApp.Shared.Views;
using Microsoft.Practices.Composite.Events;
using Microsoft.Practices.Composite.Modularity;
using Microsoft.Practices.Composite.Regions;
using Microsoft.Practices.Unity;
using Timesheets.ViewModel;
using Timesheets.Views;

namespace Timesheets
{
    public class TimesheetModule : IModule
    {
        private readonly IUnityContainer _container;
        private readonly IRegionManager _regionManager;
        private readonly MenuViewModel _menuViewModel;

        public TimesheetModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
            var image = new BitmapImage(new Uri("/Timesheets;component/Images/timesheet.png", UriKind.Relative));
            _menuViewModel = new MenuViewModel(_regionManager, _container) { ModuleImage = image, ModuleName = "Timesheets" };
        }

        public void Initialize()
        {
            RegisterViewsAndServices();

            _regionManager.AddToRegion("MainMenuRegion", new MenuView { ViewModel = _menuViewModel });
            _regionManager.RegisterViewWithRegion("WorkspaceRegion", InitializeView);
        }

        private TimesheetList InitializeView()
        {
            var view = _container.Resolve<IModuleView>("Timesheets") as TimesheetList;
            view.ViewModel = new TimesheetListViewModel(_container.Resolve<IEventAggregator>());

            return view;
        }

        protected void RegisterViewsAndServices()
        {
            _container.RegisterType<IModuleView, TimesheetList>("Timesheets", new ContainerControlledLifetimeManager());
        }
    }
}