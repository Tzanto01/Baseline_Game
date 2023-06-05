using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Core.Handlers;

internal abstract class Handler<T>
{
    internal static readonly List<T> Objects = new();

    internal abstract void Handle(GameTime pGameTime = null, SpriteBatch pSpriteBatch = null);

    internal static void Add(T pObject)
    {
        Objects.Add(pObject);
    }

    internal static void AddRange(IEnumerable<T> pObjects)
    {
        Objects.AddRange(pObjects);
    }
}
