using System.Windows.Input;
using Quark.Tools.Mvvm;

namespace DemoApp.ViewModels
{
    public class CommandViewModel : ViewModelBase
    {
        private readonly ICommand command;
        private readonly string displayName;

        public CommandViewModel(ICommand command, string displayName)
        {
            this.command = command;
            this.displayName = displayName;
        }

        public ICommand Command
        {
            get { return command; }
        }

        public string DisplayName
        {
            get { return displayName; }
        }
    }
}