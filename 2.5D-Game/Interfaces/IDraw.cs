using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Core.Interfaces;

public interface IDraw
{
    public void Draw(GameTime pGameTime, SpriteBatch pSpriteBatch);
}
