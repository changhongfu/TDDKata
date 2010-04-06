namespace Canzsoft.Silverlight.TestApp.Modules
{
    public class EmployeeModule : IModule
    {
        public string Name
        {
            get { return "Employees"; }
        }

        public string ImageUrl
        {
            get { return "/Images/employee.png"; }
        }

        public void Open()
        {
            
        }
    }
}