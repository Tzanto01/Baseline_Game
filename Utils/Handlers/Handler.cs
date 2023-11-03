using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Utils.Handlers;

public abstract class Handler<T>
{
    protected static readonly List<T> Objects = new();

    public abstract void Handle(GameTime pGameTime = null, SpriteBatch pSpriteBatch = null);

    public static void Add(T pObject)
    {
        Objects.Add(pObject);
    }

    public static void AddRange(IEnumerable<T> pObjects)
    {
        Objects.AddRange(pObjects);
    }
}
