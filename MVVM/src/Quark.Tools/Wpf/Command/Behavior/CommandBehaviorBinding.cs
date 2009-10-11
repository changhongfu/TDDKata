using System;
using System.Windows.Input;
using System.Reflection;
using System.Windows;

namespace Quark.Tools.Wpf.Command.Behavior
{
    public class CommandBehaviorBinding : IDisposable
    {
        private IExecutionStrategy strategy;
        private ICommand command;
        private Action<object> action;
        private bool disposed;

        public DependencyObject Owner { get; private set; }

        public string EventName { get; private set; }

        public EventInfo Event { get; private set; }

        public Delegate EventHandler { get; private set; }

        public object CommandParameter { get; set; }

        public ICommand Command
        {
            get { return command; }
            set
            {
                command = value;
                strategy = new CommandExecutionStrategy { Behavior = this };
            }
        }

        public Action<object> Action
        {
            get { return action; }
            set
            {
                action = value;
                strategy = new ActionExecutionStrategy { Behavior = this };
            }
        }

        //Creates an EventHandler on runtime and registers that handler to the Event specified
        public void BindEvent(DependencyObject owner, string eventName)
        {
            EventName = eventName;
            Owner = owner;
            Event = Owner.GetType().GetEvent(EventName, BindingFlags.Public | BindingFlags.Instance);
            if (Event == null)
            {
                throw new InvalidOperationException(String.Format("Could not resolve event name {0}", EventName));
            }

            //Create an event handler for the event that will call the ExecuteCommand method
            EventHandler = EventHandlerGenerator.CreateDelegate(Event.EventHandlerType, typeof(CommandBehaviorBinding).GetMethod("Execute", BindingFlags.Public | BindingFlags.Instance), this);
            //Register the handler to the Event
            Event.AddEventHandler(Owner, EventHandler);
        }

        public void Execute()
        {
            strategy.Execute(CommandParameter);
        }

        public void Dispose()
        {
            if (!disposed)
            {
                Event.RemoveEventHandler(Owner, EventHandler);
                disposed = true;
            }
        }
    }
}