using System;

namespace Quark.Tools
{
    public class EventArgs<T> : EventArgs
    {
        private readonly T item;

        public EventArgs(T item)
        {
            this.item = item;
        }

        public T Item
        {
            get { return item; }
        }
    }
}