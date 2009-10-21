using System;
using System.Collections.Generic;
using System.Windows.Data;

namespace Quark.Tools.Wpf.Extension
{
    public static class CollectionExtension
    {
        public static void SetCurrentView<T>(this ICollection<T> collection, T item) 
        {
            var collectionView = CollectionViewSource.GetDefaultView(collection);
            if (collectionView != null)
            {
                collectionView.MoveCurrentTo(item);
            }
        }

        public static void WhenCurrentChanged<T>(this ICollection<T> collection, Action<T> action)
        {
            var collectionView = CollectionViewSource.GetDefaultView(collection);
            collectionView.CurrentChanged += (sender, args) => action((T)collectionView.CurrentItem);
        }
    }
}