using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;

namespace WsOperations
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
       public string[] getWsOperations(string url)
        {
           
            XmlDocument xd = new XmlDocument();

            try
            {
                xd.Load(url);
            }
            catch (XmlException xe) 
            {
                return new[] { xe.ToString() }; // converts string to string[]
            }

            XmlNodeList portNodes = xd.SelectSingleNode("wsdl:definitions").SelectNodes("wsdl:portType");

            string[] WsOpDetails = new string[portNodes.Count]; // initializes array with the number of operations (ports) 

            foreach (XmlNode node in portNodes)
            {
                string opName = node.SelectSingleNode("wsdl:operation").Attributes.GetNamedItem("name").Value; // obtains the operation name  
                //string paramTypes =  
            }
            

            return WsOpDetails;
        }
    }
}
