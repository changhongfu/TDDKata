using System;
using Moq;
using Quark.Tools.Ioc;
using Quark.Tools.Wpf.Events;
using Quark.Tools.Wpf.ViewModel;

namespace DemoApp.UnitTests
{
    public abstract class BaseViewModelTest<T> where T : ViewModelBase
    {
        protected T CreateViewModel()
        {
            return CreateViewModel(new Mock<IEventAggregator>());
        }

        protected virtual T CreateViewModel(Mock<IIocContainer> iocMock)
        {
            var eventMock = new Mock<EventAggregator>();
            iocMock.Setup(ioc => ioc.Resolve<IEventAggregator>()).Returns(eventMock.Object);
            return CreateViewModel(iocMock.Object);
        }

        protected virtual T CreateViewModel(Mock<IEventAggregator> eventMock)
        {
            var iocMock = new Mock<IIocContainer>();
            iocMock.Setup(ioc => ioc.Resolve<IEventAggregator>()).Returns(eventMock.Object);
            return CreateViewModel(iocMock.Object);
        }

        protected void HookupMessage<TMsg>(Mock<IEventAggregator> eventMock) where TMsg : IMessage
        {
            Action<TMsg> action = null;
            eventMock.Setup(e => e.AddListener(It.IsAny<Action<TMsg>>()))
                .Callback((Action<TMsg> a) => action = a);
            eventMock.Setup(e => e.SendMessage(It.IsAny<TMsg>()))
                .Callback((TMsg msg) => action(msg));
        }

        protected abstract T CreateViewModel(IIocContainer iocContainer);
    }
}