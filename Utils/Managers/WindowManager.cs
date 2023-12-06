using System;
using Microsoft.Xna.Framework;

namespace Utils.Managers
{
    public static class WindowManager
    {
        public static event Action<bool> WindowSizeChanged;
        public static Action<Vector2> WindowMoved;
        private static Vector2 _lastKnownPosition;
        private static GameWindow _window;

        public static void SetWindow(GameWindow pWindow)
        {
            _window = pWindow;
            _window.ClientSizeChanged += OnWindowSizeChanged;
        }

        public static void Update()
        {
            Vector2 currentPosition = new Vector2(_window.ClientBounds.X, _window.ClientBounds.Y);
            if (currentPosition != _lastKnownPosition)
            {
                _lastKnownPosition = currentPosition;
                WindowMoved?.Invoke(currentPosition);
            }
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
            WindowSizeChanged?.Invoke(_window.ClientBounds.Width == 0 || _window.ClientBounds.Height == 0);
        }

        public static void SetTitle(string pTitle)
        {
            _window.Title = pTitle;
        }
    }
}
