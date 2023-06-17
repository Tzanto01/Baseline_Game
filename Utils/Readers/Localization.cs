using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace Utils.Readers;

public static class Localization
{
    private static List<LocalizationEntry> _entries = new();
    internal static List<LocalizationEntry> Entries
    {
        get => _entries;
        set => _entries = value;
    }

    public static void Initialize()
    {
        LoadLocalization();
    }

    public static void LoadLocalization()
    {
        Entries.Clear();
        var localization = XMLReader.ReadXML(APPLICATIONPATH + "\\Localization.xml");

        foreach (XmlElement childnode in localization.DocumentElement.ChildNodes)
        {
            var entry = new LocalizationEntry()
            {
                MessageKey = childnode.Attributes["key"].Value
            };

            foreach (XmlElement subnode in childnode.ChildNodes)
            {
                entry.MessageValue.Add(subnode.Name, subnode.InnerText);
            }

            Entries.Add(entry);
        }
    }

    public static string GetMessage(string pMessageKey)
    {
        var entry = Entries.FirstOrDefault(x => x.MessageKey.ToLower() == pMessageKey.ToLower());
        if (entry == null)
            return $"<{pMessageKey}>";

        var entryLocalized = entry.MessageValue[APPLICATIONLANGUAGE];
        if (entryLocalized == null)
            return $"<{pMessageKey}>";

        return entryLocalized;
    }

    public static string GetMessageFormatted(string pMessageKey, params string[] values)
    {
        var message = GetMessage(pMessageKey);
        if (values.Length == 0 || message == $"<{pMessageKey}>")
            return message;

        var newMessage = string.Format(message, values);
        return newMessage;
    }


}

internal class LocalizationEntry
{
    public string MessageKey { get; set; }
    public Dictionary<string, string> MessageValue { get; set; } = new Dictionary<string, string>();
}
