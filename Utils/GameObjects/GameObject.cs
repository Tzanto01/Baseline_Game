using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Utils.Handlers;
using Utils.Interfaces;
using Utils.Managers;
using Utils.MovingLogic;

namespace Utils.GameObjects;

public class GameObject
{
    public Vector2 Position;
    public float Speed;
    public MovingHelper MovingHelper;
    public Texture2D BaseTexture;
    public GraphicsDeviceManager Graphics
    {
        get => GraphicsManager.GetGraphics();
    }
    public float ObjectScale { get; set; }

    public GameObject()
    {
        MovingHelper = new MovingHelper();

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
    }

    public Texture2D LoadTexture(string pTextureName)
    {
        return TextureManager.LoadTexture<Texture2D>(pTextureName);
    }

    public void DrawCentered(SpriteBatch pSpriteBatch)
    {
        pSpriteBatch.DrawCentered(BaseTexture, Position, Color.White);
    }
}
