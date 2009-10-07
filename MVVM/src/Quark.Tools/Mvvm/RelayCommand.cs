using System;
using System.Windows.Input;

namespace Quark.Tools.Mvvm
{
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly Action<object> action;
        private readonly Func<object, bool> canExecute;

        public RelayCommand(Action<object> action) : this(action, null)
        {
        }

        public RelayCommand(Action<object> action, Func<object, bool> canExecute)
        {
            this.action = action;
            this.canExecute = canExecute;
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