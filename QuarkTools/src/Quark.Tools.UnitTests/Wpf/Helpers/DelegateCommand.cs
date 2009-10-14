using System;
using System.Windows.Input;

namespace Quark.Tools.UnitTests.Wpf.Helpers
{
    public class DelegateCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Action _action;

        public DelegateCommand(Action action)
        {
            _action = action;
        }

        public Action Action
        {
            set
            {
                bool shouldRaiseEvent = (_action != null && value == null) || (_action == null && value != null);

                _action = value;

                if (shouldRaiseEvent)
                {
                    var handler = CanExecuteChanged;
                    if (handler != null)
                    {
                        CanExecuteChanged(this, EventArgs.Empty);
                    }
                }
            }
        }

        public void Execute(object parameter)
        {
            _action();
        }

        public bool CanExecute(object parameter)
        {
            return _action != null;
        }
    }
}