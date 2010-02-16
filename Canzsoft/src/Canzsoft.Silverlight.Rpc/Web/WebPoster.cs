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
            var request = WebRequest.Create(new Uri("http://localhost:52404/Employee/List")) as HttpWebRequest;
            request.Method = "POST"; 

            var state = new RequestState { Request = request };

            var asyncResult = request.BeginGetResponse(OnReponseReady, state);

            while (!asyncResult.IsCompleted)
            {
                Thread.Sleep(100);
            }
            
            return state.Result;
        }

        private static void OnReponseReady(IAsyncResult result)
        {
            var state = result.AsyncState as RequestState;
            var resp = state.Request.EndGetResponse(result) as HttpWebResponse;

            Stream strm = resp.GetResponseStream();

            using (var sr = new StreamReader(strm))
            {
                state.Result = sr.ReadToEnd().Trim();
            }
        }
    }
}