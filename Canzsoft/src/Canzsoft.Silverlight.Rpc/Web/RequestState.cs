using System;
using System.Net;

namespace Canzsoft.Silverlight.Rpc.Web
{
    public class RequestState
    {
        public HttpWebResponse Response { get; set; }

        public HttpWebRequest Request { get; set; }

        public string Result { get; set; }
    }
}