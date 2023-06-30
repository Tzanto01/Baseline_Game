using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Utils.Interfaces;
using Utils.Managers;

namespace Utils.GameObjects;

public class Ball : GameObject, ILoadDrawAndUpdate
{
    public Ball() : base()
    {
        SetCentered();
        Speed = 200f;
    }

    public void Draw(GameTime pGameTime, SpriteBatch pSpriteBatch)
    {
        Draw(pSpriteBatch);
    }

    public void LoadContent()
    {
        BaseTexture = LoadTexture("ball");
    }

    public void Update(GameTime pGameTime)
    {
        MovingHelper.Move(this, pGameTime, pParentSize: WindowManager.GetWindowBounds());
    }
}