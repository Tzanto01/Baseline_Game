using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Utils.SharedObjects;
using Utils.Managers;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace Utils.MovingLogic;

public class MovingHelper
{
    private Stopwatch _instantMoveSw = new();
    private readonly bool _canPlayerMove;
    public bool ConfineToParentBounds { get; set; } = true;

    public MovingHelper(bool pCanPlayerMove)
    {
        _canPlayerMove = pCanPlayerMove;
    }

    public MovingHelper()
    {
        _canPlayerMove = false;
    }
    
    public void PlayerMove(GameObject pObject, GameTime pGameTime, MovingDirection pDirection = MovingDirection.All, float pObjectSpeed = float.NaN, Rectangle pParentSize = new())
    {
        if (pDirection == MovingDirection.None || !_canPlayerMove)
            return;

        var kState = Keyboard.GetState();
        var speed = float.IsNaN(pObjectSpeed) ? pObject.Speed : pObjectSpeed;
        var canMoveAll = (pDirection & MovingDirection.All) == MovingDirection.All;
        var parentBounds = pParentSize == default ? WindowManager.GetWindowBounds() : pParentSize;

        if (kState.IsKeyDown(Keys.Up) && (canMoveAll || (pDirection & MovingDirection.Up) == MovingDirection.Up))
            pObject.Position.Y -= speed * (float)pGameTime.ElapsedGameTime.TotalSeconds;

        if (kState.IsKeyDown(Keys.Down) && (canMoveAll || (pDirection & MovingDirection.Down) == MovingDirection.Down))
            pObject.Position.Y += speed * (float)pGameTime.ElapsedGameTime.TotalSeconds;

        if (kState.IsKeyDown(Keys.Left) && (canMoveAll || (pDirection & MovingDirection.Left) == MovingDirection.Left))
            pObject.Position.X -= speed * (float)pGameTime.ElapsedGameTime.TotalSeconds;

        if (kState.IsKeyDown(Keys.Right) && (canMoveAll || (pDirection & MovingDirection.Right) == MovingDirection.Right))
            pObject.Position.X += speed * (float)pGameTime.ElapsedGameTime.TotalSeconds;

        CheckParentSize(pObject, parentBounds);
    }

    public void PlayerMoveInstant(GameObject pObject, float pMovingDistance, int pMovingTime = 200, MovingDirection pDirection = MovingDirection.All, Rectangle pParentSize = new Rectangle())
    {
        if (pDirection == MovingDirection.None || !_canPlayerMove)
            return;
        
        switch (_instantMoveSw.IsRunning)
        {
            case true when _instantMoveSw.ElapsedMilliseconds < pMovingTime:
                return;
            case true:
                _instantMoveSw.Stop();
                _instantMoveSw = new Stopwatch();
                break;
        }

        var kState = Keyboard.GetState();
        var canMoveAll = (pDirection & MovingDirection.All) == MovingDirection.All;
        var size = pParentSize == default ? WindowManager.GetWindowBounds() : pParentSize;

        if (kState.IsKeyDown(Keys.Up) && (canMoveAll || (pDirection & MovingDirection.Up) == MovingDirection.Up))
            pObject.Position.Y -= pMovingDistance;

        if (kState.IsKeyDown(Keys.Down) && (canMoveAll || (pDirection & MovingDirection.Down) == MovingDirection.Down))
            pObject.Position.Y += pMovingDistance;

        if (kState.IsKeyDown(Keys.Left) && (canMoveAll || (pDirection & MovingDirection.Left) == MovingDirection.Left))
            pObject.Position.X -= pMovingDistance;

        if (kState.IsKeyDown(Keys.Right) && (canMoveAll || (pDirection & MovingDirection.Right) == MovingDirection.Right))
            pObject.Position.X += pMovingDistance;

        CheckParentSize(pObject, size);
        _instantMoveSw.Start();
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
