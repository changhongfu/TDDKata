namespace Quark.Tools.Ioc
{
    public interface IIocContainer
    {
        T Resolve<T>();
    }
}