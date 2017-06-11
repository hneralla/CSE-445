using System.Xml;
using System.Security.Cryptography;
using System.Web.Services.Description;
using System.Xml.Schema;
using System.Collections.Generic;

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
            List<string> WsOpDetails = new List<string>();
            XmlTextReader xd = new XmlTextReader(url);

            ServiceDescription myDescription = ServiceDescription.Read(xd);
            Types dataTypes = myDescription.Types;
            XmlSchema schemaElement = dataTypes.Schemas[0];
            PortTypeCollection portTypes = myDescription.PortTypes;

            string serviceName = myDescription.Services[0].Name;

            foreach(PortType type in portTypes)
            {
                foreach(Operation op in type.Operations)
                {
                    string opName = op.Name;
                    string inMessage = op.Messages.Input.Message.Name;
                    string outMessage = op.Messages.Output.Message.Name;

                    string inMessagePart = myDescription.Messages[inMessage].Parts[0].Element.Name;
                    string outMessagePart = myDescription.Messages[outMessage].Parts[0].Element.Name;

                    Parameter[] inputParameters = GetParameters(myDescription, inMessagePart);
                    Parameter[] outputParameters = GetParameters(myDescription, outMessagePart);

                    string inputParams = "";
                    string outParams = "";

                    foreach(Parameter param in inputParameters)
                    {
                        inputParams += param.Type + "/";
                    }

                    foreach(Parameter param in outputParameters)
                    {
                        outParams += param.Type + "/";
                    }

                    string data = opName + ":" + inputParams + ":" + outParams;
                    WsOpDetails.Add(data); // inserts data into the array 
                }
            }

            return WsOpDetails.ToArray();
        }

        private static Parameter[] GetParameters(ServiceDescription serviceDescription, string messagePartName)
        {
            List<Parameter> parameters = new List<Parameter>();

            Types types = serviceDescription.Types;
            XmlSchema xmlSchema = types.Schemas[0];

            foreach (object item in xmlSchema.Items)
            {
                XmlSchemaElement schemaElement = item as System.Xml.Schema.XmlSchemaElement;
                if (schemaElement != null)
                {
                    if (schemaElement.Name == messagePartName)
                    {
                        XmlSchemaType schemaType = schemaElement.SchemaType;
                        XmlSchemaComplexType complexType = schemaType as System.Xml.Schema.XmlSchemaComplexType;
                        if (complexType != null)
                        {
                            XmlSchemaParticle particle = complexType.Particle;
                            XmlSchemaSequence sequence = particle as System.Xml.Schema.XmlSchemaSequence;
                            if (sequence != null)
                            {
                                foreach (XmlSchemaElement childElement in sequence.Items)
                                {
                                    string parameterName = childElement.Name;
                                    string parameterType = childElement.SchemaTypeName.Name;
                                    parameters.Add(new Parameter(parameterName, parameterType));
                                }
                            }
                        }
                    }
                }
            }
            return parameters.ToArray();
        }


        public struct Parameter
        {
            /// <summary>
            /// constructor
            /// </summary>
            /// <param name="name">
            /// <param name="type">
            public Parameter(string name, string type)
            {
                this.Name = name;
                this.Type = type;
            }

            /// <summary>
            /// Name
            /// </summary>
            public string Name;
            /// <summary>
            /// Type
            /// </summary>
            public string Type;
        }
    }
}
