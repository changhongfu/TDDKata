using DemoApp.ViewModels;

namespace DemoApp.Views
{
    public partial class Shell
    {
        public Shell() : this(new ShellViewModel())
        {
        }

        public Shell(ShellViewModel viewModel)
        {
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}