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
            return CreateViewModel(new Mock<IIocContainer>());
        }

        protected virtual T CreateViewModel(Mock<IIocContainer> iocMock)
        {
            return CreateViewModel(iocMock, new Mock<IEventAggregator>());
        }

        protected virtual T CreateViewModel(Mock<IIocContainer> iocMock, Mock<IEventAggregator> eventMock)
        {
            iocMock.Setup(ioc => ioc.Resolve<IEventAggregator>()).Returns(eventMock.Object);
            return CreateViewModel(iocMock.Object);
        }

        protected abstract T CreateViewModel(IIocContainer iocContainer);
    }
}