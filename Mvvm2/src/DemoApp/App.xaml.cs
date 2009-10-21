using System.Windows;
using DemoApp.ViewModels;
using DemoApp.Views;
using Microsoft.Practices.Unity;
using Quark.Tools.Ioc;
using Quark.Tools.Wpf.Events;

namespace DemoApp
{
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            IUnityContainer container = new UnityContainer();
            var iocConatiner = new UnityIocContainer(container);
            container.RegisterInstance<IIocContainer>(iocConatiner);
            container.RegisterInstance<IEventAggregator>(new EventAggregator());

            var window = new ShellView(new ShellViewModel(iocConatiner));
            window.Show();
        }
    }
}
