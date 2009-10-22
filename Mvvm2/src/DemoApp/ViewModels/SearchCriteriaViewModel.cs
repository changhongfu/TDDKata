using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Input;
using DemoApp.Messages;
using Quark.Tools.Ioc;
using Quark.Tools.Wpf.Command;
using Quark.Tools.Wpf.Extension;
using Quark.Tools.Wpf.ViewModel;

namespace DemoApp.ViewModels
{
    public class SearchCriteriaViewModel : ViewModelBase
    {
        private readonly string[] DefaultConditions = new [] { "=<", ">=", "<", ">", "==", "!=" };
        private readonly string[] StringConditions = new [] { "Equals", "StartsWith", "EndsWith", "Contains" };
        private readonly List<PropertyInfo> availableProperties = new List<PropertyInfo>();
        private PropertyInfo _currentProperty;

        public SearchCriteriaViewModel(IIocContainer iocContainer) : base(iocContainer)
        {
            SearchCommand = new RelayCommand(RunSearchCommand);
        }

        private void RunSearchCommand(object obj)
        {
            Publish(new SearchCustomersMessage
                        {
                            Property = CurrentProperty,
                            Condition = CurrentCondition,
                            Value = CurrentFilterText
                        });
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
                OnPropertyChanged("CurrentProperty");
                OnPropertyChanged("AvailableConditions");
            }
        }

        public ICommand SearchCommand { get; private set; }

        public string CurrentCondition { get; set; }

        public string CurrentFilterText { get; set; }

        public void SetBoundType<T>()
        {
            var propertyNames = typeof (T).GetProperties();
            availableProperties.AddRange(propertyNames);
            CurrentProperty = availableProperties[0];
            availableProperties.WhenCurrentChanged(p => CurrentProperty = p);
            DefaultConditions.WhenCurrentChanged(c => CurrentCondition = c);
            StringConditions.WhenCurrentChanged(c => CurrentCondition = c);
        }
    }
}