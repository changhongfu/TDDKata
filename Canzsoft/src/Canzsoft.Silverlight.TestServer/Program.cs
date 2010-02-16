using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using ThreadState = System.Threading.ThreadState;

namespace Canzsoft.Silverlight.TestServer
{
    class Program
    {
        const int PORT_NUMBER = 9999;

        private static bool _keepAppRunning = true;
        private static HttpListener _listener;
        private static Thread _listeningThread;

        static void Main(string[] args)
        {
            Console.WriteLine("Starting the HttpListener on port:{0}", PORT_NUMBER);

            InitialiseListener();

            _listeningThread = new Thread(ListeningThread);
            _listeningThread.Start();

            Console.WriteLine("Listener started on port: {0}, waiting for requests, press ANY KEY to quit.", PORT_NUMBER);

            while (_keepAppRunning)
            {
                if (Console.KeyAvailable)
                    _keepAppRunning = false;
            }

            if (_listeningThread.ThreadState == ThreadState.Running)
                _listeningThread.Abort();

            if (_listener.IsListening)
                _listener.Stop();
        }

        private static void InitialiseListener()
        {
            _listener = new HttpListener();

            string prefix = string.Format("http://+:{0}/", PORT_NUMBER);
            _listener.Prefixes.Add(prefix);

            _listener.Start();
        }

        private static void ListeningThread()
        {
            while (_keepAppRunning)
            {
                HttpListenerContext context = _listener.GetContext();
                Console.WriteLine("---Request Recieved----");

                try
                {
                    WriteRequestHeaderInformation(context);
                    CreateResponseDocument(context);
                }
                catch (Exception ex)
                {
                    ConsoleColor oldCol = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\nThere was an error processing this request. See below for detals :-");
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("\n");
                    Console.ForegroundColor = oldCol;
                }
            }
        }

        private static void CreateResponseDocument(HttpListenerContext ctxt)
        {
            string htmlOutput = "<?xml version=\"1.0\" encoding=\"utf-8\"?>";
            if (ctxt.Request.Url.ToString().Contains("clientaccesspolicy"))
            {
                htmlOutput = "<?xml version=\"1.0\" encoding=\"utf-8\"?><access-policy><cross-domain-access><policy><allow-from http-request-headers=\"*\"><domain uri=\"*\"/></allow-from><grant-to><resource path=\"/\" include-subpaths=\"true\"/></grant-to></policy></cross-domain-access></access-policy>";
            }
            ctxt.Response.ContentType = "text/xml";

            if (ctxt.Response.OutputStream.CanWrite)
            {
                byte[] htmlData = Encoding.UTF8.GetBytes(htmlOutput);
                ctxt.Response.OutputStream.Write(htmlData, 0, htmlData.Length);
            }
            
            ctxt.Response.Close();

            Console.WriteLine("Response: {0}", htmlOutput);
        }

        private static void WriteRequestHeaderInformation(HttpListenerContext ctxt)
        {
            Console.WriteLine("Request Url: {0}", ctxt.Request.Url);
            Console.WriteLine("Request Method: {0}", ctxt.Request.HttpMethod);
            using (var sr = new StreamReader(ctxt.Request.InputStream))
            {
                string requestData = sr.ReadToEnd().Trim();
                Console.WriteLine("Request Data: {0}", requestData);
            }
        }
    }
}
