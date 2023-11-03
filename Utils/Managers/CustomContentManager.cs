using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;

namespace Utils.Managers;

public static class CustomContentManager
{
    private static ContentManager _Content;
    public static void SetContent(ContentManager pContent)
    {
        _Content = pContent;
    }

    public static IEnumerable<T> LoadTextures<T>(IEnumerable<string> pTextureNames) where T : Texture
        => pTextureNames.Select(LoadTexture<T>);

    public static T LoadTexture<T>(string pTextureName) where T : Texture
        => _Content.Load<T>(pTextureName);

    public static SpriteFont LoadSpriteFont(string pFontName)
        => _Content.Load<SpriteFont>(APPLICATIONFONTFOLDER + pFontName);
}
