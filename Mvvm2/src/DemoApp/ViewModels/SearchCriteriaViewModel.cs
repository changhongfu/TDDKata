using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Windows.Input;
using DemoApp.Messages;
using Quark.Tools.Extensions;
using Quark.Tools.Ioc;
using Quark.Tools.Wpf.Command;
using Quark.Tools.Wpf.Extension;
using Quark.Tools.Wpf.ViewModel;

namespace DemoApp.ViewModels
{
    public class SearchCriteriaViewModel : ViewModelBase
    {
        private static readonly string[] DefaultConditions = new [] { "=<", ">=", "<", ">", "==", "!=" };
        private static readonly string[] StringConditions = new [] { "Equals", "StartsWith", "EndsWith", "Contains" };

        private readonly ObservableCollection<PropertyInfo> availableProperties = new ObservableCollection<PropertyInfo>();
        private ICollection<string> availableConditions = DefaultConditions;

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
                return availableConditions;
            }
            set
            {

                availableConditions = value;
                availableConditions.WhenCurrentChanged(c => CurrentCondition = c);
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
                OnPropertyChanged("CurrentProperty");
            }
        }

        public ICommand SearchCommand { get; private set; }

        public string CurrentCondition { get; set; }

        public string CurrentFilterText { get; set; }

        public void SetBoundType<T>()
        {
            IEnumerable<PropertyInfo> properties = typeof (T).GetProperties();
            properties.ForEach(p => availableProperties.Add(p));
            
            availableProperties.WhenCurrentChanged(p =>
            {
                CurrentProperty = p;
                AvailableConditions = p.PropertyType == typeof(String) ? 
                                      new Collection<string>(StringConditions) :
                                      new Collection<string>(DefaultConditions);
            });

            CurrentProperty = availableProperties[0];
        }
    }
}