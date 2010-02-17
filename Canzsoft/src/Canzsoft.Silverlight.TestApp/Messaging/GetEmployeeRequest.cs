using System;
using System.Xml.Serialization;
using Canzsoft.Silverlight.Rpc.Messaging;

namespace Canzsoft.Silverlight.TestApp.Messaging
{
    [XmlRoot("GetEmployeeRequest")]
    public class GetEmployeeRequest : Request
    {
        public Guid Id { get; set; }
    }
}