using System.Windows.Input;

namespace Quark.Tools.Wpf.Command.Decorator
{
    public interface ICommandDecorator
    {
        ICommand ActualCommand { get; set; }
    }
}