using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Utils.Interfaces;

namespace Utils.GameObjects;

public class Rectangle : GameObject<Texture2D>, ILoadDrawAndUpdate
{
    public Rectangle() : base()
    {
        SetCentered();
    }

    public void LoadContent()
    {
        // Create Rectangle Content
        BaseTexture = LoadTexture<Texture2D>("");
    }

    public void Update(GameTime pGameTime)
    {
        throw new System.NotImplementedException();
    }
    public void Draw(GameTime pGameTime, SpriteBatch pSpriteBatch)
    {
        throw new System.NotImplementedException();
    }
}
