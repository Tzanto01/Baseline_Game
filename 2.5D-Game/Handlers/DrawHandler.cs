using Core.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Core.Handlers;

internal class DrawHandler : Handler<IDraw>
{
    internal override void Handle(GameTime pGameTime, SpriteBatch pSpriteBatch)
    {
        foreach (var obj in Objects)
        {
            obj.Draw(pGameTime, pSpriteBatch);
        }
    }
}
