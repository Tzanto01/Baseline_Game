using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Core
{
    public static class SpriteBatchExtensions
    {
        public static void DrawCentered(this SpriteBatch pSpriteBatch, Texture2D pTexture, Vector2 pPosition, Color pColor)
        {
            pSpriteBatch.Draw(pTexture, pPosition, null, pColor, 0f, new Vector2(pTexture.Width / 2, pTexture.Height / 2), Vector2.One, SpriteEffects.None, 0f);
        }
    }
}
