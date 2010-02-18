using System;
using System.Windows.Input;

namespace Canzsoft.Silverlight.Tools.Commands
{
    public abstract class CommandDecorator : ICommandDecorator, ICommand
    {
        protected CommandDecorator(ICommand command)
        {
            ActualCommand = command;
        }

        public event EventHandler CanExecuteChanged
        {
            add { ActualCommand.CanExecuteChanged += value; }
            remove { ActualCommand.CanExecuteChanged -= value; }
        }

        public ICommand ActualCommand { get; set; }

        public abstract void Execute(object parameter);

        public bool CanExecute(object parameter)
        {
            return ActualCommand.CanExecute(parameter);
        }
    }
}