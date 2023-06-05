using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Core.Managers;

public static class TextureManager
{
    private static ContentManager _Content;
    internal static void SetContent(ContentManager pContent)
    {
        _Content = pContent;
    }

    public static IEnumerable<T> LoadTextures<T>(IEnumerable<string> pTextureNames) where T : Texture
    {
        foreach (var textureName in pTextureNames)
        {
            yield return LoadTexture<T>(textureName);
        }
    }

    public static T LoadTexture<T>(string pTextureName) where T : Texture
        => _Content.Load<T>(pTextureName);
}
