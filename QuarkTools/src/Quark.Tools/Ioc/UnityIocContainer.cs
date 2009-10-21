using Microsoft.Practices.Unity;

namespace Quark.Tools.Ioc
{
    public class UnityIocContainer : IIocContainer
    {
        private readonly IUnityContainer container;

        public UnityIocContainer(IUnityContainer container)
        {
            this.container = container;
        }

        public T Resolve<T>()
        {
            return container.Resolve<T>();
        }
    }
}