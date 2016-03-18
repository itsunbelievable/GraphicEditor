using System.ServiceModel;
using System.Runtime.Serialization;
using System.Xml;

namespace ShapeInterfaces
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        string GetPathToXml();
    }
}
