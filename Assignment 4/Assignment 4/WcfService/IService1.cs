using System.ServiceModel;

namespace WcfService
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string verification(string xmlUrl, string xslUrl); // takes a URL for xml validation

        [OperationContract]
        string transformation(string xmlUrl, string xslUrl); // transforms the xml to html using the xsl
    }
    
}
