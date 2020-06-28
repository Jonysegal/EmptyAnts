using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectionsSquare
{

    public static class Direct
    {
        public static Point LeftPoint = new Point(-1, 0);
        public static Point UpPoint = new Point(0, 1);
        public static Point RightPoint = new Point(1, 0);
        public static Point DownPoint = new Point(0, -1);
        public static Point UpLeftPoint = new Point(-1, 1);
        public static Point UpRightPoint = new Point(1, 1);
        public static Point DownRightPoint = new Point(1, -1);
        public static Point DownLeftPoint = new Point(-1, -1);




        public static Dictionary<Direction, Point> DirectionPointMap = new Dictionary<Direction, Point>()
    {
        { Direction.Left, LeftPoint },
        { Direction.Up, UpPoint },
        { Direction.Right, RightPoint },
        { Direction.Down, DownPoint },
        { Direction.UpLeft, UpLeftPoint },
        { Direction.UpRight, UpRightPoint },
        { Direction.DownRight, DownRightPoint },
        { Direction.DownLeft, DownLeftPoint }
    };

        public enum Direction
        {
            Left,
            Up,
            Right,
            Down,
            UpLeft,
            UpRight,
            DownRight,
            DownLeft
        };

        public static readonly List<Direction> AllDirections = new List<Direction>()
        {
            Direction.Up,
            Direction.UpRight,
            Direction.Right,
            Direction.DownRight,
            Direction.Down,
            Direction.DownLeft,
            Direction.Left,
            Direction.UpLeft
        };

        public static readonly List<Direction> CardinalDirections = new List<Direction>()
        {
            Direction.Up,
            Direction.Right,
            Direction.Down,
            Direction.Left
        };

        public static readonly List<Direction> DiagonalDirections = new List<Direction>()
        {
            Direction.UpRight,
            Direction.DownRight,
            Direction.DownLeft,
            Direction.UpLeft
        };

        public static readonly List<Direction> VerticalDirections = new List<Direction>()
        {
            Direction.Up,
            Direction.Down
        };
        public static readonly List<Direction> HorizontalDirections = new List<Direction>()
        {
            Direction.Left,
            Direction.Right
        };

        public static bool DirectionIsVertical(Direction toCheck) => toCheck == Direction.Up || toCheck == Direction.Down;

        public static bool DirectionIsHorizontal(Direction toCheck) => toCheck == Direction.Left || toCheck == Direction.Right;
    }

}
