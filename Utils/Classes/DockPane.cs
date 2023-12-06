using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Utils.SharedObjects;
using MicrosoftRectangle = Microsoft.Xna.Framework.Rectangle;

namespace Utils.Classes
{
    public class DockPane : GameObject
    {
        // Properties
        public MicrosoftRectangle Bounds { get; set; }
        public List<GameObject> DockedObjects { get; set; } = new();

        // Constructor
        public DockPane(MicrosoftRectangle pBounds, Vector2 pOrigin = default)
        {
            Bounds = pBounds;
            Origin = pOrigin;
        }

        // Methods
        public void DockObject(GameObject pObject, DockingDirection pDirection = DockingDirection.Right, Vector2 pOffset = default)
        {
            if (!DockedObjects.Any())
            {
                pObject.Position = Origin + pOffset;
                DockedObjects.Add(pObject);
                return;
            }

            var lastObject = DockedObjects.Last();

            switch (pDirection)
            {
                case DockingDirection.Left:
                    pObject.Position = pOffset + new Vector2(lastObject.Position.X - lastObject.Width, lastObject.Position.Y);
                    break;
                case DockingDirection.Right:
                    pObject.Position = pOffset + new Vector2(lastObject.Position.X + lastObject.Width, lastObject.Position.Y);
                    break;
                case DockingDirection.Top:
                    pObject.Position = pOffset + new Vector2(lastObject.Position.X, lastObject.Position.Y - lastObject.Height);
                    break;
                case DockingDirection.Bottom:
                    pObject.Position = pOffset + new Vector2(lastObject.Position.X, lastObject.Position.Y + lastObject.Height);
                    break;
            }
            DockedObjects.Add(pObject);
        }
    }

    public enum DockingDirection
    {
        Left,
        Right,
        Top,
        Bottom
    }
}
