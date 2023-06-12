using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Drawing;
using Utils.Interfaces;
using Color = Microsoft.Xna.Framework.Color;

namespace Utils.GameObjects;

public class Ball : GameObject<Texture2D>, ILoadDrawAndUpdate
{
    public Ball() : base()
    {
        SetCentered();
        Speed = 200f;
    }

    public void Draw(GameTime pGameTime, SpriteBatch pSpriteBatch)
    {
        pSpriteBatch.DrawCentered(BaseTexture, Position, Color.White);
    }

    public void LoadContent()
    {
        BaseTexture = LoadTexture<Texture2D>("ball");
    }

    public void Update(GameTime pGameTime)
    {
        MovingHelper.Move(this, pGameTime, pParentSize: new Size(Graphics.PreferredBackBufferWidth, Graphics.PreferredBackBufferHeight));
    }
}