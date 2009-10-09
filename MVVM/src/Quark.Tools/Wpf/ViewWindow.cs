using System.Windows;

namespace Quark.Tools.Mvvm
{
    public class ViewWindow<T> : Window, IView<T>  where T : ViewModelBase
    {
        public T Model
        {
            get { return DataContext as T; }
            set { DataContext = value; }
        }
    }
}