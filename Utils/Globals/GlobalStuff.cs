using System.Globalization;
using System.IO;

namespace Utils.Globals;

public static class GlobalStuff
{
    public static string APPLICATIONPATH { get; } = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
    public static string APPLICATIONLANGUAGE { get; } = CultureInfo.InstalledUICulture.ThreeLetterISOLanguageName;
    public static string APPLICATIONDEFAULTFONT { get; } = "defaultfont";
    public static string APPLICATIONFONTFOLDER { get; } = "Fonts\\";
}
