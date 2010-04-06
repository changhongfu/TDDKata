using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Canzsoft.Silverlight.TestApp.Modules;
using Canzsoft.Silverlight.TestApp.ViewModels;

namespace Canzsoft.Silverlight.TestApp.Views
{
    public partial class Shell 
    {
        public Shell()
        {
            InitializeComponent();

            ViewModel = new ShellViewModel();
        }

        private ShellViewModel ViewModel
        {
            get { return DataContext as ShellViewModel; }
            set { DataContext = value; }
        }

        private void Module_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var module = ((FrameworkElement)sender).Tag as IModule;
            module.Open();
        } 
    }
}


