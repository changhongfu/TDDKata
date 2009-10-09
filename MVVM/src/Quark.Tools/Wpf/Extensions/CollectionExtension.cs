using System.Collections.Generic;
using System.Windows.Data;

namespace Quark.Tools.Mvvm.Extensions
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