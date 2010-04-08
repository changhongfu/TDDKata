using System.Windows;
using DemoApp.Shared.Views;
using Timesheets.ViewModel;

namespace Timesheets.Views
{
    public partial class TimesheetList : IModuleView
    {
        public static int _screenId = 1;

        public TimesheetList()
        {
            InitializeComponent();

            _txtScreenId.Text = _screenId++.ToString();
        }

        public TimesheetListViewModel ViewModel
        {
            get { return DataContext as TimesheetListViewModel; }
            set { DataContext = value; }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.OpenEmployeeCommand.Execute(1);
        }
    }
}
