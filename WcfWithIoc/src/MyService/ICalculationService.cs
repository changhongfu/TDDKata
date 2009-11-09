using System.ServiceModel;

namespace MyService
{
    [ServiceContract]
    public interface ICalculationService
    {
        [OperationContract]
        int Add(int num1, int num);
    }
}
