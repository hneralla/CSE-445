using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Xsl;
using System.IO;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService
{ 
    public class Service1 : IService1
    {
        public string verification(string xmlUrl, string xsdUrl)
        {
            string output = "";
            string xml;
            XmlDocument xd = new XmlDocument();
            XmlSchemaSet set = new XmlSchemaSet();
           
            using (var wc = new System.Net.WebClient())
            {
                xml = wc.DownloadString(xmlUrl); // Downloads the XML document using the URL
            }

            xd.LoadXml(xml); // Loads xml string into XmlDocument object
            set.Add(null, xsdUrl); // Loads the schema into the schema set

            return output;
        }

        public string transformation(string xmlUrl, string xslUrl)
        {
            string xml; // to store the xml string
            string xsl; // to store the xsl string
            StringWriter htmlResult = new StringWriter(); // to store the html string
            XslCompiledTransform trans = new XslCompiledTransform(); // to transform the XML data

            using (var wc = new System.Net.WebClient())
            {
                xml = wc.DownloadString(xmlUrl); // Downloads the XML document using the URL
                xsl = wc.DownloadString(xslUrl); // Downloads the XSL document using the URL
            }

            trans.Load(XmlReader.Create(new StringReader(xsl)));  
            trans.Transform(XmlReader.Create(new StringReader(xml)), null, htmlResult);

            return htmlResult.ToString();
        }
    }
}
