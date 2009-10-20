using DemoApp.ViewModels;

namespace DemoApp.Views
{
    public partial class ShellView
    {
        public ShellView() : this(new ShellViewModel())
        {
        }

        public ShellView(ShellViewModel viewModel)
        {
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}