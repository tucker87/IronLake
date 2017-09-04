using System;
using System.Collections.Generic;

namespace IronLake
{
    public static class Movement
    {
        public static readonly Dictionary<Direction, (Direction Opposite, bool IsNegative)> Directions =
            new Dictionary<Direction, (Direction Opposite, bool IsNegative)>
            {
                {Direction.None, (Direction.None, false) },
                {Direction.Up, (Direction.Down, true)},
                {Direction.Right, (Direction.Left, false)},
                {Direction.Down, (Direction.Up, false)},
                {Direction.Left, (Direction.Right, true)}
            };

        [Flags]
        public enum Direction
        {
            None = 1,
            Up = 2,
            Right = 4,
            Down = 8,
            Left = 16
        }

        public static float LambdaMove(float amount, Direction direction, double elapsedSeconds)
        {
            if (direction == Direction.None)
                return 0;

            return amount * 60 * (float) elapsedSeconds * (Directions[direction].IsNegative ? -1 : 1);
        }

        public static bool IsOutOfBounds(float position, int maxLimit)
        {
            return position < 0 || position > maxLimit;
        }

        public static bool IsTouchingOfBounds(float position, int offset, int maxLimit)
        {
            return position < 0 || position + offset > maxLimit;
        }
    }
}