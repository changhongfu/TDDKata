using System;

namespace Canzsoft.Silverlight.TestApp.Modules
{
    public class TimesheetModule : IModule
    {
        public string Name
        {
            get { return "Timesheets"; }
        }

        public string ImageUrl
        {
            get { return "/Images/timesheet.png"; }
        }

        public void Open()
        {
            throw new NotImplementedException();
        }
    }
}