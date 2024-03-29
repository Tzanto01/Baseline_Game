﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Utils.Interfaces;

namespace Utils.SharedObjects;

public class Rectangle : GameObject, ILoadDrawAndUpdate
{
    public Rectangle(bool canPlayerMove = false) : base(canPlayerMove)
    {
    }

    public void LoadContent()
    {
        BaseTexture = LoadTexture("rectangle");
        Size = 0.2f;
        Speed = 200;
        SetCentered();
        MovingHelper.ConfineToParentBounds = true;
    }

    public void Update(GameTime pGameTime)
    {
        MovingHelper.PlayerMoveInstant(50);
    }

    public void Draw(GameTime pGameTime, SpriteBatch pSpriteBatch)
    {
        Draw(pSpriteBatch);
    }
}
