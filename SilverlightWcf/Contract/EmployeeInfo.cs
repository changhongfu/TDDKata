using System.Runtime.Serialization;

namespace Contract
{
    [DataContract]
    public class EmployeeInfo
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string Position { get; set; }
    }
}
