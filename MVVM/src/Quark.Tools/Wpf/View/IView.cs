using Quark.Tools.Wpf.ViewModel;

namespace Quark.Tools.Wpf.View
{
    public interface IView<T> where T : ViewModelBase
    {
        T Model { get; set; }
    }
}