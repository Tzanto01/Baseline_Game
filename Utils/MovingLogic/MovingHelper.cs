using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Utils.GameObjects;
using Utils.Managers;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace Utils.MovingLogic;

public class MovingHelper
{
    public bool ConfineToParentBounds { get; set; } = true;
    // ToDo: Implement Parent-Size
    public void Move(GameObject pObject, GameTime pGameTime, MovingDirection pDirection = MovingDirection.All, float pObjectSpeed = float.NaN, Rectangle pParentSize = new Rectangle())
    {
        if (pDirection == MovingDirection.None)
            return;

        var kstate = Keyboard.GetState();
        var speed = float.IsNaN(pObjectSpeed) ? pObject.Speed : pObjectSpeed;
        var canMoveAll = (pDirection & MovingDirection.All) == MovingDirection.All;
        var parentBounds = pParentSize == default ? WindowManager.GetWindowBounds() : pParentSize;

        if (kstate.IsKeyDown(Keys.Up) && (canMoveAll || (pDirection & MovingDirection.Up) == MovingDirection.Up))
            pObject.Position.Y -= speed * (float)pGameTime.ElapsedGameTime.TotalSeconds;

        if (kstate.IsKeyDown(Keys.Down) && (canMoveAll || (pDirection & MovingDirection.Down) == MovingDirection.Down))
            pObject.Position.Y += speed * (float)pGameTime.ElapsedGameTime.TotalSeconds;

        if (kstate.IsKeyDown(Keys.Left) && (canMoveAll || (pDirection & MovingDirection.Left) == MovingDirection.Left))
            pObject.Position.X -= speed * (float)pGameTime.ElapsedGameTime.TotalSeconds;

        if (kstate.IsKeyDown(Keys.Right) && (canMoveAll || (pDirection & MovingDirection.Right) == MovingDirection.Right))
            pObject.Position.X += speed * (float)pGameTime.ElapsedGameTime.TotalSeconds;

        CheckParentSize(pObject, parentBounds);
    }

    public void MoveInstant(GameObject pObject, float pMovingDistance, MovingDirection pDirection = MovingDirection.All, Rectangle pParentSize = new Rectangle())
    {
        if (pDirection == MovingDirection.None)
            return;

        var kstate = Keyboard.GetState();
        var canMoveAll = (pDirection & MovingDirection.All) == MovingDirection.All;
        var size = pParentSize == default ? WindowManager.GetWindowBounds() : pParentSize;

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

    private void CheckParentSize(GameObject pObject, Rectangle pParentSize)
    {
        if (!ConfineToParentBounds || pParentSize == default)
            return;

        if (pObject.Position.X > pParentSize.Width - pObject.Width / 2)
            pObject.Position.X = pParentSize.Width - pObject.Width / 2;
        else if (pObject.Position.X < pObject.Width / 2)
            pObject.Position.X = pObject.Width / 2;

        if (pObject.Position.Y > pParentSize.Height - pObject.Height / 2)
            pObject.Position.Y = pParentSize.Height - pObject.Height / 2;
        else if (pObject.Position.Y < pObject.Height / 2)
            pObject.Position.Y = pObject.Height / 2;
    }
}
