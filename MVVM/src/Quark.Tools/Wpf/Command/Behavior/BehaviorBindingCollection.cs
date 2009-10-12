using System.Windows;

namespace Quark.Tools.Wpf.Command.Behavior
{
    public class BehaviorBindingCollection : FreezableCollection<BehaviorBinding>
    {
        public DependencyObject Owner { get; set; }
    }
}