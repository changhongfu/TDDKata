using System;
using Canzsoft.Silverlight.Rpc.Serialization;

namespace Canzsoft.Silverlight.Rpc.Messaging
{
    public abstract class Request
    {
        public string ToXml()
        {
            return new RpcXmlSerializer().Serialize(this);
        }
    }
}