using System;
using Moq;
using NUnit.Framework;
using Quark.Tools.Wpf.Events;
using Quark.Tools.Wpf.ViewModel;

namespace Quark.Tools.UnitTests.Wpf
{
    [TestFixture]
    public class ViewModelBaseTest
    {
        [Test]
        public void TestViewModelBase_HasPropertyChangedEvent()
        {
            var model = new TestViewModel();
            model.PropertyChanged += delegate { };
        }

        [Test]
        public void Workspace_CanPublishMessage()
        {
            var mock = new Mock<IEventAggregator>();
            var model = new TestViewModel(mock.Object);

            var message = new Message<string>("a");
            model.TestPublishMessage(message);

            mock.Verify(e => e.SendMessage(message));
        }

        [Test]
        public void Workspace_CanSubscribeToMessage()
        {
            var mock = new Mock<IEventAggregator>();
            var model = new TestViewModel(mock.Object);
            var action = new Action<Message<string>>(delegate { });

            model.TestSubscribeToMessage(action);

            mock.Verify(e => e.AddListener(action));

        }

        private class TestViewModel : ViewModelBase
        {
            public TestViewModel()
            {
            }

            public TestViewModel(IEventAggregator eventAggregator)
                : base(eventAggregator)
            {
            }

            public void TestPublishMessage<T>(T message) where T : IMessage
            {
                PublishMessage(message);
            }

            public void TestSubscribeToMessage<T>(Action<T> action) where T : IMessage
            {
                SubscribeToMessage(action);
            }
        }
    }
}