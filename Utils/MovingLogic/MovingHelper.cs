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
    private Vector2 _lastPosition;
    private GameObject _parentObject;

    public MovingHelper(GameObject pObject, bool pCanPlayerMove)
    {
        _canPlayerMove = pCanPlayerMove;
        _parentObject = pObject;
        WindowManager.WindowSizeChanged += OnWindowSizeChanged;
    }

    public MovingHelper()
    {
        _canPlayerMove = false;
    }
    
    public void PlayerMove(GameTime pGameTime, MovingDirection pDirection = MovingDirection.All, float pObjectSpeed = float.NaN, Rectangle pParentSize = new())
    {
        if (pDirection == MovingDirection.None || !_canPlayerMove)
            return;

        var kState = Keyboard.GetState();
        var speed = float.IsNaN(pObjectSpeed) ? _parentObject.Speed : pObjectSpeed;
        var canMoveAll = (pDirection & MovingDirection.All) == MovingDirection.All;
        var parentBounds = pParentSize == default ? WindowManager.GetWindowBounds() : pParentSize;

        if (kState.IsKeyDown(Keys.Up) && (canMoveAll || (pDirection & MovingDirection.Up) == MovingDirection.Up))
            _parentObject.Position.Y -= speed * (float)pGameTime.ElapsedGameTime.TotalSeconds;

        if (kState.IsKeyDown(Keys.Down) && (canMoveAll || (pDirection & MovingDirection.Down) == MovingDirection.Down))
            _parentObject.Position.Y += speed * (float)pGameTime.ElapsedGameTime.TotalSeconds;

        if (kState.IsKeyDown(Keys.Left) && (canMoveAll || (pDirection & MovingDirection.Left) == MovingDirection.Left))
            _parentObject.Position.X -= speed * (float)pGameTime.ElapsedGameTime.TotalSeconds;

        if (kState.IsKeyDown(Keys.Right) && (canMoveAll || (pDirection & MovingDirection.Right) == MovingDirection.Right))
            _parentObject.Position.X += speed * (float)pGameTime.ElapsedGameTime.TotalSeconds;

        CheckParentSize(parentBounds);
    }

    public void PlayerMoveInstant(float pMovingDistance, int pMovingTime = 200, MovingDirection pDirection = MovingDirection.All, Rectangle pParentSize = new Rectangle())
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
            _parentObject.Position.Y -= pMovingDistance;

        if (kState.IsKeyDown(Keys.Down) && (canMoveAll || (pDirection & MovingDirection.Down) == MovingDirection.Down))
            _parentObject.Position.Y += pMovingDistance;

        if (kState.IsKeyDown(Keys.Left) && (canMoveAll || (pDirection & MovingDirection.Left) == MovingDirection.Left))
            _parentObject.Position.X -= pMovingDistance;

        if (kState.IsKeyDown(Keys.Right) && (canMoveAll || (pDirection & MovingDirection.Right) == MovingDirection.Right))
            _parentObject.Position.X += pMovingDistance;

        CheckParentSize(size);
        _instantMoveSw.Start();
    }

    private void CheckParentSize(Rectangle pParentSize)
    {
        if (!ConfineToParentBounds || pParentSize == default)
            return;

        if (_parentObject.Position.X > pParentSize.Width - _parentObject.Width / 2)
            _parentObject.Position.X = pParentSize.Width - _parentObject.Width / 2;
        else if (_parentObject.Position.X < _parentObject.Width / 2)
            _parentObject.Position.X = _parentObject.Width / 2;

        if (_parentObject.Position.Y > pParentSize.Height - _parentObject.Height / 2)
            _parentObject.Position.Y = pParentSize.Height - _parentObject.Height / 2;
        else if (_parentObject.Position.Y < _parentObject.Height / 2)
            _parentObject.Position.Y = _parentObject.Height / 2;
    }

    public void StoreLastPosition()
    {
        _lastPosition = _parentObject.Position;
    }

    public void RestoreLastPosition()
    {
        _parentObject.Position = _lastPosition;
    }

    private void OnWindowSizeChanged(bool isMinimized)
    {
        if (isMinimized)
        {
           StoreLastPosition();
           return; 
        }
        RestoreLastPosition();
    }
}
