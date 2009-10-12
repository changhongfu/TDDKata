using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace Quark.Tools.Wpf.Command.Behavior
{
    public static class Click
    {
        private static readonly DependencyProperty ClickCommandBehaviorProperty = DependencyProperty.RegisterAttached(
            "ClickCommandBehavior",
            typeof(ClickCommandBehavior),
            typeof(Click),
            null);


        public static readonly DependencyProperty CommandProperty = DependencyProperty.RegisterAttached(
            "Command",
            typeof(ICommand),
            typeof(Click),
            new PropertyMetadata(OnSetCommandCallback));

        public static readonly DependencyProperty CommandParameterProperty = DependencyProperty.RegisterAttached(
            "CommandParameter",
            typeof(object),
            typeof(Click),
            new PropertyMetadata(OnSetCommandParameterCallback));

        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Only works for buttonbase")]
        public static void SetCommand(ButtonBase buttonBase, ICommand command)
        {
            buttonBase.SetValue(CommandProperty, command);
        }

        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Only works for buttonbase")]
        public static ICommand GetCommand(ButtonBase buttonBase)
        {
            return buttonBase.GetValue(CommandProperty) as ICommand;
        }

        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Only works for buttonbase")]
        public static void SetCommandParameter(ButtonBase buttonBase, object parameter)
        {
            buttonBase.SetValue(CommandParameterProperty, parameter);
        }

        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Only works for buttonbase")]
        public static object GetCommandParameter(ButtonBase buttonBase)
        {
            return buttonBase.GetValue(CommandParameterProperty);
        }

        private static void OnSetCommandCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            ButtonBase buttonBase = dependencyObject as ButtonBase;
            if (buttonBase != null)
            {
                ClickCommandBehavior behavior = GetOrCreateBehavior(buttonBase);
                behavior.Command = e.NewValue as ICommand;
            }
        }

        private static void OnSetCommandParameterCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            ButtonBase buttonBase = dependencyObject as ButtonBase;
            if (buttonBase != null)
            {
                ClickCommandBehavior behavior = GetOrCreateBehavior(buttonBase);
                behavior.CommandParameter = e.NewValue;
            }
        }

        private static ClickCommandBehavior GetOrCreateBehavior(ButtonBase buttonBase)
        {
            ClickCommandBehavior behavior = buttonBase.GetValue(ClickCommandBehaviorProperty) as ClickCommandBehavior;
            if (behavior == null)
            {
                behavior = new ClickCommandBehavior(buttonBase);
                buttonBase.SetValue(ClickCommandBehaviorProperty, behavior);
            }

            return behavior;
        }
    }
}