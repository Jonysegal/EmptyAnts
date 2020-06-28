using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectionsSquare
{
    public static class FamilyPositioner
    {
        public static void PositionFamily(GenericLocalMap<Being> family, Point bottomLeft, int offset = 0)
        {
            foreach(var beingRow in family.map)
            {
                foreach(var being in beingRow.Value)
                {
                    var mapCoordWithinFamily = new Point(beingRow.Key, being.Key);
                    var placeAt = PointHelper.PointExbandedBy(mapCoordWithinFamily, Being.SquareWidth);
                    placeAt = PointHelper.PointOffsetBy(placeAt, bottomLeft);
                    placeAt = PointHelper.PointOffsetBy(placeAt, PointHelper.PointExbandedBy(mapCoordWithinFamily, offset));
                    LocalMapPositioner.PositionLocalMap(being.Value.map, placeAt);
                }
            }
        }
    }
}
