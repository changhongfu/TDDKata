using NUnit.Framework;
using DescriptionAttribute = System.ComponentModel.DescriptionAttribute;

namespace Quark.Tools.UnitTests
{
    [TestFixture]
    public class EnumTest
    {
        [Test]
        public void TestLenght()
        {
            Assert.AreEqual(3, Enum<TestEnum>.Length);
        }

        [Test]
        public void TestParse()
        {
            Assert.AreEqual(TestEnum.Value1, Enum<TestEnum>.Parse("Value1"));
            Assert.AreEqual(TestEnum.Value2, Enum<TestEnum>.Parse("Value2"));
            Assert.AreEqual(TestEnum.Value3, Enum<TestEnum>.Parse("Value3"));

            Assert.AreEqual(TestEnumWithDescription.Value1, Enum<TestEnumWithDescription>.Parse("Value1"));
            Assert.AreEqual(TestEnumWithDescription.Value2, Enum<TestEnumWithDescription>.Parse("Value2"));
            Assert.AreEqual(TestEnumWithDescription.Value3, Enum<TestEnumWithDescription>.Parse("Value3"));
        }

        [Test]
        public void TestTryParse()
        {
            TestEnum val1;
            Assert.IsTrue(Enum<TestEnum>.TryParse("Value1", out val1));
            Assert.AreEqual(TestEnum.Value1, val1);

            TestEnumWithDescription val2;
            Assert.IsTrue(Enum<TestEnumWithDescription>.TryParse("Value2", out val2));
            Assert.AreEqual(TestEnumWithDescription.Value2, val2);

            TestEnum val3;
            Assert.IsFalse(Enum<TestEnum>.TryParse("NoSuchValue", out val3));
            Assert.AreEqual(default(TestEnum), val3);
        }

        [Test]
        public void TestTryParse_Nullable()
        {
            TestEnum? val1;
            Assert.IsTrue(Enum<TestEnum>.TryParse("Value1", out val1));
            Assert.AreEqual(TestEnum.Value1, val1);

            TestEnumWithDescription? val2;
            Assert.IsTrue(Enum<TestEnumWithDescription>.TryParse("Value2", out val2));
            Assert.AreEqual(TestEnumWithDescription.Value2, val2);

            TestEnum? val3;
            Assert.IsFalse(Enum<TestEnum>.TryParse("NoSuchValue", out val3));
            Assert.IsNull(val3);
        }

        [Test]
        public void TestGetName()
        {
            Assert.AreEqual("Value1", Enum<TestEnum>.GetName(0));
        }

        [Test]
        public void TestGetNames()
        {
            var names = Enum<TestEnum>.GetNames();
            Assert.AreEqual("Value1", names[0]);
            Assert.AreEqual("Value2", names[1]);
            Assert.AreEqual("Value3", names[2]);
        }

        [Test]
        public void TestGetValues()
        {
            var values = Enum<TestEnum>.GetValues();
            Assert.AreEqual(values.Length, 3);
            Assert.AreEqual(TestEnum.Value1, values[0]);
            Assert.AreEqual(TestEnum.Value2, values[1]);
            Assert.AreEqual(TestEnum.Value3, values[2]);
        }

        [Test]
        public void TestGetValuesOfT()
        {
            var values = Enum<TestEnum>.GetValues<int>();
            Assert.AreEqual(3, values.Length);
            Assert.AreEqual(0, values[0]);
            Assert.AreEqual(1, values[1]);
            Assert.AreEqual(2, values[2]);
        }

        [Test]
        public void TestGetDescription()
        {
            Assert.AreEqual("Value1", Enum<TestEnum>.GetDescription(TestEnum.Value1));
            Assert.AreEqual("Value 1", Enum<TestEnumWithDescription>.GetDescription(TestEnumWithDescription.Value1));

            Assert.AreEqual("Value2", Enum<TestEnum>.GetDescription(1));
            Assert.AreEqual("Value 2", Enum<TestEnumWithDescription>.GetDescription(1));
        }

        [Test]
        public void TestGetDescriptions()
        {
            var descriptions = Enum<TestEnumWithDescription>.GetDescriptions();
            Assert.AreEqual(descriptions.Length, 3);
            Assert.AreEqual("Value 1", descriptions[0]);
            Assert.AreEqual("Value 2", descriptions[1]);
            Assert.AreEqual("Value 3", descriptions[2]);
        }

        [Test]
        public void TestGetDescriptions_ShouldReturnStringValueAsDescription_IfDescriptionNotSpecified()
        {
            var descriptions = Enum<TestEnum>.GetDescriptions();
            Assert.AreEqual(descriptions.Length, 3);
            Assert.AreEqual("Value1", descriptions[0]);
            Assert.AreEqual("Value2", descriptions[1]);
            Assert.AreEqual("Value3", descriptions[2]);
        }

        [Test]
        public void GetValueAndDescriptionsPair()
        {
            var valueAndDescriptions = Enum<TestEnumWithDescription>.GetValueAndDescriptionPairs();
            Assert.AreEqual(3, valueAndDescriptions.Length);
            Assert.AreEqual(TestEnumWithDescription.Value1, valueAndDescriptions[0].Key);
            Assert.AreEqual("Value 1", valueAndDescriptions[0].Value);
            Assert.AreEqual(TestEnumWithDescription.Value2, valueAndDescriptions[1].Key);
            Assert.AreEqual("Value 2", valueAndDescriptions[1].Value);
            Assert.AreEqual(TestEnumWithDescription.Value3, valueAndDescriptions[2].Key);
            Assert.AreEqual("Value 3", valueAndDescriptions[2].Value);
        }

        enum TestEnum
        {
            Value1,
            Value2,
            Value3
        }

        enum TestEnumWithDescription
        {
            [Description("Value 1")]
            Value1,

            [Description("Value 2")]
            Value2,

            [Description("Value 3")]
            Value3
        }
    }
}