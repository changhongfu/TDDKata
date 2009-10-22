namespace Quark.Tools.Wpf.Events
{
    public interface IEventAggregator
    {
        void Publish<T>(T message) where T : IMessage;

        void Subscribe<T>(ISubscriber<T> subscriber) where T : IMessage;
    }
}