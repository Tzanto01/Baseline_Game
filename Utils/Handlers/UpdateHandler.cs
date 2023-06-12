using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Utils.Interfaces;

namespace Utils.Handlers;

public class UpdateHandler : Handler<IUpdate>
{
    public override void Handle(GameTime pGameTime = null, SpriteBatch pSpriteBatch = null)
    {
        foreach (var obj in Objects)
        {
            obj.Update(pGameTime);
        }
    }
}
