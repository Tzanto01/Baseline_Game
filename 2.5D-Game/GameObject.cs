using Core.Handlers;
using Core.Interfaces;
using Core.KeyBoard;
using Microsoft.Xna.Framework;

namespace Core;

public class GameObject<Texture>
{
    public Vector2 Position;
    public float Speed;
    public MovingHelper MovingHelper;
    public Texture BaseTexture { get; set; }
    public GraphicsDeviceManager Graphics
    {
        get => Program.Game.GetGraphics();
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
}
