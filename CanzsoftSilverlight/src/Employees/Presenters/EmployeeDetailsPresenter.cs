using Employees.Views;
using Microsoft.Practices.Composite.Regions;

namespace Employees.Presenters
{
    public class EmployeeDetailsPresenter
    {
        private readonly IRegionManager _regionManager; 
        private readonly IEmployeeDetailsView _employeeDetailsView;

        public EmployeeDetailsPresenter(IRegionManager regionManager, IEmployeeDetailsView employeeDetailsView)
        {
            _regionManager = regionManager;
            _employeeDetailsView = employeeDetailsView;
        }

        public void ShowView()
        {
            _regionManager.AddToRegion("WorkspaceRegion", _employeeDetailsView);
            _regionManager.Regions["WorkspaceRegion"].Activate(_employeeDetailsView);
        }
    }
}