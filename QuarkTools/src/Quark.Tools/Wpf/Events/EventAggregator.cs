using System;
using System.Collections.Generic;
using System.Linq;
using Quark.Tools.Extensions;

namespace Quark.Tools.Wpf.Events
{
    public class EventAggregator : IEventAggregator
    {
        private Dictionary<Type, List<object>> subscribers = new Dictionary<Type, List<object>>();

        public void Publish<T>(T message) where T : IMessage
        {
            if (subscribers.ContainsKey(typeof(T)))
            {
                subscribers[typeof(T)].Select(s => (ISubscriber<T>)s).ForEach(s => s.Handle(message));
            }
        }

        public void Subscribe<T>(ISubscriber<T> subscriber) where T : IMessage
        {
            GetSubscriberList<T>().Add(subscriber);
        }

        private List<object> GetSubscriberList<T>() where T : IMessage
        {
            if (!subscribers.ContainsKey(typeof(T)))
            {
                subscribers[typeof(T)] = new List<object>();
            }
            return subscribers[typeof(T)];
        }
    }
}