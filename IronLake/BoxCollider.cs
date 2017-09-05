using Microsoft.Xna.Framework;

namespace IronLake
{
    public class BoxCollider : Collider
    {
        public BoxCollider(int width, int height)
        {
            BoundingBox = new Rectangle(0, 0, width, height);
        }

        public Rectangle BoundingBox { get; set; }

        public override void BeforePhysics()
        {
            var boundingBox = BoundingBox;
            boundingBox.X = (int) Transform.Position.X;
            boundingBox.Y = (int) Transform.Position.Y;
            BoundingBox = boundingBox;

            base.BeforePhysics();
        }
    }
}