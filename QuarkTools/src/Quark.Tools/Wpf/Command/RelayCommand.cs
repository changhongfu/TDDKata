using System;
using System.Windows.Input;

namespace Quark.Tools.Wpf.Command
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object> action;
        private readonly Func<object, bool> canExecute;

        public RelayCommand(Action<object> action)
            : this(action, null)
        {
        }

        public RelayCommand(Action<object> action, Func<object, bool> canExecute)
        {
            this.action = action;
            this.canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            action(parameter);
        }

        public bool CanExecute(object parameter)
        {
            return canExecute == null || canExecute(parameter);
        }
    }
}