using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectionsSquare
{
    public static class LocalMapPositioner
    {
        public static void PositionMap(LocalMap toPosition, Point positionAt)
        {
            
            toPosition.pointTyles.ForEach(x => FullMap.AddPointTyle(PointHelper.PointTyleOffsetBy(x, positionAt)));

        }

        public static void PositionBeing(Being toPosition) => PositionMap(toPosition.map, toPosition.position);
    }
}
