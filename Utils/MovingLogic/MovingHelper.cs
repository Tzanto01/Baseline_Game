using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Drawing;
using Utils.GameObjects;

namespace Utils.MovingLogic;

public class MovingHelper
{
    public bool ConfineToParentBounds { get; set; } = true;
    // ToDo: Implement Parent-Size
    public void Move(GameObject pObject, GameTime pGameTime, MovingDirection pDirection = MovingDirection.All, float pObjectSpeed = float.NaN, Size pParentSize = new Size())
    {
        if (pDirection == MovingDirection.None)
            return;

        var kstate = Keyboard.GetState();
        var speed = float.IsNaN(pObjectSpeed) ? pObject.Speed : pObjectSpeed;
        var canMoveAll = (pDirection & MovingDirection.All) == MovingDirection.All;
        var size = pParentSize == default ? new Size() : pParentSize;

        if (kstate.IsKeyDown(Keys.Up) && (canMoveAll || (pDirection & MovingDirection.Up) == MovingDirection.Up))
            pObject.Position.Y -= speed * (float)pGameTime.ElapsedGameTime.TotalSeconds;

        if (kstate.IsKeyDown(Keys.Down) && (canMoveAll || (pDirection & MovingDirection.Down) == MovingDirection.Down))
            pObject.Position.Y += speed * (float)pGameTime.ElapsedGameTime.TotalSeconds;

        if (kstate.IsKeyDown(Keys.Left) && (canMoveAll || (pDirection & MovingDirection.Left) == MovingDirection.Left))
            pObject.Position.X -= speed * (float)pGameTime.ElapsedGameTime.TotalSeconds;

        if (kstate.IsKeyDown(Keys.Right) && (canMoveAll || (pDirection & MovingDirection.Right) == MovingDirection.Right))
            pObject.Position.X += speed * (float)pGameTime.ElapsedGameTime.TotalSeconds;

        CheckParentSize(pObject, size);
    }

    public void MoveInstant(GameObject pObject, float pMovingDistance, MovingDirection pDirection = MovingDirection.All, Size pParentSize = new Size())
    {
        if (pDirection == MovingDirection.None)
            return;

        var kstate = Keyboard.GetState();
        var canMoveAll = (pDirection & MovingDirection.All) == MovingDirection.All;
        var size = pParentSize == default ? new Size() : pParentSize;

        if (kstate.IsKeyDown(Keys.Up) && (canMoveAll || (pDirection & MovingDirection.Up) == MovingDirection.Up))
            pObject.Position.Y -= pMovingDistance;

        if (kstate.IsKeyDown(Keys.Down) && (canMoveAll || (pDirection & MovingDirection.Down) == MovingDirection.Down))
            pObject.Position.Y += pMovingDistance;

        if (kstate.IsKeyDown(Keys.Left) && (canMoveAll || (pDirection & MovingDirection.Left) == MovingDirection.Left))
            pObject.Position.X -= pMovingDistance;

        if (kstate.IsKeyDown(Keys.Right) && (canMoveAll || (pDirection & MovingDirection.Right) == MovingDirection.Right))
            pObject.Position.X += pMovingDistance;

        CheckParentSize(pObject, size);
    }

    private void CheckParentSize(GameObject pObject, Size size)
    {
        if (!ConfineToParentBounds || size == default)
            return;

        if (pObject.Position.X > size.Width - pObject.BaseTexture.Width / 2)
            pObject.Position.X = size.Width - pObject.BaseTexture.Width / 2;
        else if (pObject.Position.X < pObject.BaseTexture.Width / 2)
            pObject.Position.X = pObject.BaseTexture.Width / 2;

        if (pObject.Position.Y > size.Height - pObject.BaseTexture.Height / 2)
            pObject.Position.Y = size.Height - pObject.BaseTexture.Height / 2;
        else if (pObject.Position.Y < pObject.BaseTexture.Height / 2)
            pObject.Position.Y = pObject.BaseTexture.Height / 2;
    }
}
