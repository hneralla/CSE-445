using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WeatherConditions
{ 
    [ServiceContract]
    public interface IService1
    {
        // This operation returns a string of data about the user-given ZIP code
        [OperationContract]
        string[] getLocationDetails(string zipcode);
    }
}
