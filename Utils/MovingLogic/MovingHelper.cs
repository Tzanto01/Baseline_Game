using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Drawing;
using Utils.GameObjects;

namespace Utils.MovingLogic;

public class MovingHelper
{
    public bool ConfineToParentBounds { get; set; } = true;
    // ToDo: Implement Parent-Size
    public void Move<T>(GameObject<T> pObject, GameTime pGameTime, MovingDirection pDirection = MovingDirection.All, float pObjectSpeed = float.NaN, Size pParentSize = new Size()) where T : Texture
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

    public void MoveInstant<T>(GameObject<T> pObject, float pMovingDistance, MovingDirection pDirection = MovingDirection.All, Size pParentSize = new Size()) where T : Texture
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

    private void CheckParentSize<T>(GameObject<T> pObject, Size size) where T : Texture
    {
        if (!ConfineToParentBounds || pObject is not GameObject<Texture2D> object2D || size == default)
            return;

        if (pObject.Position.X > size.Width - object2D.BaseTexture.Width / 2)
            pObject.Position.X = size.Width - object2D.BaseTexture.Width / 2;
        else if (pObject.Position.X < object2D.BaseTexture.Width / 2)
            pObject.Position.X = object2D.BaseTexture.Width / 2;

        if (pObject.Position.Y > size.Height - object2D.BaseTexture.Height / 2)
            pObject.Position.Y = size.Height - object2D.BaseTexture.Height / 2;
        else if (pObject.Position.Y < object2D.BaseTexture.Height / 2)
            pObject.Position.Y = object2D.BaseTexture.Height / 2;
    }
}
