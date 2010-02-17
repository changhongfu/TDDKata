using System.ComponentModel;

namespace Canzsoft.Silverlight.Tools
{
    public interface IAsyncRunner
    {
        AsyncRunner Do(DoWorkEventHandler doWorkEventHandler);

        AsyncRunner WhenComplete(RunWorkerCompletedEventHandler completedEventHandler);

        void RunAsync();
    }
}