using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectionsSquare
{
    public static class FamilyManager
    {
        public static List<GenericLocalMap<Being>> families = new List<GenericLocalMap<Being>>();

        public static void GenerateFamilies()
        {
            families.Add(PyramidFamilyCreator.GenerateFamily(5));
            PositionFamiles();
            AddBeingsToManager();
        }

        //Obvi if we ever have multiple families we'll need to position better
        public static void PositionFamiles() => families.ForEach(x => FamilyPositioner.PositionFamily(x, new Point(100, 100), 3));

        static void AddBeingsToManager()
        {
            foreach(var family in families)
            {
                foreach(var beingRow in family.map)
                {
                    foreach(var being in beingRow.Value)
                    {
                        AllBeings.RegisterBeing(being.Value);
                    }
                }
            }
        }
    }
}
