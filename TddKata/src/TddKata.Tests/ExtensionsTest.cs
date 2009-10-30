using NUnit.Framework;

namespace TddKata.Tests
{
    [TestFixture]
    public class ExtensionsTest
    {
        [Test]
        public void ToCommaDelimitedString_Interger()
        {
            var values = new[] {1, 2, 3,};
            string result = values.ToCommaDelimitedString();
            Assert.AreEqual("1, 2, 3", result);
        }
    }
}