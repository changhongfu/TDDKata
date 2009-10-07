using Quark.Tools.Mvvm;

namespace DemoApp.ViewModels
{
    public abstract class WorkspaceViewModel : ViewModelBase
    {
        public virtual string DisplayName { get; protected set; } 
    }
}