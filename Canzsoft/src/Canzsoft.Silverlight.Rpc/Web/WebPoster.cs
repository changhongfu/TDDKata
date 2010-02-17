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
            var request = WebRequest.Create(new Uri("http://localhost:9999/Myservice")) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";  

            var state = new RequestState { Request = request };

            request.BeginGetRequestStream(delegate(IAsyncResult asyncResult)
            {
                StreamWriter writer = new StreamWriter(request.EndGetRequestStream(asyncResult));
                writer.WriteLine(requestString);
                writer.Flush();
                writer.Close();

                request.BeginGetResponse(delegate(IAsyncResult asyncResult2)
                {
                    HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(asyncResult2);
                    using (var sr = new StreamReader(response.GetResponseStream()))
                    {
                        state.Result = sr.ReadToEnd().Trim();
                    }
                }, state);

            }, state);


            while (String.IsNullOrEmpty(state.Result))
            {
                Thread.Sleep(100);
            }
            
            return state.Result;
        }
    }
}