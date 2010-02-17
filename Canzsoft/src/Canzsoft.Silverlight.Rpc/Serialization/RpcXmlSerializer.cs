using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Canzsoft.Silverlight.Rpc.Serialization
{
    public class RpcXmlSerializer : IXmlSerializer
    {
        private static readonly Encoding DefaultEncoding = Encoding.UTF8;
        private static readonly XmlWriterSettings DefaultXmlWriterSettings = new XmlWriterSettings { Indent = true, Encoding = DefaultEncoding };

        public string Serialize<T>(T toBeSerialzed)
        {
            var serializer = new XmlSerializer(toBeSerialzed.GetType());
            var emptyXmlns = new XmlSerializerNamespaces();
            emptyXmlns.Add(String.Empty, String.Empty);
            using (var stream = new MemoryStream())
            {
                var xmlTextWriter = XmlWriter.Create(stream, DefaultXmlWriterSettings);
                serializer.Serialize(xmlTextWriter, toBeSerialzed, emptyXmlns);
                var bytes = stream.ToArray();
                string xml = DefaultEncoding.GetString(bytes, 0, bytes.Length);
                xml = TrimMicrosoftStartingCharacters(xml);
                return xml;
            }
        }

        public T Deserialize<T>(string xmlString)
        {
            if (String.IsNullOrEmpty(xmlString))
            {
                return default(T);
            }
            xmlString = TrimMicrosoftStartingCharacters(xmlString);
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (MemoryStream stream = new MemoryStream(DefaultEncoding.GetBytes(xmlString)))
            {
                stream.Position = 0;
                XmlReader reader = XmlReader.Create(stream);
                return (T)serializer.Deserialize(reader);
            }
        }

        private static string TrimMicrosoftStartingCharacters(string xml)
        {
            int index = xml.IndexOf("<?xml");
            if (index > 0)
            {
                xml = xml.Substring(index);
            }
            return xml;
        }
    }
}