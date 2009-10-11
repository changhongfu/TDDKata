using System;
using System.Windows;
using System.Collections.Specialized;

namespace Quark.Tools.Wpf.Command.Behavior
{
    public class CommandBehaviorCollection
    {
        private static readonly DependencyPropertyKey BehaviorsPropertyKey
            = DependencyProperty.RegisterAttachedReadOnly("Behaviors", typeof(BehaviorBindingCollection), typeof(CommandBehaviorCollection),
                                                          new FrameworkPropertyMetadata((BehaviorBindingCollection)null));

        public static readonly DependencyProperty BehaviorsProperty = BehaviorsPropertyKey.DependencyProperty;

        public static BehaviorBindingCollection GetBehaviors(DependencyObject d)
        {
            if (d == null)
            {
                throw new InvalidOperationException("The dependency object trying to attach to is set to null");
            }

            BehaviorBindingCollection collection = d.GetValue(BehaviorsProperty) as BehaviorBindingCollection;
            if (collection == null)
            {
                collection = new BehaviorBindingCollection { Owner = d };
                SetBehaviors(d, collection);
            }
            return collection;
        }

        private static void SetBehaviors(DependencyObject d, BehaviorBindingCollection value)
        {
            d.SetValue(BehaviorsPropertyKey, value);
            INotifyCollectionChanged collection = value;
            collection.CollectionChanged += CollectionChanged;
        }

        static void CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            BehaviorBindingCollection sourceCollection = (BehaviorBindingCollection)sender;
            switch (e.Action)
            {
                    //when an item(s) is added we need to set the Owner property implicitly
                case NotifyCollectionChangedAction.Add:
                    if (e.NewItems != null)
                        foreach (BehaviorBinding item in e.NewItems)
                            item.Owner = sourceCollection.Owner;
                    break;
                    //when an item(s) is removed we should Dispose the BehaviorBinding
                case NotifyCollectionChangedAction.Remove:
                    if (e.OldItems != null)
                        foreach (BehaviorBinding item in e.OldItems)
                            item.Behavior.Dispose();
                    break;

                    //here we have to set the owner property to the new item and unregister the old item
                case NotifyCollectionChangedAction.Replace:
                    if (e.NewItems != null)
                        foreach (BehaviorBinding item in e.NewItems)
                            item.Owner = sourceCollection.Owner;

                    if (e.OldItems != null)
                        foreach (BehaviorBinding item in e.OldItems)
                            item.Behavior.Dispose();
                    break;

                    //when an item(s) is removed we should Dispose the BehaviorBinding
                case NotifyCollectionChangedAction.Reset:
                    if (e.OldItems != null)
                        foreach (BehaviorBinding item in e.OldItems)
                            item.Behavior.Dispose();
                    break;

                default:
                    break;
            }
        }
    }

    public class BehaviorBindingCollection : FreezableCollection<BehaviorBinding>
    {
        public DependencyObject Owner { get; set; }
    }
}