using System.Xml;

namespace Utils.Readers;

public static class XMLReader
{
    public static XmlDocument ReadXML(string pPath)
    {
        var doc = new XmlDocument();
        doc.Load(pPath);

        return doc;
    }
}
