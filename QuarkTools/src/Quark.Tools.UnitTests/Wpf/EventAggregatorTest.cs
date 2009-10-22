using System;
using Moq;
using NUnit.Framework;
using Quark.Tools.Wpf.Events;

namespace Quark.Tools.UnitTests.Wpf
{
    [TestFixture]
    public class EventAggregatorTest
    {
        [Test]
        public void SubscriberShouldReceiveMessage_WhenMessagePublished()
        {
            var mock = new Mock<ISubscriber<Message1>>();
            var eventAggregator = new EventAggregator();

            eventAggregator.Subscribe(mock.Object);
            var msg = new Message1();
            eventAggregator.Publish(msg);

            mock.Verify(s => s.Handle(msg));
        }

        [Test]
        public void SubscriberShouldNotReceiveMessageWhichItIsNotSubscribedTo()
        {
            var mock = new Mock<ISubscriber<Message1>>();
            var eventAggregator = new EventAggregator();

            eventAggregator.Subscribe(mock.Object);
            var msg = new Message2();
            eventAggregator.Publish(msg);

            mock.Verify(s => s.Handle(It.IsAny<Message1>()), Times.Never());
        }

        public class Message1 : IMessage {}
        public class Message2 : IMessage { }
    }
}