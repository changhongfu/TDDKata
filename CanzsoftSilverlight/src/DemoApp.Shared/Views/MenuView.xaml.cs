using System.Windows.Input;
using DemoApp.Shared.ViewModels;

namespace DemoApp.Shared.Views
{
    public partial class MenuView 
    {
        public MenuView()
        {
            InitializeComponent();
        }

        public IMenuViewModel ViewModel
        {
            get { return DataContext as IMenuViewModel; }
            set { DataContext = value; }
        }

        private void Menu_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ViewModel.OpenModuleCommand.Execute(ViewModel.ModuleName);
        }
    }
}
