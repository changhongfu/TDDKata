using System.Windows;
using Canzsoft.Silverlight.Tools.Converters;
using NUnit.Framework;

namespace Canzsoft.Silverlight.UnitTests.Tools
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