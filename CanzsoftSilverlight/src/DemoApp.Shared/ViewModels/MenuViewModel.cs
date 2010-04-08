using System.Windows.Input;
using System.Windows.Media.Imaging;
using DemoApp.Shared.Views;
using Microsoft.Practices.Composite.Presentation.Commands;
using Microsoft.Practices.Composite.Regions;
using Microsoft.Practices.Unity;

namespace DemoApp.Shared.ViewModels
{
    public class MenuViewModel : IMenuViewModel
    {
        private readonly IRegionManager _regionManager;
        private readonly IUnityContainer _container;

        public MenuViewModel(IRegionManager regionManager, IUnityContainer container)
        {
            _regionManager = regionManager;
            _container = container;
            OpenModuleCommand = new DelegateCommand<string>(OpenModule);
        }

        private void OpenModule(string moduleName)
        {
            _regionManager.Regions["WorkspaceRegion"].Activate(_container.Resolve<IModuleView>(moduleName));
        }

        public ICommand OpenModuleCommand { get; private set; }

        public string ModuleName { get; set; }

        public BitmapImage ModuleImage { get; set; }
    }
}