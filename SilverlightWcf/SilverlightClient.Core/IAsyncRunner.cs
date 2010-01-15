using System.ComponentModel;

namespace SilverlightClient.Core
{
    public interface IAsyncRunner
    {
        AsyncRunner Do(DoWorkEventHandler doWorkEventHandler);

        AsyncRunner WhenComplete(RunWorkerCompletedEventHandler completedEventHandler);

        void RunAsync();
    }
}