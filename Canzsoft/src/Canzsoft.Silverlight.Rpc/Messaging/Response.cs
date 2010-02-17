using System;
using Canzsoft.Silverlight.Rpc.Serialization;

namespace Canzsoft.Silverlight.Rpc.Messaging
{
    public abstract class Response
    {
        public static T ParseFromXml<T>(string xmlString)
        {
            return new RpcXmlSerializer().Deserialize<T>(xmlString);
        }
    }
}