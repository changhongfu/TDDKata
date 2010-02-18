using Canzsoft.Silverlight.TestApp.ViewModels;

namespace Canzsoft.Silverlight.TestApp.Views
{
    public partial class EmployeeForm 
    {
        public EmployeeForm()
        {
            InitializeComponent();

            this.DataContext = new EmployeeViewModel();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
}


