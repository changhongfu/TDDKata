using System;
using System.ComponentModel;
using Quark.Tools.Wpf.Events;

namespace Quark.Tools.Wpf.ViewModel
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly IEventAggregator eventAggregator;

        protected ViewModelBase() : this(EventAggregator.Instance)
        {
        }

        protected ViewModelBase(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }

        protected void PublishMessage<T>(T message) where T : IMessage
        {
            eventAggregator.SendMessage(message);
        }

        protected void SubscribeToMessage<T>(Action<T> action) where T : IMessage
        {
            eventAggregator.AddListener(action);
        }
    }
}