using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConnectionsSquare
{
    public class Point
    {
        public int x, y;
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            Point compareTo = (Point)obj;
            return compareTo.x == x && compareTo.y == y;
        }
        public override string ToString()
        {
            return "(" + x + ", " + y + ")";
        }
    }

    public static class PointHelper
    {
        public static Point PointOffsetBy(Point p, Point offset) => new Point(p.x + offset.x, p.y + offset.y);

        public static PointTyle PointTyleOffsetBy(PointTyle p, Point offset) => new PointTyle(PointOffsetBy(p.point, offset), p.type);

        public static Point PointExbandedBy(Point p, int expandBy) => new Point(p.x * expandBy, p.y * expandBy);

        public static Point PointInDirectionBy(Point point, Direct.Direction direction, int moveBy) => PointOffsetBy(point, PointExbandedBy(Direct.DirectionPointMap[direction], moveBy));

        public static Point PointInDirection(Point point, Direct.Direction direction) => PointInDirectionBy(point, direction, 1);

        public static List<Point> PointsInSquareAround(Point origin, int radius)
        {
            List<Point> toReturn = new List<Point>();

            for (int i = -radius; i <= radius; i++)
            {
                for (int j = -radius; j <= radius; j++)
                {
                    toReturn.Add(PointOffsetBy(origin, new Point(i, j)));
                }
            }
            return toReturn;
        }
        public static List<Point> PointsFromDirection(Point start, List<Direct.Direction> directions) => directions.Select(x => PointInDirection(start, x)).ToList();

        public static List<Point> PointsFromCardinalDirections(Point start) => new List<Point>()
        {
            PointInDirection(start, Direct.Direction.Up),
            PointInDirection(start, Direct.Direction.Right),
            PointInDirection(start, Direct.Direction.Down),
            PointInDirection(start, Direct.Direction.Left)
        };

        public static Point MidpointOf(Point a, Point b) => new Point((a.x + b.x) / 2, (a.y + b.y) / 2);

        //Goes from a.x => b.x then down in the y from a.y => b.y
        //Eg a = (-1, 1) b = (1, -1) would go (-1, 1), (0, 1), (1, 1), (-1, 0), (0, 0), etc
        //public static List<Point> PointsInRegionBetween(point a, point b)
        //{

        //}

    }

}
