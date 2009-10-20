using System;
using Quark.Tools.Wpf.ViewModel;

namespace DemoApp.ViewModels
{
    public class AddCustomerViewModel : ViewModelBase
    {
        public string DisplayName
        {
            get { return "Add Customer"; }
        }

        public bool IsClosable
        {
            get { return true; }
        }
    }
}