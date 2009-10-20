using System.Windows;
using NUnit.Framework;
using Quark.Tools.Wpf.Converter;

namespace Quark.Tools.UnitTests.Wpf
{
    [TestFixture]
    public class BoolToVisibilityConverterTest
    {
        [Test]
        public void TextConvert_ReturnVisisable_IfValueIsTrue()
        {
            var converter = new BoolToVisibilityConverter();
            var result = converter.Convert(true, typeof(Visibility), null, null);
            Assert.AreEqual(Visibility.Visible, result);
        }

        [Test]
        public void TextConvert_ReturnCollapsed_IfValueIsFalse()
        {
            var converter = new BoolToVisibilityConverter();
            var result = converter.Convert(false, typeof(Visibility), null, null);
            Assert.AreEqual(Visibility.Collapsed, result);
        }
    }
}