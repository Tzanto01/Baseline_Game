using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Drawing;

namespace Core.KeyBoard;

public class MovingHelper
{
    public bool ConfineToParentBounds { get; set; } = true;
    // ToDo: Implement Parent-Size
    public void Move<T>(GameObject<T> pObject, GameTime pGameTime, MovingDirection pDirection = MovingDirection.All, float pObjectSpeed = float.NaN, Size parentSize = new Size())
    {
        if (pDirection == MovingDirection.None)
            return;

        var kstate = Keyboard.GetState();
        var speed = float.IsNaN(pObjectSpeed) ? pObject.Speed : pObjectSpeed;
        var canMoveAll = (pDirection & MovingDirection.All) == MovingDirection.All;
        var size = parentSize == default ? new Size() : parentSize;

        if (kstate.IsKeyDown(Keys.Up) && (canMoveAll || (pDirection & MovingDirection.Up) == MovingDirection.Up))
            pObject.Position.Y -= speed * (float)pGameTime.ElapsedGameTime.TotalSeconds;

        if (kstate.IsKeyDown(Keys.Down) && (canMoveAll || (pDirection & MovingDirection.Down) == MovingDirection.Down))
            pObject.Position.Y += speed * (float)pGameTime.ElapsedGameTime.TotalSeconds;

        if (kstate.IsKeyDown(Keys.Left) && (canMoveAll || (pDirection & MovingDirection.Left) == MovingDirection.Left))
            pObject.Position.X -= speed * (float)pGameTime.ElapsedGameTime.TotalSeconds;

        if (kstate.IsKeyDown(Keys.Right) && (canMoveAll || (pDirection & MovingDirection.Right) == MovingDirection.Right))
            pObject.Position.X += speed * (float)pGameTime.ElapsedGameTime.TotalSeconds;

        if (!ConfineToParentBounds || pObject is not GameObject<Texture2D> Object2D || size == default)
            return;

        if (pObject.Position.X > size.Width - Object2D.BaseTexture.Width / 2)
            pObject.Position.X = size.Width - Object2D.BaseTexture.Width / 2;
        else if (pObject.Position.X < Object2D.BaseTexture.Width / 2)
            pObject.Position.X = Object2D.BaseTexture.Width / 2;

        if (pObject.Position.Y > size.Height - Object2D.BaseTexture.Height / 2)
            pObject.Position.Y = size.Height - Object2D.BaseTexture.Height / 2;
        else if (pObject.Position.Y < Object2D.BaseTexture.Height / 2)
            pObject.Position.Y = Object2D.BaseTexture.Height / 2;
    }
}
