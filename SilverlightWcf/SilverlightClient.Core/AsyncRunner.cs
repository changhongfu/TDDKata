using System.ComponentModel;

namespace SilverlightClient.Core
{
    public class AsyncRunner : IAsyncRunner
    {
        private RunWorkerCompletedEventHandler _completedEventHandler;
        private DoWorkEventHandler _doWorkEventHandler;

        public AsyncRunner Do(DoWorkEventHandler doWorkEventHandler)
        {
            _doWorkEventHandler = doWorkEventHandler;
            return this;
        }

        public AsyncRunner WhenComplete(RunWorkerCompletedEventHandler completedEventHandler)
        {
            _completedEventHandler = completedEventHandler;
            return this;
        }

        public void RunAsync()
        {
            var worker = new BackgroundWorker();

            worker.DoWork += _doWorkEventHandler;
            worker.RunWorkerCompleted += _completedEventHandler;
            
            worker.RunWorkerAsync();
        }
    }
}