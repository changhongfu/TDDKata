using System;
using System.IO;
using System.Net;
using System.Threading;

namespace Canzsoft.Silverlight.Rpc.Web
{
    public class WebPoster : IWebPoster
    {
        public HttpWebRequest Resuest;

        public string Post(string requestString)
        {
            Uri uri = new Uri("http://www.contoso.com");

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            RequestState state = new RequestState { Request = request };

            IAsyncResult result = request.BeginGetResponse(RespCallback, state);

            if (result.IsCompleted)
            {
                Thread.Sleep(100);
            }

            Stream responseStream = state.Response.GetResponseStream();
            using (StreamReader sr = new StreamReader(responseStream))
            {
                return sr.ReadToEnd().Trim();
            }
        }

        private static void RespCallback(IAsyncResult asynchronousResult)
        {
            RequestState state = (RequestState) asynchronousResult.AsyncState;
            HttpWebRequest request = state.Request;
            state.Response = (HttpWebResponse) request.EndGetResponse(asynchronousResult);
        }
    }
}