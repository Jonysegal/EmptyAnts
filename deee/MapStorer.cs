using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;


public static class Map
{
    public const int Min = -500, Max = 500;

    public static Dictionary<Point, Tile.Type> map = new Dictionary<Point, Tile.Type>();

    public static List<Point> ModifiedPoints = new List<Point>();

    public static Dictionary<Tile.Type, List<Point>> listsOfPointsByType = new Dictionary<Tile.Type, List<Point>>()
    {
        {Tile.Type.Ant, new List<Point>() },
        {Tile.Type.AntHill, new List<Point>() },
        {Tile.Type.AntWithFood, new List<Point>() },
        {Tile.Type.Food, new List<Point>() },
        {Tile.Type.Ground, new List<Point>() },
        {Tile.Type.Water, new List<Point>() }
    };

    static void AddTile(Point addTo, Tile.Type toAdd)
    {
        
        listsOfPointsByType[toAdd].Add(addTo);
        map[addTo] = toAdd;
        ModifiedPoints.Add(addTo);
        
    }

    public static Tile.Type TypeOfPoint(Point point)
    {
        foreach(var val in map)
        {
            if (val.Key.Equals(point))
                return val.Value;
        }
        return Tile.Type.Ground;
    }
    public static bool PointIsAccessible(Point point) => Tile.AccessableTypes.Contains(TypeOfPoint(point));

    public static void AddWaterAt(Point at) => AddTile(at, Tile.Type.Water);
    public static void AddGroundAt(Point at) => AddTile(at, Tile.Type.Ground);
    public static void AddFoodAt(Point at) => AddTile(at, Tile.Type.Food);
    public static void AddAntAt(Point at) => AddTile(at, Tile.Type.Ant);
    public static void AddAntHillAt(Point at) => AddTile(at, Tile.Type.AntHill);
    public static void AddAntWithFoodAt(Point at) => AddTile(at, Tile.Type.AntWithFood);

}


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

    public static Point PointExbandedBy(Point p, int expandBy) => new Point(p.x * expandBy, p.y * expandBy);

    public static Point PointInDirectionBy(Point point, Direct.Direction direction, int moveBy) => PointOffsetBy(point, PointExbandedBy(Direct.DirectionPointMap[direction], moveBy));

    public static Point PointInDirection(Point point, Direct.Direction direction) => PointInDirectionBy(point, direction, 1);

    public static List<Point> PointsInSquareAround(Point origin, int radius)
    {
        List<Point> toReturn = new List<Point>();

        for(int i = -radius; i <= radius; i++)
        {
            for(int j = -radius; j <= radius; j++)
            {
                toReturn.Add(PointOffsetBy(origin, new Point(i, j)));
            }
        }
        return toReturn;
    }

    public static List<Point> PointsInDistanceAround(Point origin, int radius) => PointsInSquareAround(origin, radius).Where(x => DistanceBetweenPoints(origin, x) <= radius).ToList();
   
    public static double DistanceBetweenPoints(Point a, Point b) => Math.Sqrt((a.x - b.x) * (a.x - b.x) + (a.y - b.y) * (a.y - b.y));

    const double halfOfFortyFive = 45 / 2;

    public static List<Direct.Direction> BestDirectionFrom(Point a, Point b)
    {
        if (a == b)
        {
            Console.WriteLine("kill me");
            return null;

        }

        double xDisplacement = b.x - a.x;
        double yDisplacement = b.y - a.y;
        double angle = Math.Atan(yDisplacement / xDisplacement);
        Direct.Direction bestDirection;
        angle = MathHelper.ConvertRadiansToDegrees(Math.Atan(yDisplacement / xDisplacement));
        if (xDisplacement < 0 && yDisplacement < 0)
        {
            angle = (-90 - angle);
        }
        if(xDisplacement >= 0)
        {
            if (yDisplacement >= 0)
            {
                if (angle < 45 * .5)
                    bestDirection = Direct.Direction.Right;
                else if (angle > 45 * 1.5)
                    bestDirection = Direct.Direction.Up;
                else
                    bestDirection = Direct.Direction.UpRight;
            }
            else
            {
                if (angle > 45 * -.5)
                    bestDirection = Direct.Direction.Right;
                else if (angle < 45 * -1.5)
                    bestDirection = Direct.Direction.Down;
                else
                    bestDirection = Direct.Direction.DownRight;
            }
        }
        else
        {
            if (yDisplacement >= 0)
            {
                if (angle > 45 * -.5)
                    bestDirection = Direct.Direction.Up;
                else if (angle < 45 * -1.5)
                    bestDirection = Direct.Direction.Right;
                else
                    bestDirection = Direct.Direction.UpRight;
            }
            else
            {
                if (angle < 45 * -2.5)
                    bestDirection = Direct.Direction.DownLeft;
                else if (xDisplacement < yDisplacement)
                    bestDirection = Direct.Direction.Left;
                else
                    bestDirection = Direct.Direction.Down;
            }
        }
        var toReturn = new List<Direct.Direction>() { bestDirection };
        var directionIndex = Direct.FullDirectionCircle.list.IndexOf(bestDirection);
        for(int i=1; i <= 3; i++)
        {
            toReturn.Add(Direct.FullDirectionCircle.TraverseFromBy(bestDirection, i));
            toReturn.Add(Direct.FullDirectionCircle.TraverseFromBy(bestDirection, i * -1));
        }
 
        return toReturn ;

    }

    public static List<Point> PointsFromDirection(Point start, List<Direct.Direction> directions) => directions.Select(x => PointInDirection(start, x)).ToList();


}
