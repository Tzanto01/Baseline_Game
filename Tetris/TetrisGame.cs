using Microsoft.Xna.Framework;
using Utils.Attributes;
using Utils.SharedObjects;

namespace Tetris;

[Game]
public class TetrisGame
{
    public TetrisGame()
    {
        Initizalize();
    }

    public void Initizalize()
    {
        var textObject = new TextBox()
        {
            Color = Color.Black
        };
        textObject.SetText("BeepBoop");
    }
}
