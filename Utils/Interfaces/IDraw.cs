using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Utils.Interfaces;

public interface IDraw
{
    public void Draw(GameTime pGameTime, SpriteBatch pSpriteBatch);
}
