using Core.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Core.Handlers;

internal class UpdateHandler : Handler<IUpdate>
{
    internal override void Handle(GameTime pGameTime = null, SpriteBatch pSpriteBatch = null)
    {
        foreach (var obj in Objects)
        {
            obj.Update(pGameTime);
        }
    }
}
