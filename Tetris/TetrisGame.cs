using Utils.GameObjects;
using Utils.Interfaces;

namespace Tetris;

public class TetrisGame : IGame
{
    public TetrisGame()
    {
        Initizalize();
    }

    public void Initizalize()
    {
        var ball = new Ball();
    }
}
