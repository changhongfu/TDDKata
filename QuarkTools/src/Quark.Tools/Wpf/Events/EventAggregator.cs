using System;
using System.Collections.Generic;

namespace Quark.Tools.Wpf.Events
{
    public class EventAggregator : IEventAggregator
    {
        //Should replace this by IOC
        public static readonly  EventAggregator Instance = new EventAggregator();


        private Dictionary<Type, IEventActions> eventActions = new Dictionary<Type, IEventActions>();



        public void SendMessage<T>(T message) where T : IMessage
        {
            foreach (var action in GetEventActions<T>())
            {
                action(message);
            }
        }

        public void AddListener<T>(Action<T> action) where T : IMessage
        {
            GetEventActions<T>().Add(action);
        }

        private EventActions<T> GetEventActions<T>() where T : IMessage
        {
            if (!eventActions.ContainsKey(typeof(T)))
            {
                eventActions[typeof(T)] = new EventActions<T>();
            }
            return eventActions[typeof(T)] as EventActions<T>;
        }
    }
}