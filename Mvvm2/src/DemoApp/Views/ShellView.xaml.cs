using DemoApp.ViewModels;

namespace DemoApp.Views
{
    public partial class ShellView
    {


        public ShellView(ShellViewModel viewModel)
        {
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}