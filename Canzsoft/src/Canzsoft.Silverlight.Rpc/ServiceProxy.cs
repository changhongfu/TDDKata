using Canzsoft.Silverlight.Rpc.Messaging;
using Canzsoft.Silverlight.Rpc.Web;

namespace Canzsoft.Silverlight.Rpc
{
    public class ServiceProxy
    {
        private readonly IWebPoster _poster;

        public ServiceProxy() : this (new WebPoster())
        {
        }

        public ServiceProxy(IWebPoster poster)
        {
            _poster = poster;
        }

        public T Invoke<T>(Request request) where T : Response
        {
            var requestXml = request.ToXml();
            var responseXml = _poster.Post(requestXml);
            return Response.ParseFromXml<T>(responseXml);
        }
    }
}