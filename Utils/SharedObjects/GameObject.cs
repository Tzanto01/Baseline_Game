using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Utils.Handlers;
using Utils.Interfaces;
using Utils.Managers;
using Utils.MovingLogic;

namespace Utils.SharedObjects;

public abstract class GameObject
{
    public Vector2 Position { get; set; } = Vector2.Zero;
    public Vector2 Origin { get; set; } = Vector2.Zero;
    public float Speed { get; set; } = 0;
    public float Size { get; set; } = 1;
    public Microsoft.Xna.Framework.Rectangle? Source { get; set; }
    public Color Color { get; set; } = Color.White;
    public float Rotation { get; set; } = 0;
    public SpriteEffects Effects { get; set; } = SpriteEffects.None;
    public float Layer { get; set; } = 0;
    public bool CanPlayerMove { get; init; } = false;
    public float Height => BaseTexture.Height * Size;
    public float Width => BaseTexture.Width * Size;

    public MovingHelper MovingHelper;
    public Texture2D BaseTexture;
    public static GraphicsDeviceManager Graphics => GraphicsManager.GetGraphics();

    public GameObject(bool canPlayerMove = false)
    {
        CanPlayerMove = canPlayerMove;
        MovingHelper = new MovingHelper(this, CanPlayerMove);

        if (this is IUpdate updatingObject)
            UpdateHandler.Add(updatingObject);
        if (this is IDraw drawingObject)
            DrawHandler.Add(drawingObject);
        if (this is ILoadContent loadingObject)
            LoadContentHandler.Add(loadingObject);
    }

    public void SetCentered()
    {
        Position = new Vector2(Graphics.PreferredBackBufferWidth / 2, Graphics.PreferredBackBufferHeight / 2);
        Origin = new Vector2(BaseTexture.Width / 2, BaseTexture.Height / 2);
    }

    public static Texture2D LoadTexture(string pTextureName)
        => CustomContentManager.LoadTexture<Texture2D>(pTextureName);

    public void Draw(SpriteBatch pSpriteBatch)
    {
        pSpriteBatch.Draw(BaseTexture, Position, Source, Color, Rotation, Origin, Size, Effects, Layer);
    }
}
