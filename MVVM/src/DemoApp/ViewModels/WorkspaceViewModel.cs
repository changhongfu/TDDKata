using System;
using System.Windows.Input;
using Quark.Tools.Mvvm;

namespace DemoApp.ViewModels
{
    public abstract class WorkspaceViewModel : ViewModelBase
    {
        public event EventHandler RequestClose;

        protected WorkspaceViewModel()
        {
            CloseCommand = new RelayCommand(p => OnRequestClose());
        }

        public virtual string DisplayName { get; protected set; }

        public ICommand CloseCommand { get; set; }

        private void OnRequestClose()
        {
            var handler = RequestClose;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
    }
}