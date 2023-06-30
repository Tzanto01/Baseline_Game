using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Objects;
using Utils.Interfaces;

namespace Utils.SharedObjects
{
    public class TextBox : TextObject, ILoadDrawAndUpdate
    {
        public void LoadContent()
        {
            SetCentered();
        }

        public void Update(GameTime pGameTime)
        {
        }
        public void Draw(GameTime pGameTime, SpriteBatch pSpriteBatch)
        {
            DrawString(pSpriteBatch);
        }
    }
}
