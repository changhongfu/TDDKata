using System.ComponentModel;

namespace Canzsoft.Silverlight.Tools
{
    public class AsyncRunner : IAsyncRunner
    {
        private RunWorkerCompletedEventHandler _completedEventHandler;
        private DoWorkEventHandler _doWorkEventHandler;

        public AsyncRunner Run(DoWorkEventHandler doWorkEventHandler)
        {
            _doWorkEventHandler = doWorkEventHandler;
            return this;
        }

        public AsyncRunner WhenComplete(RunWorkerCompletedEventHandler completedEventHandler)
        {
            _completedEventHandler = completedEventHandler;
            return this;
        }

        public void Execute()
        {
            var worker = new BackgroundWorker();

            worker.DoWork += _doWorkEventHandler;
            worker.RunWorkerCompleted += _completedEventHandler;

            worker.RunWorkerAsync();
        }
    }
}