using DemoApp.ViewModels;
using Quark.Tools.Wpf.View;

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