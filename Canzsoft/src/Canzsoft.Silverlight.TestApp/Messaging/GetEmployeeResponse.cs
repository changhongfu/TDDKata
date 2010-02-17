using System.Xml.Serialization;
using Canzsoft.Silverlight.Rpc.Messaging;
using Canzsoft.Silverlight.TestApp.Models;

namespace Canzsoft.Silverlight.TestApp.Messaging
{
    [XmlRoot("GetEmployeeResponse")]
    public class GetEmployeeResponse : Response
    {
        public EmployeeInfo Employee { get; set; }
    }
}