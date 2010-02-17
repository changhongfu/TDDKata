using System;
using System.IO;
using System.Net;
using System.Threading;

namespace Canzsoft.Silverlight.Rpc.Web
{
    public class WebPoster : IWebPoster
    {
        public string Post(string requestString)
        {
            var request = (HttpWebRequest)WebRequest.Create(new Uri("http://localhost:9999/Myservice"));
            request.ContentType = "application/x-www-form-urlencoded";
            request.Method = "POST";

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

            while (String.IsNullOrEmpty(state.Result))
            {
                Thread.Sleep(100);
            }
            
            return state.Result;
        }
    }
}