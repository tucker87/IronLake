using System;
using Microsoft.Xna.Framework;

namespace IronLake
{
    public static class RectangleExtensions
    {
        /// <summary>
        /// Calculates the signed depth of intersection between two rectangles.
        /// </summary>
        /// <returns>
        /// The amount of overlap between two intersecting rectangles. These
        /// depth values can be negative depending on which sides the rectangles
        /// intersect. This allows callers to determine the correct direction
        /// to push objects in order to resolve collisions.
        /// If the rectangles are not intersecting, Vector2.Zero is returned.
        /// </returns>
        public static (float X, float Y) GetIntersectionDepth(this Rectangle rectA, Rectangle rectB)
        {
            // Calculate current and minimum-non-intersecting distances between centers.
            float distanceX = rectA.Center.X - rectB.Center.X;
            float distanceY = rectA.Center.Y - rectB.Center.Y;
            var minDistanceX = rectA.Width / 2.0f + rectB.Width / 2.0f;
            var minDistanceY = rectA.Height / 2.0f + rectB.Height / 2.0f;

            // If we are not intersecting at all, return (0, 0).
            if (Math.Abs(distanceX) >= minDistanceX || Math.Abs(distanceY) >= minDistanceY)
                return (0, 0);

            // Calculate and return intersection depths.
            var depthX = distanceX > 0 ? minDistanceX - distanceX : -minDistanceX - distanceX;
            var depthY = distanceY > 0 ? minDistanceY - distanceY : -minDistanceY - distanceY;
            return (depthX, depthY);
        }

        public static (float X, float Y) GetAbsIntersectionDepth(this Rectangle rectA, Rectangle rectB)
        {
            var(depthX, depthY) = GetIntersectionDepth(rectA, rectB);
            return (Math.Abs(depthX), Math.Abs(depthY));
        }
    }
}
