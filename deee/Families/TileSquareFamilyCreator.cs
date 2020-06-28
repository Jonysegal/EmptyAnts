using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConnectionsSquare
{
    public static class TileSquareFamilyCreator
    {
        /// <summary>
        ///Policy: starts with a random being in center and random beings at either corner.
        ///The corners are extended like this: corner i + 1 is corner combo(corner i, a random being). this being is the same for all 4 corners
        ///This will create four rows. one on top, one right, one bottom, one left. Top is defined as beings between topLeft and topRight. right is topRight to bottomRight. etc
        ///The policy for filling out each row is the following. if emptyBeings in row == 1, empty beings is combo the one below it and the one to right or left and random. 
        ///Above is all perspective of top row.
        ///If emptyBeings.count != 1, empty being X is combo left of X and below X (or right of X and below X if on right side).
        ///all the perspective stuff gets messier as do other sides
        /// </summary>
        /// 

        static GenericLocalMap<Being> BeingMap;
        static int familyWidth;

        public static GenericLocalMap<Being> GenerateFamily(int width)
        {
            if (MathHelper.IsEven(width) || width < 5)
                Console.WriteLine("Tried to do create an incorrect width square family " + width);
            familyWidth = width;
            BeingMap = new GenericLocalMap<Being>();
            StartFamily();
            FillBetweenAllCorners();
            return BeingMap;
        }

        static void StartFamily()
        {
            Being firstBeing = BeingFiller.NewFilledBeing();
            BeingMap.AddAt(firstBeing, PointHelper.ZeroPoint);
            foreach (var direction in Direct.DiagonalDirections)
            {
                var currentPairWith = BeingFiller.NewFilledBeing();

                var compareToPoint = PointHelper.PointExbandedBy(PointHelper.PointInDirection(PointHelper.ZeroPoint, direction), 0);
                var compareToBeing = BeingMap.ValueAt(compareToPoint);
                var placePosition = PointHelper.PointInDirection(compareToPoint, direction);

                BeingMap.AddAt(BeingCombiner.CombineBeings(compareToBeing, currentPairWith), placePosition);
            }
            int displacement = 1;

            while (displacement * 2 < familyWidth)
            {
                var currentPairWith = BeingFiller.NewFilledBeing();
                foreach (var direction in Direct.DiagonalDirections)
                {
                    var compareToPoint = PointHelper.PointExbandedBy(PointHelper.PointInDirection(PointHelper.ZeroPoint, direction), displacement);
                    var compareToBeing = BeingMap.ValueAt(compareToPoint);
                    var placePosition = PointHelper.PointInDirection(compareToPoint, direction);

                    BeingMap.AddAt(BeingCombiner.CombineBeings(compareToBeing, currentPairWith), placePosition);
                }
                displacement += 1;
            }
            
        }

        static void FillBetweenAllCorners()
        {
            List<Point> corners = new List<Point>()
            {
                new Point(0, 0), //upright
                new Point(0, 0), //downright
                new Point(0, 0), //downleft
                new Point(0, 0) //upleft
            };
            int counter = 0;
            while(counter * 2 < familyWidth)
            {
                for(int i =0; i < corners.Count; i++)
                {
                    corners[i] = PointHelper.PointInDirection(corners[i], Direct.DiagonalDirections[i]);
                }
                for(int i=0; i < corners.Count; i++)
                {
                    var a = corners[i];
                    var b = i == corners.Count - 1 ? corners[0] : corners[i + 1];
                    FillBetweenCorners(a, b);
                }
                counter++;
            }
        }


        static void FillBetweenCorners(Point a, Point b)
        {
            var collectedPoints = PointHelper.PointsInRegionBetween(a, b);
            ListHelper.RemoveEndsOf(collectedPoints);
            var directionToCenter = CorrectDirectionToCenterFromPoints(a, b);
            collectedPoints = SortListForProperCreation(collectedPoints, directionToCenter);
            foreach (Point point in collectedPoints)
            {
                var parentTowardsCenter = PointHelper.PointInDirection(point, directionToCenter);
                var parentBehind = PointHelper.PointInDirection(point, BackwardsDirectionWithDirectionToCenter(point, directionToCenter));
                BeingMap.AddAt(BeingCombiner.CombineBeings(BeingMap.ValueAt(parentTowardsCenter), BeingMap.ValueAt(parentBehind)), point);
            }
        }

        static List<Point> SortListForProperCreation(List<Point> toSort, Direct.Direction directionToCenter)
        {
            if (Direct.DirectionIsVertical(directionToCenter))
                return toSort.OrderByDescending(x => Math.Abs(x.x)).ToList();
            else
                return toSort.OrderByDescending(x => Math.Abs(x.y)).ToList();
        }

        static Direct.Direction BackwardsDirectionWithDirectionToCenter(Point from, Direct.Direction toCenter)
        {
            if (Direct.DirectionIsVertical(toCenter))
            {
                if (from.x < 0)
                    return Direct.Direction.Left;
                else if (from.x > 0)
                    return Direct.Direction.Right;
                else
                    return ListHelper.RandomElementInList(Direct.HorizontalDirections);
            }
            else
            {
                if (from.y < 0)
                    return Direct.Direction.Down;
                else if (from.y > 0)
                    return Direct.Direction.Up;
                else
                    return ListHelper.RandomElementInList(Direct.VerticalDirections);
            }
        }

        static Direct.Direction CorrectDirectionToCenterFromPoints(Point a, Point b)
        {
            if (a.y > 0 && b.y > 0)
                return Direct.Direction.Down;
            else if (a.y < 0 && b.y < 0)
                return Direct.Direction.Up;
            if (a.x > 0 && b.x > 0)
                return Direct.Direction.Left;
            else
                return Direct.Direction.Right;
        }
    }

}