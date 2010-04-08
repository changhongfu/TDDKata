using DemoApp.Shared.Views;
using Employees.Presenters;
using Employees.Views;
using Microsoft.Practices.Composite.Modularity;
using Microsoft.Practices.Unity;

namespace Employees
{
    public class EmployeeModule : IModule
    {
        private readonly IUnityContainer _container;


        public EmployeeModule(IUnityContainer container)
        {
            _container = container;
        }

        public void Initialize()
        {
            RegisterViewsAndServices();

            var presenter = _container.Resolve<EmployeePresenter>();
            presenter.InitialiseView();
        }

        protected void RegisterViewsAndServices()
        {
            _container.RegisterType<IModuleMenuItemView, EmployeeMenuItemView>();
            _container.RegisterType<IEmployeeListView, EmployeeListView>();
            _container.RegisterType<IEmployeeDetailsView, EmployeeDetailsView>();
        }
    }
}