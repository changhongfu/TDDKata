using System.Windows.Input;

namespace Canzsoft.Silverlight.Tools.Commands
{
    public interface ICommandDecorator
    {
        ICommand ActualCommand { get; set; }
    }
}