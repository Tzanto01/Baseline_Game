using Microsoft.Xna.Framework.Graphics;
using Utils.GameObjects;
using Utils.Managers;

namespace Objects
{
    public abstract class TextObject : GameObject
    {
        public string CurrentText { get; internal set; }
        private SpriteFont _currentFont;
        public SpriteFont CurrentFont
        {
            get
            {
                return _currentFont;
            }
            internal set
            {
                _currentFont = value;
                BaseTexture = _currentFont.Texture;
            }
        }

        public TextObject() : base()
        {
            CurrentFont = CustomContentManager.LoadSpriteFont(APPLICATIONDEFAULTFONT);
        }

        public void SetText(string pText)
        {
            CurrentText = pText;
        }

        public void SetFontByName(string pFontName)
        {
            CurrentFont = CustomContentManager.LoadSpriteFont(pFontName);
        }

        public void DrawString(SpriteBatch pSpriteBatch)
        {
            pSpriteBatch.DrawString(CurrentFont, CurrentText, Position, Color, Rotation, Origin, Size, Effects, Layer);
        }
    }
}
