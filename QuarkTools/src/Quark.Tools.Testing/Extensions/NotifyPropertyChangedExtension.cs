using System;
using System.ComponentModel;
using NUnit.Framework;

namespace Quark.Tools.Testing.Extensions
{
    public static class NotifyPropertyChangedExtension
    {
        public static void AssertEventWasRaised<T>(this T obj, string propertyName, Action<T> action) where T : INotifyPropertyChanged
        {
            bool raised = false;
            obj.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == propertyName)
                {
                    raised = true;
                }
            };
            action(obj);
            Assert.IsTrue(raised, "PropertyChanged event is not raised while change property: ." + propertyName);
        }
    }
}