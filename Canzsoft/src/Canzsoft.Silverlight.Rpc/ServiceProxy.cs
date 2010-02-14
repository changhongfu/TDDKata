using Canzsoft.Silverlight.Rpc.Messaging;
using Canzsoft.Silverlight.Rpc.Serialization;
using Canzsoft.Silverlight.Rpc.Web;

namespace Canzsoft.Silverlight.Rpc
{
    public class ServiceProxy
    {
        private readonly IXmlSerializer _serializer;
        private readonly IWebPoster _poster;

        public ServiceProxy(IXmlSerializer serializer, IWebPoster poster)
        {
            _serializer = serializer;
            _poster = poster;
        }

        public T Invoke<T>(Request request) where T : Response
        {
            var requestXml = _serializer.Serialize(request);
            var reponseXml = _poster.Post(requestXml);
            return _serializer.Deserialize<T>(reponseXml);
        }
    }
}