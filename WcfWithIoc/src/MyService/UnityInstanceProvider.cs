using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using Microsoft.Practices.Unity;

namespace MyService
{
    public class UnityInstanceProvider : IInstanceProvider
    {
        private readonly UnityContainer _container;
        private readonly Type _serviceType;
        

        public UnityInstanceProvider(UnityContainer container, Type type)
        {
            _container = container;
            _serviceType = type;
        }

        public object GetInstance(InstanceContext instanceContext, Message message)
        {
            return _container.Resolve(_serviceType);
        }

        public object GetInstance(InstanceContext instanceContext)
        {
            return GetInstance(instanceContext, null);
        }

        public void ReleaseInstance(InstanceContext instanceContext, object instance)
        {
        }
    }
}