using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConnectionsSquare
{
    public static class BeingFiller
    {
        const int maxAdditions = 20;

        public static void FillBeing(Being toFill)
        {
            var start = new Point(StaticRandom.Next(0, Being.SquareWidth), StaticRandom.Next(0, Being.SquareWidth));
            var proceduralList = new List<Point>() { start };
            var totalAdded = 0;
            while(proceduralList.Count > 0 && totalAdded < maxAdditions)
            {
                var possibleAdditions = new List<Point>();
                
                foreach(var p in proceduralList)
                {
                    if (!toFill.map.ContainsPoint(p))
                    {
                        possibleAdditions.AddRange(PointHelper.PointsFromCardinalDirections(p));
                        toFill.map.AddOccupiedAt(p);
                        totalAdded++;
                    }
                }

                possibleAdditions = possibleAdditions.Where(x => toFill.map.PointInBounds(x)).ToList();
                possibleAdditions = possibleAdditions.Where(x => !toFill.map.ContainsPoint(x)).ToList();
                for(int i = possibleAdditions.Count -1; i >= 0; i--)
                {
                    if (StaticRandom.NextDouble() - .5 < totalAdded / maxAdditions)
                    {
                        possibleAdditions.RemoveAt(i);
                    }
                }
                proceduralList.Clear();
                proceduralList.AddRange(possibleAdditions);
            }

            toFill.map.Complete();
        }
    }
}
