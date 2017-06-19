using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Temperature
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        int c2f(int c); //celsius to fahrenheit; celsius is parameter

        [OperationContract]
        int f2c(int f); //fahrenheit to celsius; faranheit is parameter
    }
}
