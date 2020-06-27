using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectionsSquare
{
    public static class PointCollection
    {
        public static Dictionary<int, List<Point>> SizeListOfPointsTable = new Dictionary<int, List<Point>>();

        public static List<Point> ListOfPointsWithSize(int size) => SizeListOfPointsTable.TryGetValue(size, out var list) ? list : GenerateAndAddPointListWithSize(size);

        static List<Point> GenerateAndAddPointListWithSize(int size)
        {
            var toReturn = new List<Point>();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    toReturn.Add(new Point(i, j));
                }
            }
            SizeListOfPointsTable[size] = toReturn;
            return toReturn;
        }
    }
}
