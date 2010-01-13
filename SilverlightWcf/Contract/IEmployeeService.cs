using System.ServiceModel;

namespace Contract
{
    [ServiceContract]
    public interface IEmployeeService
    {
        [OperationContract]
        EmployeeInfo[] LoadEmployees();
    }
}