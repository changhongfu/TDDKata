using System.Windows;
using Quark.Tools.Wpf.ViewModel;

namespace Quark.Tools.Wpf.View
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