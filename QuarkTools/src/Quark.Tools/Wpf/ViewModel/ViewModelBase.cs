using System;
using System.ComponentModel;
using Quark.Tools.Ioc;
using Quark.Tools.Wpf.Events;

namespace Quark.Tools.Wpf.ViewModel
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        private readonly IIocContainer iocContainer;
        private IEventAggregator eventAggregator;

        protected ViewModelBase(IIocContainer iocContainer)
        {
            this.iocContainer = iocContainer;
        }

        protected IIocContainer IocContainer
        {
            get { return iocContainer; }
        }

        protected IEventAggregator EventAggregator
        {
            get
            {
                return eventAggregator ?? 
                       (eventAggregator = IocContainer.Resolve<IEventAggregator>());
            }
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

        protected void Publish<T>(T message) where T : IMessage
        {
            EventAggregator.Publish(message);
        }

        protected void Subscribe<T>(ISubscriber<T> subscriber) where T : IMessage
        {
            EventAggregator.Subscribe(subscriber);
        }

        protected T CreateViewModel<T>() where T : ViewModelBase
        {
            return IocContainer.Resolve<T>();
        }
    }
}