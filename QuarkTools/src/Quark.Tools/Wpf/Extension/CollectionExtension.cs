using System.Collections.Generic;
using System.Windows.Data;
using Quark.Tools.Wpf.ViewModel;

namespace Quark.Tools.Wpf.Extension
{
    public static class CollectionExtension
    {
        public static void SetCurrentView<T>(this ICollection<T> collection, T item) where T : ViewModelBase
        {
            var collectionView = CollectionViewSource.GetDefaultView(collection);
            if (collectionView != null)
            {
                collectionView.MoveCurrentTo(item);
            }
        }
    }
}