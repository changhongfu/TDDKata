using System;
using System.Windows.Input;

namespace Quark.Tools.Wpf.Command.Decorator
{
    public class BeforeCommandDecorator : CommandDecorator
    {
        private readonly Action _beforeExecutionAction;

        public BeforeCommandDecorator(ICommand command, Action beforeExecutionAction) : base(command)
        {
            _beforeExecutionAction = beforeExecutionAction;
        }

        public override void Execute(object parameter)
        {
            _beforeExecutionAction();
            ActualCommand.Execute(parameter);
        }
    }
}