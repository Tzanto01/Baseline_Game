using System;
using Microsoft.Xna.Framework;

namespace Utils.Managers
{
    public static class WindowManager
    {
        public static event Action<bool> WindowSizeChanged;

        private static GameWindow _window;

        public static void SetWindow(GameWindow pWindow)
        {
            _window = pWindow;
            _window.ClientSizeChanged += OnWindowSizeChanged;
        }

        public static Rectangle GetWindowBounds()
        {
            return _window.ClientBounds;
        }

        public static void SetResizable(bool pIsResizable)
        {
            _window.AllowUserResizing = pIsResizable;
        }

        private static void OnWindowSizeChanged(object sender, EventArgs e)
        {
            // Trigger the event when the window size changes
            WindowSizeChanged?.Invoke(_window.ClientBounds.Width == 0 || _window.ClientBounds.Height == 0);
        }
    }
}
