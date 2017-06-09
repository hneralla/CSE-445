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
    // Author: Harith Neralla
    // CSE 445 Assignment 3: Part 1

    public class Service1 : IService1
    {
        // Service 7: WsOperations
        // Description: Analyze a WSDL file in XML format and return operation names and their
        // corresponding input parameter and return types.

        public string[] getWsOperations(string url)
        {
            
            XmlDocument xd = new XmlDocument(); 
            string[] WsOpDetails;
            int opIndex = 0; // to iterate through WsOpDetails

            try
            {
                xd.Load(url); 
            }
            catch (XmlException xe)   
            {
                return new[] { xe.ToString() }; // converts string to string[]
            }

            XmlNode defNode = xd.SelectSingleNode("wsdl:definitions");
            XmlNodeList opNodes = defNode.SelectSingleNode("wsdl:portType").SelectNodes("wsdl:operation");
            XmlNodeList dataTypes = defNode.SelectSingleNode("wsdl:types").SelectSingleNode("xs:schema").SelectNodes("xs:element");

            WsOpDetails = new string[opNodes.Count]; // initializes array with the number of operations (ports) 

            XmlNode elementNode = dataTypes.Item(0); 

            foreach (XmlNode node in opNodes)
            {
                string paramTypes = "";
                string returnType = "";
                string opName = node.Attributes.GetNamedItem("name").Value; // obtains the operation name
                               
                for (int index = 0; index < 2; index++)
                {
                    if (elementNode.Attributes.GetNamedItem("name").Value == opName)
                    {
                        XmlNodeList list = elementNode.SelectSingleNode("xs:complexType")
                                            .SelectSingleNode("xs:sequence").SelectNodes("xs:element"); // list of element nodes (parameters)
                        
                        foreach (XmlNode elNode in list) // iterates through n number of parameters
                        {
                            paramTypes += elNode.Attributes.GetNamedItem("type").Value + "-"; // builds a string of parameter types separated by "-"
                        }

                    }

                    if (elementNode.Attributes.GetNamedItem("name").Value == (opName + "Response"))
                    {
                        returnType = elementNode.SelectSingleNode("xs:complexType").SelectSingleNode("xs:sequence") // obtains return type 
                                      .SelectSingleNode("xs:element").Attributes.GetNamedItem("type").Value; 
                    }

                    elementNode = elementNode.NextSibling; // goes to the next elementNode
                }

                WsOpDetails[opIndex] = returnType + "||" + opName + "||" + paramTypes; // inserts data into the array
                opIndex++; 
            }

            return WsOpDetails;
        }
    }
}
