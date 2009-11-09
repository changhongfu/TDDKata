using Microsoft.Practices.Unity;

namespace MyService
{
    public class IocBootstrap
    {
        public static UnityContainer SetupIoc()
        {
            var container = new UnityContainer();
            container.RegisterType<ICalculator, Calculator>();
            return container;
        }
    }
}