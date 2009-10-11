using System;
using System.Windows;
using System.Windows.Input;

namespace Quark.Tools.Wpf.Command.Behavior
{
    public class CommandBehavior
    {
        private static readonly DependencyProperty BehaviorProperty =
            DependencyProperty.RegisterAttached("Behavior", typeof(CommandBehaviorBinding), typeof(CommandBehavior),
                                                new FrameworkPropertyMetadata((CommandBehaviorBinding)null));
        
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.RegisterAttached("Command", typeof(ICommand), typeof(CommandBehavior),
                                                new FrameworkPropertyMetadata(null, new PropertyChangedCallback(OnCommandChanged)));

        public static readonly DependencyProperty ActionProperty =
            DependencyProperty.RegisterAttached("Action", typeof(Action<object>), typeof(CommandBehavior),
                                                new FrameworkPropertyMetadata(null, new PropertyChangedCallback(OnActionChanged)));

        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.RegisterAttached("CommandParameter", typeof(object), typeof(CommandBehavior),
                                                new FrameworkPropertyMetadata(null, new PropertyChangedCallback(OnCommandParameterChanged)));

        public static readonly DependencyProperty EventProperty =
            DependencyProperty.RegisterAttached("Event", typeof(string), typeof(CommandBehavior),
                                                new FrameworkPropertyMetadata(String.Empty, new PropertyChangedCallback(OnEventChanged)));

        private static CommandBehaviorBinding GetBehavior(DependencyObject d)
        {
            return (CommandBehaviorBinding)d.GetValue(BehaviorProperty);
        }

        private static void SetBehavior(DependencyObject d, CommandBehaviorBinding value)
        {
            d.SetValue(BehaviorProperty, value);
        }
        
        public static ICommand GetCommand(DependencyObject d)
        {
            return (ICommand)d.GetValue(CommandProperty);
        }

        public static void SetCommand(DependencyObject d, ICommand value)
        {
            d.SetValue(CommandProperty, value);
        }

        private static void OnCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CommandBehaviorBinding binding = FetchOrCreateBinding(d);
            binding.Command = (ICommand)e.NewValue;
        }

        public static Action<object> GetAction(DependencyObject d)
        {
            return (Action<object>)d.GetValue(ActionProperty);
        }

        public static void SetAction(DependencyObject d, Action<object> value)
        {
            d.SetValue(ActionProperty, value);
        }

        private static void OnActionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CommandBehaviorBinding binding = FetchOrCreateBinding(d);
            binding.Action = (Action<object>)e.NewValue;
        }
        
        public static object GetCommandParameter(DependencyObject d)
        {
            return d.GetValue(CommandParameterProperty);
        }

        public static void SetCommandParameter(DependencyObject d, object value)
        {
            d.SetValue(CommandParameterProperty, value);
        }
        
        public static string GetEvent(DependencyObject d)
        {
            return (string)d.GetValue(EventProperty);
        }

        public static void SetEvent(DependencyObject d, string value)
        {
            d.SetValue(EventProperty, value);
        }

        private static void OnCommandParameterChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CommandBehaviorBinding binding = FetchOrCreateBinding(d);
            binding.CommandParameter = e.NewValue;
        }

        private static void OnEventChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CommandBehaviorBinding binding = FetchOrCreateBinding(d);
            //check if the Event is set. If yes we need to rebind the Command to the new event and unregister the old one
            if (binding.Event != null && binding.Owner != null)
                binding.Dispose();
            //bind the new event to the command
            binding.BindEvent(d, e.NewValue.ToString());
        }

        //tries to get a CommandBehaviorBinding from the element. Creates a new instance if there is not one attached
        private static CommandBehaviorBinding FetchOrCreateBinding(DependencyObject d)
        {
            CommandBehaviorBinding binding = GetBehavior(d);
            if (binding == null)
            {
                binding = new CommandBehaviorBinding();
                SetBehavior(d, binding);
            }
            return binding;
        }
    }
}