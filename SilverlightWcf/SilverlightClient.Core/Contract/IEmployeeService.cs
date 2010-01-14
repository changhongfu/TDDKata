using System;
using System.ServiceModel;

namespace Contract
{
    [ServiceContract(ConfigurationName = "Wcf.IEmployeeService")]
    public interface IEmployeeService
    {
        [OperationContract(AsyncPattern = true, Action = "http://tempuri.org/IEmployeeService/LoadEmployees", ReplyAction = "http://tempuri.org/IEmployeeService/LoadEmployeesResponse")]
        IAsyncResult BeginLoadEmployees(AsyncCallback callback, object asyncState);

        EmployeeInfo[] EndLoadEmployees(IAsyncResult result);
    }
}