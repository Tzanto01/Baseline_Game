using Core.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Drawing;
using Utils.Managers;
using Color = Microsoft.Xna.Framework.Color;

namespace Core;

public class Ball : GameObject<Texture2D>, ILoadDrawAndUpdate
{
    public Ball() : base()
    {
        Position = new Vector2(Graphics.PreferredBackBufferWidth / 2, Graphics.PreferredBackBufferHeight / 2);
        Speed = 200f;
    }

    public void Draw(GameTime pGameTime, SpriteBatch pSpriteBatch)
    {
        pSpriteBatch.DrawCentered(BaseTexture, Position, Color.White);
    }

    public void LoadContent()
    {
        BaseTexture = TextureManager.LoadTexture<Texture2D>("ball");
    }

    public void Update(GameTime pGameTime)
    {
        MovingHelper.Move(this, pGameTime, parentSize: new Size(Graphics.PreferredBackBufferWidth, Graphics.PreferredBackBufferHeight));
    }
}