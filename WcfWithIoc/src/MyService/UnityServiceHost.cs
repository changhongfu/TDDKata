using System;
using System.ServiceModel;
using Microsoft.Practices.Unity;

namespace MyService
{
    public class UnityServiceHost : ServiceHost
    {
        private readonly UnityContainer _container;

        public UnityServiceHost(UnityContainer container, Type serviceType, params Uri[] baseAddresses) : base(serviceType, baseAddresses)
        {
            _container = container;
        }

        protected override void OnOpening()
        {
            Description.Behaviors.Add(new UnityServiceBehavior(_container));
            base.OnOpening();
        }
    }
}