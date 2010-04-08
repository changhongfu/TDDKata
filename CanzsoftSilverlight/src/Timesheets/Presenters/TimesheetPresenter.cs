using System;
using DemoApp.Shared.Messaging;
using DemoApp.Shared.Views;
using Microsoft.Practices.Composite.Events;
using Microsoft.Practices.Composite.Regions;
using Timesheets.Views;

namespace Timesheets.Presenters
{
    public class TimesheetPresenter
    {
        private readonly IModuleMenuItemView _menuItemView;
        private readonly ITimesheetListView _timesheetListView;
        private readonly IRegionManager _regionManager;
        private readonly IEventAggregator _eventAggregator;

        public TimesheetPresenter(IModuleMenuItemView menuItemView, ITimesheetListView timesheetListView, IRegionManager regionManager)
        {
            _menuItemView = menuItemView;
            _timesheetListView = timesheetListView;
            _regionManager = regionManager;
        }

        public void InitialiseView()
        {
            _regionManager.RegisterViewWithRegion("MainMenuRegion", () => _menuItemView);
            _regionManager.RegisterViewWithRegion("WorkspaceRegion", () => _timesheetListView);
            _regionManager.Regions["WorkspaceRegion"].Deactivate(_timesheetListView);

            _menuItemView.Clicked += (sender, args) => OpenTimesheetList();
        }

        private void OpenTimesheetList()
        {
            _regionManager.Regions["WorkspaceRegion"].Activate(_timesheetListView);
        }

        private void SendOpenEmployeeMessage(int employeeId)
        {
            _eventAggregator.GetEvent<OpenEmployeeEvent>().Publish(employeeId);
        }
    }
}