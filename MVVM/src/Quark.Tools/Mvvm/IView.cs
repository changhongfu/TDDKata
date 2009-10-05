namespace Quark.Tools.Mvvm
{
    public interface IView<T> where T : ViewModelBase
    {
        T Model { get; set; }
    }
}