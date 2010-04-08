using System.Windows;
using Employees;
using Microsoft.Practices.Composite.Modularity;
using Microsoft.Practices.Composite.UnityExtensions;
using Timesheets;

namespace DemoApp
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override IModuleCatalog GetModuleCatalog()
        {
            var catalog = new ModuleCatalog();
            catalog.AddModule(typeof (EmployeeModule));
            catalog.AddModule(typeof (TimesheetModule));
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
            presenter.ShowView();
            return presenter.View as DependencyObject;
        }
    }
}