using System.Windows;

namespace DemoApp
{
    public partial class Shell : IShellView
    {
        public Shell()
        {
            InitializeComponent();
        }

        public void ShowView()
        {
            Application.Current.RootVisual = this;
        }
    }
}
