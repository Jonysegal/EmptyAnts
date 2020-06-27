using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace ConnectionsSquare
{
    public static class MapAnalyzer
    {
        public static bool MapIsHorizontallySymetrical(LocalMap check)
        {
            int includeBelow = check.size / 2 - 1;
            var pointsToCompare = PointCollection.ListOfPointsWithSize(check.size).Where(x => x.x <= includeBelow);
            foreach(var point in pointsToCompare)
            {
                if (!check.PointsAreSameType(point, new Point(check.size - 1 - point.x, point.y)))
                    return false;
            }
            return true;
        }
        public static bool MapIsVerticallySymetrical(LocalMap check)
        {
            int includeBelow = check.size / 2 - 1;
            var pointsToCompare = PointCollection.ListOfPointsWithSize(check.size).Where(x => x.y <= includeBelow);
            foreach(var point in pointsToCompare)
            {
                if (!check.PointsAreSameType(point, new Point(point.x, check.size - 1 - point.y)))
                    return false;
            }
            return true;
        }
    }
}
