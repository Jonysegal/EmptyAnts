using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectionsSquare
{
    public static class LocalMapPositioner
    {
        public static void AddMapToFullMap(LocalMap toPosition)
        {
            toPosition.pointTyles.ForEach(x => FullMap.AddPointTyle(PointHelper.PointTyleOffsetBy(x, toPosition.position)));

        }

        public static void AddBeingToFullMap(Being toAdd) => AddMapToFullMap(toAdd.map);

        public static void PositionLocalMap(LocalMap toPosition, Point positionAt) => toPosition.position = positionAt;
    }
}
