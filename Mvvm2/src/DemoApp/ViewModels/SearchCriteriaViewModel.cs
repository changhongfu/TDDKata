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
        private readonly List<PropertyInfo> availableProperties = new List<PropertyInfo>();
        private List<string> availableConditions = new List<string>();
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
            get { return availableConditions; }
            set
            {
                availableConditions = new List<string>(value);
                OnPropertyChanged("AvailableConditions");
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
            availableProperties.WhenCurrentChanged(p => CurrentProperty = p);
        }
    }
}