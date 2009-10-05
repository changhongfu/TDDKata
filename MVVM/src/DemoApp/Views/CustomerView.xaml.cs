using DemoApp.ViewModels;
using Quark.Tools.Mvvm;

namespace DemoApp.Views
{
    public partial class CustomerView : ViewUserControl<CustomerViewModel>
    {
        public CustomerView()
        {
            InitializeComponent();
        }
    }
}