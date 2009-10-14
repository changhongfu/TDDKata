using System;
using System.Windows.Input;

namespace Quark.Tools.Wpf.Command.Decorator
{
    public static class CommandExtensions
    {
        public static ICommand BeforeExecute(this ICommand command, Action action)
        {
            return new BeforeCommandDecorator(command, action);
        }

        public static ICommand AfterExecute(this ICommand command, Action action)
        {
            return new AfterCommandDecorator(command, action);
        }

        public static ICommand ExecuteAsync(this ICommand command)
        {
            return new AsyncCommandDecorator(command);
        }
    }
}