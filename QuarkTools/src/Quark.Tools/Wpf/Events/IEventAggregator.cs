using System;

namespace Quark.Tools.Wpf.Events
{
    public interface IEventAggregator
    {
        void SendMessage<T>(T message) where T : IMessage;

        void AddListener<T>(Action<T> action) where T : IMessage;
    }
}