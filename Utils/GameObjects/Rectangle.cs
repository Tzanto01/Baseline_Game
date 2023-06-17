using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Drawing;
using Utils.Interfaces;

namespace Utils.GameObjects;

public class Rectangle : GameObject, ILoadDrawAndUpdate
{
    public Rectangle() : base()
    {
        SetCentered();
    }

    public void LoadContent()
    {
        BaseTexture = LoadTexture("rectangle");
        ObjectScale = 0.5f;
    }

    public void Update(GameTime pGameTime)
    {
        MovingHelper.Move(this, pGameTime, pParentSize: new Size(Graphics.PreferredBackBufferWidth, Graphics.PreferredBackBufferHeight));
    }
    public void Draw(GameTime pGameTime, SpriteBatch pSpriteBatch)
    {
        DrawCentered(pSpriteBatch);
        pSpriteBatch.DrawCentered(BaseTexture, Position, Color.White);
    }
}
