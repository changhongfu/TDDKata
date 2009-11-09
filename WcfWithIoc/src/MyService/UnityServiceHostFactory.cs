using System;
using System.ServiceModel;
using System.ServiceModel.Activation;
using Microsoft.Practices.Unity;

namespace MyService
{
    public class UnityServiceHostFactory : ServiceHostFactory
    {
        private readonly UnityContainer _container;

        public UnityServiceHostFactory()
        {
            _container = IocBootstrap.SetupIoc();
        }

        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            return new UnityServiceHost(_container, serviceType, baseAddresses);
        }
    }
}