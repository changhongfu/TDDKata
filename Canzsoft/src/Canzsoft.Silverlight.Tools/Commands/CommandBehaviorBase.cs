using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace Canzsoft.Silverlight.Tools.Commands
{
    public class CommandBehaviorBase<T> where T : Control
    {
        private readonly EventHandler _commandCanExecuteChangedHandler;
        private readonly WeakReference _targetObject;
        private ICommand _command;
        private object _commandParameter;

        public CommandBehaviorBase(T targetObject)
        {
            _targetObject = new WeakReference(targetObject);
            _commandCanExecuteChangedHandler = new EventHandler(CommandCanExecuteChanged);
        }

        public ICommand Command
        {
            get { return _command; }
            set
            {
                if (_command != null)
                {
                    _command.CanExecuteChanged -= _commandCanExecuteChangedHandler;
                }

                _command = value;
                if (_command != null)
                {
                    _command.CanExecuteChanged += _commandCanExecuteChangedHandler;
                    UpdateEnabledState();
                }
            }
        }

        public object CommandParameter
        {
            get { return _commandParameter; }
            set
            {
                if (_commandParameter != value)
                {
                    _commandParameter = value;
                    UpdateEnabledState();
                }
            }
        }

        protected T TargetObject
        {
            get { return _targetObject.Target as T; }
        }


        protected virtual void UpdateEnabledState()
        {
            if (TargetObject == null)
            {
                Command = null;
                CommandParameter = null;
            }
            else if (Command != null)
            {
                TargetObject.IsEnabled = Command.CanExecute(CommandParameter);
            }
        }

        private void CommandCanExecuteChanged(object sender, EventArgs e)
        {
            UpdateEnabledState();
        }

        protected virtual void ExecuteCommand()
        {
            if (Command != null)
            {
                Command.Execute(CommandParameter);
            }
        }
    }
}