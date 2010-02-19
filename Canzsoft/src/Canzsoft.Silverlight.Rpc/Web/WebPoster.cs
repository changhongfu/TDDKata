using System;
using System.IO;
using System.Net;
using System.Threading;

namespace Canzsoft.Silverlight.Rpc.Web
{
    public class WebPoster : IWebPoster
    {
        private static readonly string SERVER_URL = "http://localhost:9999/Myservice";
        private static readonly string CONTENT_TYPE = "application/x-www-form-urlencoded";
        private static readonly string HTTP_POST = "POST";

        public string Post(string requestString)
        {
            HttpWebRequest request = CreateWebRequest();

            var state = new RequestState();

            request.BeginGetRequestStream(asyncResult =>
            {
                using(var writer = new StreamWriter(request.EndGetRequestStream(asyncResult)))
                {
                    writer.Write(requestString);
                    writer.Flush();
                }

                request.BeginGetResponse(asyncResult2 =>
                 {
                     var response = (HttpWebResponse) request.EndGetResponse(asyncResult2);
                     using (var sr = new StreamReader(response.GetResponseStream()))
                     {
                         state.Result = sr.ReadToEnd().Trim();
                     }
                 }, state);
            }, state);

            WaitForResult(state);
            
            return state.Result;
        }

        private static HttpWebRequest CreateWebRequest()
        {
            var request = (HttpWebRequest)WebRequest.Create(new Uri(SERVER_URL));
            request.ContentType = CONTENT_TYPE;
            request.Method = HTTP_POST;
            return request;
        }

        private static void WaitForResult(RequestState state)
        {
            while (String.IsNullOrEmpty(state.Result))
            {
                Thread.Sleep(100);
            }
        }
    }
}