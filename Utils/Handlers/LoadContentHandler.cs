using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Utils.Interfaces;

namespace Utils.Handlers;

public class LoadContentHandler : Handler<ILoadContent>
{
    public override void Handle(GameTime pGameTime = null, SpriteBatch pSpriteBatch = null)
    {
        foreach (var obj in Objects)
        {
            obj.LoadContent();
        }
    }
}
