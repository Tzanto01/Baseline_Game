using Microsoft.Xna.Framework;

namespace Utils.Managers
{
    public static class WindowManager
    {
        private static GameWindow _window;

        public static void SetWindow(GameWindow pWindow)
        {
            _window = pWindow;
        }

        public static Rectangle GetWindowBounds()
        {
            return _window.ClientBounds;
        }

        public static void SetResizable(bool pIsResizable)
        {
            _window.AllowUserResizing = pIsResizable;
        }
    }
}
