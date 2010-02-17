using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Canzsoft.Silverlight.TestServer
{
    public static class XmlSerializerHelper
    {
        private static readonly Encoding DefaultEncoding = Encoding.UTF8;

        public static string Serialize<T>(T obj)
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));
            XmlSerializerNamespaces emptyXmlns = new XmlSerializerNamespaces();
            emptyXmlns.Add(String.Empty, String.Empty);
            using (MemoryStream memoryStream = new MemoryStream())
            {
                XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, DefaultEncoding);
                xmlTextWriter.Formatting = Formatting.None;
                ser.Serialize(xmlTextWriter, obj, emptyXmlns);
                string xml = DefaultEncoding.GetString(memoryStream.ToArray());
                xml = TrimMicrosoftStartingCharacters(xml);
                return xml;
            }
        }

        public static T Deserialize<T>(string xml)
        {
            if (String.IsNullOrEmpty(xml))
            {
                return default(T);
            }
            xml = TrimMicrosoftStartingCharacters(xml);
            XmlSerializer ser = new XmlSerializer(typeof(T));
            using (MemoryStream stream = new MemoryStream(DefaultEncoding.GetBytes(xml)))
            {
                stream.Position = 0;
                XmlTextReader reader = new XmlTextReader(stream);
                return (T)ser.Deserialize(reader);
            }
        }

        public static string TrimMicrosoftStartingCharacters(string xml)
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