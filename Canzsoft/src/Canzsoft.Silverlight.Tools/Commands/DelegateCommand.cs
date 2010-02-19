using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace Canzsoft.Silverlight.Tools.Commands
{
    public class DelegateCommand : ICommand
    {
        private readonly Action<object> _executeMethod;
        private readonly Func<object, bool> _canExecuteMethod;
        private List<WeakReference> _canExecuteChangedHandlers;

        public DelegateCommand(Action<object> executeMethod)
            : this(executeMethod, null)
        {
        }

        public DelegateCommand(Action<object> executeMethod, Func<object, bool> canExecuteMethod)
        {
            if (executeMethod == null && canExecuteMethod == null)
            {
                throw new ArgumentNullException("executeMethod", "DelegateCommand Delegates Cannot Be Null");
            }

            _executeMethod = executeMethod;
            _canExecuteMethod = canExecuteMethod;
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecuteMethod == null)
            {
                return true;
            }
            return _canExecuteMethod(parameter);
        }

        public void Execute(object parameter)
        {
            if (_executeMethod == null)
            {
                return;
            }
            _executeMethod(parameter);
        }

        bool ICommand.CanExecute(object parameter)
        {
            return CanExecute(parameter);
        }

        void ICommand.Execute(object parameter)
        {
            Execute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                WeakEventHandlerManager.AddWeakReferenceHandler(ref _canExecuteChangedHandlers, value, 2);
            }
            remove
            {
                WeakEventHandlerManager.RemoveWeakReferenceHandler(_canExecuteChangedHandlers, value);
            }
        }
        
        protected virtual void OnCanExecuteChanged()
        {
            WeakEventHandlerManager.CallWeakReferenceHandlers(this, _canExecuteChangedHandlers);
        }

        public void RaiseCanExecuteChanged()
        {
            OnCanExecuteChanged();
        }
    }
}