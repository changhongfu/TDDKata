using System;
using System.Windows.Input;
using DemoApp.Shared.Views;

namespace Employees.Views
{
    public partial class EmployeeMenuItemView : IModuleMenuItemView
    {
        public event EventHandler Clicked;

        public EmployeeMenuItemView()
        {
            InitializeComponent();
        }

        private void Menu_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var handler = Clicked;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
}
