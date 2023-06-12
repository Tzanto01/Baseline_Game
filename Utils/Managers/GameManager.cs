using System;
using Utils.Interfaces;

namespace Utils.Managers
{
    public static class GameManager
    {
        private static Type _currentGameType;

        public static void SetGameType(Type pGameType)
        {
            _currentGameType = pGameType;
        }

        public static IGame InitializeCurrentGame()
            => Activator.CreateInstance(_currentGameType) as IGame;
    }
}
