using System.Xml.Serialization;
using Canzsoft.Silverlight.Rpc.Messaging;
using Canzsoft.Silverlight.TestApp.Models;

namespace Canzsoft.Silverlight.TestApp.Messaging
{
    [XmlRoot("GetEmployeesResponse")]
    public class GetEmployeesResponse : Response
    {
        public EmployeeInfo[] Employees { get; set; }
    }
}