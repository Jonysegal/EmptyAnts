using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectionsSquare
{
    public static class BeingCombiner
    {
        public static Being CombineBeings(Being a, Being b)
        {
            Being toReturn = new Being();
            foreach(var p in Being.pointsInBeingMap)
            {
                if (a.map.TypeOf(p) != b.map.TypeOf(p))
                    toReturn.map.AddOccupiedAt(p);
            }
            toReturn.map.Complete();
            return toReturn;
        }
    }
}
