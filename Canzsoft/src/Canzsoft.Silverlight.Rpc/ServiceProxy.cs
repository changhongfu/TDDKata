using Canzsoft.Silverlight.Rpc.Messaging;
using Canzsoft.Silverlight.Rpc.Serialization;
using Canzsoft.Silverlight.Rpc.Web;

namespace Canzsoft.Silverlight.Rpc
{
    public class ServiceProxy
    {
        private readonly IXmlSerializer _xmlSerializer;
        private readonly IWebPoster _poster;

        public ServiceProxy() : this (new RpcXmlSerializer(), new WebPoster())
        {
        }

        public ServiceProxy(IXmlSerializer xmlSerializer, IWebPoster poster)
        {
            _xmlSerializer = xmlSerializer;
            _poster = poster;
        }

        public T Invoke<T>(Request request) where T : Response
        {
            var requestXml = _xmlSerializer.Serialize(request);
            var responseXml = _poster.Post(requestXml);
            return _xmlSerializer.Deserialize<T>(responseXml);
        }
    }
}