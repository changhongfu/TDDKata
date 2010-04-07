using System.Windows;
using Microsoft.Practices.Composite.Modularity;
using Microsoft.Practices.Composite.UnityExtensions;

namespace DemoApp
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override IModuleCatalog GetModuleCatalog()
        {
            var catalog = new ModuleCatalog();
            //catalog.AddModule(typeof (MarketModule));
            return catalog;
        }

        protected override void ConfigureContainer()
        {
            Container.RegisterType<IShellView, Shell>();

            base.ConfigureContainer();
        }

        protected override DependencyObject CreateShell()
        {
            var presenter = Container.Resolve<ShellPresenter>();
            presenter.View.ShowView();
            return presenter.View as DependencyObject;
        }
    }
}