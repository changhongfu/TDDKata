using System.Windows;
using DemoApp.ViewModels;
using DemoApp.Views;

namespace DemoApp
{
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var window = new Shell(new ShellViewModel());
            window.Show();
        }
    }
}
