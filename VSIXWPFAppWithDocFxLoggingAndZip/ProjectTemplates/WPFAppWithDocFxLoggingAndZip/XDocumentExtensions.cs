using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace $safeprojectname$
{
    /// <summary>Class XDocumentExtensions</summary>
    public static class XDocumentExtensions
    {
        /// <summary>Gets the x document.</summary>
        /// <param name="document">The document.</param>
        /// <returns>System.Xml.Linq.XDocument.</returns>
        public static XDocument GetXDocument(this XmlDocument document)
        {
            XDocument xDoc = new();
            using (XmlWriter xmlWriter = xDoc.CreateWriter())
                document.WriteTo(xmlWriter);
            XmlDeclaration decl = document.ChildNodes.OfType<XmlDeclaration>().FirstOrDefault();
            if (decl is not null)
            {
                xDoc.Declaration = new XDeclaration(decl.Version, decl.Encoding, decl.Standalone);
            }
            return xDoc;
        }
        /// <summary>Gets the x element.</summary>
        /// <param name="node">The node.</param>
        /// <returns>System.Xml.Linq.XElement.</returns>
        public static XElement GetXElement(this XmlNode node)
        {
            XDocument xDoc = new();
            using (XmlWriter xmlWriter = xDoc.CreateWriter())
                node.WriteTo(xmlWriter);
            return xDoc.Root;
        }
        /// <summary>Gets the XML document.</summary>
        /// <param name="document">The document.</param>
        /// <returns>System.Xml.XmlDocument.</returns>
        public static XmlDocument GetXmlDocument(this XDocument document)
        {
            using (XmlReader xmlReader = document.CreateReader())
            {
                XmlDocument xmlDoc = new();
                xmlDoc.Load(xmlReader);
                if (document.Declaration is not null)
                {
                    XmlDeclaration dec = xmlDoc.CreateXmlDeclaration(document.Declaration.Version,
                        document.Declaration.Encoding, document.Declaration.Standalone);
                    xmlDoc.InsertBefore(dec, xmlDoc.FirstChild);
                }
                return xmlDoc;
            }
        }
        /// <summary>Gets the XML node.</summary>
        /// <param name="element">The element.</param>
        /// <returns>System.Xml.XmlNode.</returns>
        public static XmlNode GetXmlNode(this XElement element)
        {
            using (XmlReader xmlReader = element.CreateReader())
            {
                XmlDocument xmlDoc = new();
                xmlDoc.Load(xmlReader);
                return xmlDoc;
            }
        }
    }
}
