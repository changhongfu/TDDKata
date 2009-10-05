using System.Windows.Controls;

namespace Quark.Tools.Mvvm
{
    public class ViewUserControl<T> : UserControl, IView<T> where T : ViewModelBase
    {
        public T Model
        {
            get { return DataContext as T; }
            set { DataContext = value; }
        }
    }
}