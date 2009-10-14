using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace Quark.Tools.Wpf.Command.Behavior
{
    public class CommandBehaviorBase<T> where T : Control
    {
        private readonly EventHandler commandCanExecuteChangedHandler;
        private readonly WeakReference targetObject;
        private ICommand command;
        private object commandParameter;

        public CommandBehaviorBase(T targetObject)
        {
            this.targetObject = new WeakReference(targetObject);
            commandCanExecuteChangedHandler = new EventHandler(CommandCanExecuteChanged);
        }

        public ICommand Command
        {
            get { return command; }
            set
            {
                if (command != null)
                {
                    command.CanExecuteChanged -= commandCanExecuteChangedHandler;
                }

                command = value;
                if (command != null)
                {
                    command.CanExecuteChanged += commandCanExecuteChangedHandler;
                    UpdateEnabledState();
                }
            }
        }

        public object CommandParameter
        {
            get { return commandParameter; }
            set
            {
                if (commandParameter != value)
                {
                    commandParameter = value;
                    UpdateEnabledState();
                }
            }
        }

        protected T TargetObject
        {
            get { return targetObject.Target as T; }
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