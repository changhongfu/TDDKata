namespace Canzsoft.Silverlight.TestApp.Modules
{
    public interface IModule
    {
        string Name { get; }
        string ImageUrl { get; }
        void Open();
    }
}