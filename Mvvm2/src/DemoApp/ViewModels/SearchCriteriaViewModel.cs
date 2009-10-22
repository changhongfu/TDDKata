using System;
using System.Collections.Generic;
using System.Reflection;
using Quark.Tools.Ioc;
using Quark.Tools.Wpf.Extension;
using Quark.Tools.Wpf.ViewModel;

namespace DemoApp.ViewModels
{
    public class SearchCriteriaViewModel : ViewModelBase
    {
        private readonly string[] DefaultConditions = new string[] { "=<", ">=", "<", ">", "==", "!=" };
        private readonly string[] StringConditions = new string[] { "Equals", "StartsWith", "EndsWith", "Contains" };
        private readonly List<PropertyInfo> availableProperties = new List<PropertyInfo>();
        private PropertyInfo _currentProperty;

        public SearchCriteriaViewModel(IIocContainer iocContainer) : base(iocContainer)
        {
        }

        public ICollection<PropertyInfo> AvailableProperties
        {
            get { return availableProperties; }
        }

        public ICollection<string> AvailableConditions
        {
            get
            {
                if (CurrentProperty == null || CurrentProperty.PropertyType == typeof(String))
                {
                    return StringConditions;
                }
                return DefaultConditions;
            }
        }

        public PropertyInfo CurrentProperty
        {
            get
            {
                return _currentProperty;
            }
            set
            {
                _currentProperty = value;
            }
        }

        public void SetBoundType<T>()
        {
            var propertyNames = typeof (T).GetProperties();
            availableProperties.AddRange(propertyNames);
            CurrentProperty = availableProperties[0];
            availableProperties.WhenCurrentChanged(p => CurrentProperty = p);
        }
    }
}