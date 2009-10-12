using System;
using System.Windows;
using System.Collections.Specialized;

namespace Quark.Tools.Wpf.Command.Behavior
{
    public class CommandBehaviorCollection 
    {
        private static readonly DependencyProperty BehaviorsProperty
            = DependencyProperty.RegisterAttached("Behaviors", typeof(BehaviorBindingCollection), typeof(CommandBehaviorCollection),
                                                          new FrameworkPropertyMetadata((BehaviorBindingCollection)null, OnBehaviorsChanged));

        private static void OnBehaviorsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var collection = d.GetValue(BehaviorsProperty) as BehaviorBindingCollection;
            
        }


        // public static readonly DependencyProperty BehaviorsProperty = BehaviorsPropertyKey.DependencyProperty;

        public static BehaviorBindingCollection GetBehaviors(DependencyObject d)
        {
            return d.GetValue(BehaviorsProperty) as BehaviorBindingCollection;
        }

        public static void SetBehaviors(DependencyObject d, BehaviorBindingCollection value)
        {
            d.SetValue(BehaviorsProperty, value);
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
}