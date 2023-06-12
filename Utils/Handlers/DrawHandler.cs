using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Utils.Interfaces;

namespace Utils.Handlers;

public class DrawHandler : Handler<IDraw>
{
    public override void Handle(GameTime pGameTime, SpriteBatch pSpriteBatch)
    {
        foreach (var obj in Objects)
        {
            obj.Draw(pGameTime, pSpriteBatch);
        }
    }
}
