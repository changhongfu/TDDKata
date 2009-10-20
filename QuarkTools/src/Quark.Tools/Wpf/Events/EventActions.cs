using System;
using System.Collections;
using System.Collections.Generic;

namespace Quark.Tools.Wpf.Events
{
    public class EventActions<T> : IEventActions, IEnumerable<Action<T>> where T : IMessage
    {
        private List<Action<T>> actions = new List<Action<T>>();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<Action<T>> GetEnumerator()
        {
            foreach (var action in actions)
            {
                yield return action;
            }
        }

        public void Add(Action<T> action)
        {
            actions.Add(action);
        }
    }
}