using System;
using System.Windows.Input;
using DemoApp.Shared.Views;

namespace Timesheets.Views
{
    public partial class TimesheetMenuItemView : IModuleMenuItemView
    {
        public event EventHandler Clicked;

        public TimesheetMenuItemView()
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
