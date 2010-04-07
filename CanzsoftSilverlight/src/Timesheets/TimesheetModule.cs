using Microsoft.Practices.Composite.Modularity;
using Microsoft.Practices.Composite.Regions;
using Microsoft.Practices.Unity;
using Timesheets.Views;

namespace Timesheets
{
    public class TimesheetModule : IModule
    {
        private readonly IUnityContainer _container;
        private readonly IRegionManager _regionManager;

        public TimesheetModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            RegisterViewsAndServices();

            _regionManager.RegisterViewWithRegion("MainMenuRegion", () => new TimesheetMenu());
        }

        protected void RegisterViewsAndServices()
        {
            
        }
    }
}