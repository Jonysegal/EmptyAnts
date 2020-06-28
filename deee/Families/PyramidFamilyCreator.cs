using System.Collections.Generic;

namespace ConnectionsSquare
{
    //Family creators craete a generic local map of local maps according to certain polcies. These local maps can then be manipulated by other stuff.notep
    public static class PyramidFamilyCreator
    {
        public static GenericLocalMap<Being> GenerateFamily(int baseSize)
        {
            var toReturn = new GenericLocalMap<Being>();
            var allBeings = new List<Being>();

            for (int i = 0; i < baseSize; i++)
            {
                Being being = new Being();
                BeingFiller.FillBeing(being);
                allBeings.Add(being);
            }

            var childrenOf = new List<Being>(allBeings);
            AddListOfBeingsToMap(toReturn, childrenOf, 0);
            var rowCount = 0;
            while (childrenOf.Count > 1)
            {
                rowCount++;
                var children = new List<Being>();
                for (int i = 0; i <= childrenOf.Count - 2; i++)
                {
                    var a = childrenOf[i];
                    var b = childrenOf[i + 1];
                    var child = BeingCombiner.CombineBeings(a, b);
                    children.Add(child);
                }
                ListHelper.ClearAndAddRange(childrenOf, children);
                AddListOfBeingsToMap(toReturn, childrenOf, rowCount);
            }

            return toReturn;
        }

        static void AddListOfBeingsToMap(GenericLocalMap<Being> manipulate, List<Being> toAdd, int rowCount)
        {
            var spot = rowCount;

            foreach(var being in toAdd)
            {
                manipulate.AddAt(being, new Point(spot, rowCount));
                spot += 2;
            }

        }
    }
}
