using System;
using System.Windows.Input;

namespace Quark.Tools.Wpf.Command.Decorator
{
    public class AfterCommandDecoratorx : CommandDecorator
    {
        private readonly Action _afterExecutionAction;

        public AfterCommandDecorator(ICommand command, Action afterExecutionAction) : base(command)
        {
            _afterExecutionAction = afterExecutionAction;

            //If command has been decorated with Async, would run AfterExecution Action on its RunWorkerComplete event handler
            //Otherwise, run AfterExecution Action after execution of the command
            var asyncCommand = GetAsyncCommandDecorator(ActualCommand);
            if (asyncCommand != null)
            {
                asyncCommand.BackgroundWorker.RunWorkerCompleted += (sender, args) => _afterExecutionAction();
            }
        }

        public override void Execute(object parameter)
        {
            ActualCommand.Execute(parameter);

            if (GetAsyncCommandDecorator(ActualCommand) == null)
            {
                _afterExecutionAction();
            }
        }

        private static AsyncCommandDecorator GetAsyncCommandDecorator(ICommand command)
        {
            if (command is AsyncCommandDecorator)
            {
                return command as AsyncCommandDecorator;
            }
            if (command.GetType().IsSubclassOf(typeof(CommandDecorator)))
            {
                return GetAsyncCommandDecorator(((CommandDecorator)command).ActualCommand);
            }
            return null;
        }
    }
}