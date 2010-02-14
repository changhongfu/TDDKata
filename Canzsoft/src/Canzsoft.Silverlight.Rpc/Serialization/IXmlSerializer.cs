namespace Canzsoft.Silverlight.Rpc.Serialization
{
    public interface IXmlSerializer
    {
        string Serialize<T>(T toBeSerialzed);
        T Deserialize<T>(string xmlString);
    }
}