using System;

namespace Core.KeyBoard;

[Flags]
public enum MovingDirection
{
    None = 1,
    All = 2,
    Up = 4,
    Down = 8,
    Left = 16,
    Right = 32,
}
