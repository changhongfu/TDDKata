using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Quark.Tools.Wpf.Command.Behavior
{
    public static class DoubleClick
    {
        private static readonly DependencyProperty DoubleClickCommandBehaviorProperty = DependencyProperty.RegisterAttached(
            "DoubleClickCommandBehavior",
            typeof(DoubleClickCommandBehavior),
            typeof(DoubleClick),
            null);

        public static readonly DependencyProperty CommandProperty = DependencyProperty.RegisterAttached(
            "Command",
            typeof(ICommand),
            typeof(DoubleClick),
            new PropertyMetadata(OnSetCommandCallback));

        public static readonly DependencyProperty CommandParameterProperty = DependencyProperty.RegisterAttached(
            "CommandParameter",
            typeof(object),
            typeof(DoubleClick),
            new PropertyMetadata(OnSetCommandParameterCallback));


        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Only works for buttonbase")]
        public static void SetCommand(Control control, ICommand command)
        {
            control.SetValue(CommandProperty, command);
        }

        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Only works for buttonbase")]
        public static ICommand GetCommand(Control control)
        {
            return control.GetValue(CommandProperty) as ICommand;
        }

        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Only works for buttonbase")]
        public static void SetCommandParameter(Control control, object parameter)
        {
            control.SetValue(CommandParameterProperty, parameter);
        }

        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Only works for buttonbase")]
        public static object GetCommandParameter(Control control)
        {
            return control.GetValue(CommandParameterProperty);
        }

        private static void OnSetCommandCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            Control control = dependencyObject as Control;
            if (control != null)
            {
                DoubleClickCommandBehavior behavior = GetOrCreateBehavior(control);
                behavior.Command = e.NewValue as ICommand;
            }
        }

        private static void OnSetCommandParameterCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            Control control = dependencyObject as Control;
            if (control != null)
            {
                DoubleClickCommandBehavior behavior = GetOrCreateBehavior(control);
                behavior.CommandParameter = e.NewValue;
            }
        }

        private static DoubleClickCommandBehavior GetOrCreateBehavior(Control control)
        {
            DoubleClickCommandBehavior behavior = control.GetValue(DoubleClickCommandBehaviorProperty) as DoubleClickCommandBehavior;
            if (behavior == null)
            {
                behavior = new DoubleClickCommandBehavior(control);
                control.SetValue(DoubleClickCommandBehaviorProperty, behavior);
            }

            return behavior;
        }
    }
}