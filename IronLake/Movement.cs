using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

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

        public static readonly Dictionary<Direction, Enum[]> InputMap = new Dictionary<Direction, Enum[]>
        {
            {Direction.Up, new Enum[] {Buttons.DPadUp, Keys.W, Keys.Up}},
            {Direction.Right, new Enum[] {Buttons.DPadRight, Keys.D, Keys.Right}},
            {Direction.Down, new Enum[] {Buttons.DPadDown, Keys.S, Keys.Down}},
            {Direction.Left, new Enum[] {Buttons.DPadLeft, Keys.A, Keys.Left}}
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

        public static Direction GetInputDirections()
        {
            return EnumExtensions.GetValues<Direction>()
                .Where(d => d > Direction.None)
                .Where(direction => GetInput(InputMap[direction]))
                .Aggregate(Direction.None, (current, direction) => current | direction);
        }

        public static bool GetInput(IEnumerable<Enum> inputs)
        {
            return inputs.Any(i =>
            {
                switch (i)
                {
                    case Buttons b:
                        return GamePad.GetState(PlayerIndex.One).IsButtonDown(b);
                    case Keys k:
                        return Keyboard.GetState().IsKeyDown(k);
                    default:
                        return false;
                }
            });
        }
    }
}