using System.Windows.Controls.Primitives;

namespace Canzsoft.Silverlight.Tools.Commands
{
    public class ButtonBaseClickCommandBehavior : CommandBehaviorBase<ButtonBase>
    {
        public ButtonBaseClickCommandBehavior(ButtonBase clickableObject)
            : base(clickableObject)
        {
            clickableObject.Click += OnClick;
        }

        private void OnClick(object sender, System.Windows.RoutedEventArgs e)
        {
            ExecuteCommand();
        }
    }
}