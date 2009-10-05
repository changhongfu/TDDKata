using System;
using System.Diagnostics;
using System.Windows.Controls;

namespace Quark.Tools.Mvvm
{
    public class EnumComboBox<T> : ComboBox where T : struct, IComparable, IFormattable, IConvertible
    {
        static EnumComboBox()
        {
            Debug.Assert(typeof(T).IsEnum, string.Format("The class ({0}) must be an enum", typeof(T).FullName));
        }

        public EnumComboBox()
        {
            ItemsSource = Enum<T>.GetDescriptions();
        }
    }
}