using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Utils.Interfaces;

namespace Utils.GameObjects;

public class Rectangle : GameObject, ILoadDrawAndUpdate
{
    public void LoadContent()
    {
        BaseTexture = LoadTexture("rectangle");
        Size = 0.2f;
        Speed = 200;
        SetCentered();
        MovingHelper.ConfineToParentBounds = true;
    }

    public void Update(GameTime pGameTime)
    {
        MovingHelper.Move(this, pGameTime);
    }

    public void Draw(GameTime pGameTime, SpriteBatch pSpriteBatch)
    {
        Draw(pSpriteBatch);
    }
}
