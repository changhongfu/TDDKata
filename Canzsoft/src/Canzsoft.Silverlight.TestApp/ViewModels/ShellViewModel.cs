using System.Collections.Generic;
using Canzsoft.Silverlight.TestApp.Modules;

namespace Canzsoft.Silverlight.TestApp.ViewModels
{
    public class ShellViewModel
    {
        private readonly IList<IModule> _modules;

        public ShellViewModel()
        {
            _modules = new List<IModule>{ new EmployeeModule(), new TimesheetModule() };
        }

        public IList<IModule> Modules
        {
            get { return _modules; }
        }
    }
}