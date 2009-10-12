using System.Windows.Controls.Primitives;

namespace Quark.Tools.Wpf.Command.Behavior
{
    public class ClickCommandBehavior : CommandBehaviorBase<ButtonBase>
    {
        public ClickCommandBehavior(ButtonBase clickableObject) : base(clickableObject)
        {
            clickableObject.Click += OnClick;
        }
      
        private void OnClick(object sender, System.Windows.RoutedEventArgs e)
        {
            ExecuteCommand();
        }
    }
}