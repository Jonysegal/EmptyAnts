using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectionsSquare
{
    public static class BeingControl
    {
        const int IntialBeings = 20;

        static List<BeingAndOutline> beingsAndOutlines = new List<BeingAndOutline>();

        static BeingControl()
        {
            CreateInitialBeings();
            CreateChildrenOfInitialBeings();
            foreach(var bo in beingsAndOutlines)
            {
                if (MapAnalyzer.MapIsHorizontallySymetrical(bo.being.map))
                {
                    Console.WriteLine("below is horiz symet");
                    bo.being.map.Print();
                }
                if (MapAnalyzer.MapIsVerticallySymetrical(bo.being.map))
                {
                    Console.WriteLine("below is vert symet");
                    bo.being.map.Print();
                }
                if(beingsAndOutlines.IndexOf(bo) < 5)
                {
                    bo.being.map.Print();
                }
            }
        }
        public static void Loop()
        {
            PositionBeingsAndOutlines();
        }

        static void PositionBeingsAndOutlines() => beingsAndOutlines.ForEach(PositionBeingAndOutline);

        static void CreateInitialBeings()
        {
            for (int i = 0; i < IntialBeings; i++)
            {
                Being being = new Being(new Point(10 + (i * 50), 100));
                BeingFiller.FillBeing(being);
                CreateOutlineForAndAdd(being);
            }
        }

        static void CreateChildrenOfInitialBeings()
        {
            var childrenOf = new List<BeingAndOutline>(beingsAndOutlines);
            while (childrenOf.Count > 1)
            {
                var children = new List<BeingAndOutline>();
                for (int i = 0; i <= childrenOf.Count - 2; i++)
                {
                    var a = childrenOf[i].being;
                    var b = childrenOf[i + 1].being;
                    var child = BeingCombiner.CombineBeings(a, b);
                    CreateOutlineForAndAdd(child);
                    child.position = PointHelper.PointOffsetBy(PointHelper.MidpointOf(a.position, b.position), new Point(0, 20));
                    children.Add(ListHelper.LastElementOf(beingsAndOutlines));
                }
                ListHelper.ClearAndAddRange(childrenOf, children);

            }

        }

        static void CreateOutlineForAndAdd(Being createForAndAdd)
        {
            LocalMap outline = Outliner.OutlineWithSize(Being.SquareWidth + 2);
            beingsAndOutlines.Add(new BeingAndOutline(createForAndAdd, outline));
        }

        static void PositionBeingAndOutline(BeingAndOutline toPosition)
        {
            LocalMapPositioner.PositionBeing(toPosition.being);
            if (Config.DrawOutlines)
                LocalMapPositioner.PositionMap(toPosition.outline, PointHelper.PointInDirection(toPosition.being.position, Direct.Direction.DownLeft));
        }

    }
    class BeingAndOutline
    {
        public Being being;
        public LocalMap outline;
        public BeingAndOutline(Being b, LocalMap o)
        {
            being = b;
            outline = o;
        }
    }
}
