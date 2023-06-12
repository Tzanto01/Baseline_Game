using Microsoft.Xna.Framework;

namespace Utils.Managers;

public static class GraphicsManager
{
    private static GraphicsDeviceManager _graphics;

    public static GraphicsDeviceManager GetGraphics()
        => _graphics;

    public static void SetGraphics(GraphicsDeviceManager pGraphics)
        => _graphics = pGraphics;
}
