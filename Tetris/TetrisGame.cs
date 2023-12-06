using Microsoft.Xna.Framework;
using Utils.Attributes;
using Rectangle = Utils.SharedObjects.Rectangle;

namespace Tetris;

[Game]
public class TetrisGame
{
    public TetrisGame()
    {
        Initialize();
    }

    public void Initialize()
    {
        var rectangle = new Rectangle(true)
        {
            Color = Color.Black,
            CanPlayerMove = true
        };
    }
}
