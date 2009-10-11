﻿using System;

namespace Quark.Tools.Wpf.Command.Behavior
{
    public interface IExecutionStrategy
    {
        CommandBehaviorBinding Behavior { get; set; }

        void Execute(object parameter);
    }

    public class CommandExecutionStrategy : IExecutionStrategy
    {
        public CommandBehaviorBinding Behavior { get; set; }

        public void Execute(object parameter)
        {
            if (Behavior == null)
            {
                throw new InvalidOperationException("Behavior property cannot be null when executing a strategy");
            }

            if (Behavior.Command.CanExecute(Behavior.CommandParameter))
            {
                Behavior.Command.Execute(Behavior.CommandParameter);
            }
        }
    }

    public class ActionExecutionStrategy : IExecutionStrategy
    {
        public CommandBehaviorBinding Behavior { get; set; }

        public void Execute(object parameter)
        {
            Behavior.Action(parameter);
        }
    }
}