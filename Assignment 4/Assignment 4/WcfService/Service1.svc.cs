using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Xsl;
using System.IO;
using System.Net;

namespace WcfService
{ 
    public class Service1 : IService1
    {
        // Author: Harith Neralla
        // ASU CSE 445 Summer 2017
        // 06/24/2017

        // This service includes two operations: XML Verficiation (XML Schema) and XML Transformation (XSLT)
        // The parameters are URL links

        // Takes a URL for an XML document and an XML Schema document and verifies them. Returns error information.
        public string verification(string xmlUrl, string xsdUrl)
        {
            string output = "No Errors"; // default output 
            string xml;
            var set = new XmlSchemaSet();

            using (var wc = new WebClient())
            {
                try
                {
                    xml = wc.DownloadString(xmlUrl); // Downloads the XML document using the URL
                }
                catch(WebException e)
                {
                    output = "XML INVALID";
                    return output;
                }
            }
            
            var xd = new XmlDocument(); // Loads xml string into XmlDocument object
            try
            {
                xd.Load(xmlUrl);
            }
            catch(XmlException e)
            {
                output = e.ToString();
                return output;
            }
            
            var xdoc = XmlDocToXDoc(xd);

            set.Add(null, xsdUrl); // Loads the schema into the schema set

            xdoc.Validate(set, (o, e) => // tries to validate the xml document
            {
                 output = e.Message; 
            });

            return output;
        }

        private static XDocument XmlDocToXDoc(XmlDocument xdoc)
        {
            return XDocument.Load(new XmlNodeReader(xdoc));
        }

        // Takes URLs for XML and XSL documents and transforms the XML into HTML. Returns HTML in the form of a string.
        public string transformation(string xmlUrl, string xslUrl)
        {
            string xml; // to store the xml string
            string xsl; // to store the xsl string
            var htmlResult = new StringWriter(); // to store the html string
            var trans = new XslCompiledTransform(); // to transform the XML data

            using (var wc = new System.Net.WebClient())
            {
                try
                {
                    xml = wc.DownloadString(xmlUrl); // Downloads the XML document using the URL
                    xsl = wc.DownloadString(xslUrl); // Downloads the XSL document using the URL
                }
                catch
                {
                    htmlResult.WriteLine("Invalid Links");
                    return htmlResult.ToString();
                }
                
            }

            trans.Load(XmlReader.Create(new StringReader(xsl))); // loads the xsl file 

            try
            {
                try
                {
                    trans.Transform(XmlReader.Create(new StringReader(xml)), null, htmlResult); // transforms the xml to html
                }catch(XmlException e)
                {
                    htmlResult.WriteLine(e);
                    return htmlResult.ToString();
                }
                
            }
            catch (XsltException e1)
            {
                htmlResult.WriteLine(e1); // writes the error to the output string
            }
            
            return htmlResult.ToString();
        }
    }
}
