using System;
using Utils.Attributes;

namespace Utils.Managers
{
    public static class GameManager
    {
        private static Type _currentGameType;

        public static bool SetGameType(Type pGameType)
        {
            if (Attribute.GetCustomAttribute(pGameType, typeof(GameAttribute)) is null)
            {
                return false;
            }
            _currentGameType = pGameType;
            return true;
        }

        public static object InitializeCurrentGame()
            => Activator.CreateInstance(_currentGameType);
    }
}
