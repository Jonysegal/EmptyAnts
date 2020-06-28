using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectionsSquare
{
    public static class TileSquareFamilyCreator
    {
        /// <summary>
        ///Policy: starts with a random being in center and random beings at either corner.
        ///This will create four rows. one on top, one right, one bottom, one left. Top is defined as beings between topLeft and topRight. right is topRight to bottomRight. etc
        ///The policy for filling out each row is the following. if emptyBeings in row == 1, empty beings is combo the one below it and the one to right or left and random. 
        ///Above is all perspective of top row.
        ///If emptyBeings.count != 1, empty being X is combo left of X and below X (or right of X and below X if on right side).
        ///all the perspective stuff gets messier as do other sides
        /// </summary>
        /// 

        static GenericLocalMap<Being> BeingMap;

        public static GenericLocalMap<Being> GenerateFamily(int width)
        {
            if (!MathHelper.IsEven(width) || width < 5)
                Console.WriteLine("Tried to do create an incorrect width square family " + width);
            BeingMap = new GenericLocalMap<Being>();
            StartFamily(); 
            return BeingMap;
        }

        static void StartFamily()
        {
            Being firstBeing = BeingFiller.NewFilledBeing();
            BeingMap.AddAt(firstBeing, PointHelper.ZeroPoint);
            foreach(var point in PointHelper.PointsInDiagonalDirections(PointHelper.ZeroPoint))
            {
                BeingMap.AddAt(BeingFiller.NewFilledBeing(), point);
            }
        }
    }

}