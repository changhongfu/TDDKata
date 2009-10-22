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

        protected abstract T CreateViewModel(IIocContainer iocContainer);
    }
}