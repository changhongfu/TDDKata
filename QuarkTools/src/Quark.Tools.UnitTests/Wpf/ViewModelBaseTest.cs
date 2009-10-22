using System;
using Moq;
using NUnit.Framework;
using Quark.Tools.Ioc;
using Quark.Tools.Wpf.Events;
using Quark.Tools.Wpf.ViewModel;

namespace Quark.Tools.UnitTests.Wpf
{
    [TestFixture]
    public class ViewModelBaseTest
    {
        [Test]
        public void ViewModelBase_HasPropertyChangedEvent()
        {
            var iocMock = new Mock<IIocContainer>();

            var model = new TestViewModel(iocMock.Object);

            model.PropertyChanged += delegate { };
        }

        [Test]
        public void ViewModelBase_ShouldResolveEventAggregator_WhenConstructed()
        {
            var iocMock = new Mock<IIocContainer>();
            var model = new TestViewModel(iocMock.Object);
            var expectedEventAggregator = new Mock<IEventAggregator>().Object;
            iocMock.Setup(ioc => ioc.Resolve<IEventAggregator>()).Returns(expectedEventAggregator);

            var actualEventAggregator = model.TestEventAggregator;

            Assert.AreEqual(expectedEventAggregator, actualEventAggregator);
        }

        //[Test]
        //public void ViewModelBase_CanPublishMessage()
        //{
        //    var mock = new Mock<IEventAggregator>();
        //    var iocMock = new Mock<IIocContainer>();
        //    iocMock.Setup(ioc => ioc.Resolve<IEventAggregator>()).Returns(mock.Object);

        //    var model = new TestViewModel(iocMock.Object);

        //    var message = new Message<string>("a");
        //    model.TestPublishMessage(message);

        //    mock.Verify(e => e.Publish(message));
        //}

        //[Test]
        //public void ViewModelBase_CanSubscribeToMessage()
        //{
        //    var mock = new Mock<IEventAggregator>();
        //    var iocMock = new Mock<IIocContainer>();
        //    iocMock.Setup(ioc => ioc.Resolve<IEventAggregator>()).Returns(mock.Object);

        //    var model = new TestViewModel(iocMock.Object);
        //    var action = new Action<Message<string>>(delegate { });

        //    model.TestSubscribeToMessage(action);

        //    mock.Verify(e => e.Subscribe(action));
        //}

        [Test]
        public void CreateViewModel_ShouldCreateViewModelusingIocContainer()
        {
            var iocMock = new Mock<IIocContainer>();
            var model = new TestViewModel(iocMock.Object);

            model.TestCreateViewModel<TestViewModel>();

            iocMock.Verify(ioc => ioc.Resolve<TestViewModel>());
        }

        private class TestViewModel : ViewModelBase
        {
            public TestViewModel(IIocContainer iocContainer)
                : base(iocContainer)
            {
            }

            public void TestPublishMessage<T>(T message) where T : IMessage
            {
                PublishMessage(message);
            }

            public void TestSubscribeToMessage<T>(ISubscriber<T> subscriber) where T : IMessage
            {
                SubscribeToMessage(subscriber);
            }

            public T TestCreateViewModel<T>() where T : ViewModelBase
            {
                return CreateViewModel<T>();
            }

            public IEventAggregator TestEventAggregator
            {
                get { return EventAggregator; }
            }
        }
    }
}