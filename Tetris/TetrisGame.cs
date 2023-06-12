using System;
using System.Reflection;
using Utils.Interfaces;

namespace Tetris
{
    public class TetrisGame : IGame
    {
        public Guid Id { get; }

        public TetrisGame()
        {
            var assembly = Assembly.GetAssembly(typeof(TetrisGame));
        }
    }
}
