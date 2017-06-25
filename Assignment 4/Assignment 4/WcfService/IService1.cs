using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string verification(string xmlUrl, string xslUrl);

        [OperationContract]
        string transformation(string xmlUrl, string xslUrl);
    }
    
}
