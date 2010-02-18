using System.ComponentModel;
using System.Windows.Input;

namespace Canzsoft.Silverlight.Tools.Commands
{
    public class AsyncCommandDecorator : CommandDecorator
    {
        private readonly BackgroundWorker _backgroundWorker;

        public AsyncCommandDecorator(ICommand command) : base(command)
        {
            _backgroundWorker = new BackgroundWorker();
            _backgroundWorker.DoWork += (sender, args) => command.Execute(args.Argument);
        }

        public BackgroundWorker BackgroundWorker
        {
            get { return _backgroundWorker; }
        }

        public override void Execute(object parameter)
        {
            _backgroundWorker.RunWorkerAsync(parameter);
        }
    }
}