using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Utils.Handlers;
using Utils.Interfaces;
using Utils.Managers;
using Utils.MovingLogic;

namespace Utils.GameObjects;

public class GameObject<T> where T : Texture
{
    public Vector2 Position;
    public float Speed;
    public MovingHelper MovingHelper;
    public T BaseTexture { get; set; }
    public GraphicsDeviceManager Graphics
    {
        get => GraphicsManager.GetGraphics();
    }

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

    public T LoadTexture<T>(string pTextureName) where T : Texture
    {
        return TextureManager.LoadTexture<T>(pTextureName);
    }
}
