using System.Windows;
using WpfClient.Wcf;

namespace WpfClient
{
    public partial class Window1 
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void LoadButtonOnClick(object sender, RoutedEventArgs e)
        {
            var proxy = new EmployeeServiceClient();
            var employees = proxy.LoadEmployees();
            _textBlock1.Text = employees[0].FirstName;
            _textBlock2.Text = employees[1].FirstName;
        }
    }
}
