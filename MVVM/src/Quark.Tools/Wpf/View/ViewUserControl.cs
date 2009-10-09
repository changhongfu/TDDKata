using System.Windows.Controls;
using Quark.Tools.Wpf.ViewModel;

namespace Quark.Tools.Wpf.View
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