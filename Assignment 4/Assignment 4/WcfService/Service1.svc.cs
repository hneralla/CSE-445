using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Xsl;
using System.IO;

namespace WcfService
{ 
    public class Service1 : IService1
    {
        public string verification(string xmlUrl, string xsdUrl)
        {
            string output = "No Errors";
            string xml;
       
            XmlSchemaSet set = new XmlSchemaSet();
           
            using (var wc = new System.Net.WebClient())
            {
                xml = wc.DownloadString(xmlUrl); // Downloads the XML document using the URL
            }

            var xdoc = XDocument.Load(xml); // Loads xml string into XmlDocument object
            set.Add("", xsdUrl); // Loads the schema into the schema set

            xdoc.Validate(set, (o, e) =>
            {
                 output = e.Message;
            });

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

            try
            {
                trans.Transform(XmlReader.Create(new StringReader(xml)), null, htmlResult);
            }catch(XsltException e1)
            {
                htmlResult.WriteLine(e1);
            }
            
            return htmlResult.ToString();
        }
    }
}
