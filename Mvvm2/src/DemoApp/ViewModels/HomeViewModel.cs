using Quark.Tools.Wpf.ViewModel;

namespace DemoApp.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public string DisplayName { get { return "Home"; } }
        public bool IsCloseable { get { return false; } }

    }
}