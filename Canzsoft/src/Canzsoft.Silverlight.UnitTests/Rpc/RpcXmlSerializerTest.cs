using System;
using NUnit.Framework;
using Canzsoft.Silverlight.Rpc.Serialization;

namespace Canzsoft.Silverlight.UnitTests.Rpc
{
    [TestFixture]
    public class RpcXmlSerializerTest
    {
        [Test]
        public void Serialize()
        {
            var serializer = new RpcXmlSerializer();
            var xmlString = serializer.Serialize(new MyClass { Id = 1 });

            var expectedXml = String.Format("<?xml version=\"1.0\" encoding=\"utf-8\"?>{0}<MyClass>{0}{1}<Id>1</Id>{0}</MyClass>", Environment.NewLine, "  ");
            Assert.AreEqual(expectedXml, xmlString);
        }

        [Test]
        public void Deserialize_EmptyXml_ReturnNull()
        {
            var serializer = new RpcXmlSerializer();

            var myClass = serializer.Deserialize<MyClass>(String.Empty);

            Assert.IsNull(myClass);
        }

        [Test]
        public void Deserialize()
        {
            var serializer = new RpcXmlSerializer();
            var xmlString = String.Format("<?xml version=\"1.0\" encoding=\"utf-8\"?>{0}<MyClass>{0}{1}<Id>1</Id>{0}</MyClass>", Environment.NewLine, "  ");

            var myClass = serializer.Deserialize<MyClass>(xmlString);

            Assert.AreEqual(1, myClass.Id);
        }
    }

    public class MyClass
    {
        public int Id { get; set; }
    }
}