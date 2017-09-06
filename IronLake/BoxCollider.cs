using Microsoft.Xna.Framework;

namespace IronLake
{
    public class BoxCollider : Collider
    {
        private Rectangle _boundingBox;

        public BoxCollider(int width, int height)
        {
            _boundingBox = new Rectangle(0, 0, width, height);
        }

        public Rectangle BoundingBox
        {
            get
            {
                _boundingBox.X = (int) GameObject.Transform.Position.X;
                _boundingBox.Y = (int)GameObject.Transform.Position.Y;

                return _boundingBox;
            }
        }
    }
}