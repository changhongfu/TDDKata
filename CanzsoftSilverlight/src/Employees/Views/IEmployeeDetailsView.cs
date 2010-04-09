using Employees.Models;

namespace Employees.Views
{
    public interface IEmployeeDetailsView
    {
        void SetEmployee(Employee employee);
    }
}