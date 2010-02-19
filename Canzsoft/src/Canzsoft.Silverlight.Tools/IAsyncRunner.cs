using System.ComponentModel;

namespace Canzsoft.Silverlight.Tools
{
    public interface IAsyncRunner
    {
        AsyncRunner Run(DoWorkEventHandler doWorkEventHandler);

        AsyncRunner WhenComplete(RunWorkerCompletedEventHandler completedEventHandler);

        void Execute();
    }
}