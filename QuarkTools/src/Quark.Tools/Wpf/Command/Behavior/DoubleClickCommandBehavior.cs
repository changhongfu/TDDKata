using System.Windows.Controls;

namespace Quark.Tools.Wpf.Command.Behavior
{
    public class DoubleClickCommandBehavior : CommandBehaviorBase<Control>
    {
        public DoubleClickCommandBehavior(Control clickableObject) : base(clickableObject)
        {
            clickableObject.MouseDoubleClick += delegate { ExecuteCommand(); };
        }
    }
}