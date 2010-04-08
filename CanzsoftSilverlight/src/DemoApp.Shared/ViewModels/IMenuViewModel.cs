using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace DemoApp.Shared.ViewModels
{
    public interface IMenuViewModel
    {
        ICommand OpenModuleCommand { get; }
        string ModuleName { get; }
        BitmapImage ModuleImage { get; }
    }
}