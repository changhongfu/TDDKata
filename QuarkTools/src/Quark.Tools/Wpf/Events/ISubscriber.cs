namespace Quark.Tools.Wpf.Events
{
    public interface ISubscriber<T>  where T : IMessage
    {
        void Handle(T message);
    }
}