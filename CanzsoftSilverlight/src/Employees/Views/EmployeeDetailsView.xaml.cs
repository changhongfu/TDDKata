using Employees.Models;

namespace Employees.Views
{
    public partial class EmployeeDetailsView : IEmployeeDetailsView
    {
        public EmployeeDetailsView()
        {
            InitializeComponent();
        }

        public void SetEmployee(Employee employee)
        {
            DataContext = employee;
        }
    }
}
