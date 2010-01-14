using System.ServiceModel;
using Contract;

namespace SilverlightClient.Core
{
    public interface IEmployeeServiceChannel : IEmployeeService, IClientChannel
    {
    }
}