using System;
using System.Net;
using System.Threading;

namespace Canzsoft.Silverlight.TestServer
{
    public class MyWebServer
    {
        private static AutoResetEvent listenForNextRequest = new AutoResetEvent(false);

        private HttpListener _httpListener = new HttpListener();
        private readonly int port = 8888;

        public string Prefix { get; set; }

        public bool IsRunning { get; private set; }

        public MyWebServer()
        {
            _httpListener = new HttpListener();
        }

        public void Start()
        {
            if (String.IsNullOrEmpty(Prefix))
            {
                throw new InvalidOperationException("No prefix has been specified");
            }
            _httpListener.Prefixes.Clear();
            _httpListener.Prefixes.Add(Prefix);
            _httpListener.Start();
            ThreadPool.QueueUserWorkItem(Listen);
        }

        internal void Stop()
        {
            _httpListener.Stop();
            IsRunning = false;
        }

        private void Listen(object state)
        {
            while (_httpListener.IsListening)
            {
                _httpListener.BeginGetContext(ListenerCallback, _httpListener);
                listenForNextRequest.WaitOne();
            }
        }

        private void ListenerCallback(IAsyncResult result)
        {
            var listener = result.AsyncState as HttpListener;
            HttpListenerContext context;

            if (listener == null)
            {
                return;
            }

            try
            {
                context = listener.EndGetContext(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return;
            }
            finally
            {
                listenForNextRequest.Set();
            }
            
            ProcessRequest(context);
        }

        protected void ProcessRequest(HttpListenerContext context)
        {
            
        }
    }
}