namespace Quark.Tools.Wpf.Events
{
    public class Message<T> : IMessage
    {
        private readonly T dataItem;

        public Message(T dataItem)
        {
            this.dataItem = dataItem;
        }

        public T DataItem
        {
            get { return dataItem; }
        }
    }
}