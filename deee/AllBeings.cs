using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectionsSquare
{
    public static class AllBeings
    {
        static List<BeingAndOutline> beingsAndOutlines = new List<BeingAndOutline>();

        static List<Being> allBeings = new List<Being>();

        static AllBeings()
        {
        }
        public static void Loop()
        {
            PositionBeingsAndOutlines();
        }

        static void PositionBeingsAndOutlines() => beingsAndOutlines.ForEach(PositionBeingAndOutline);

        public static void RegisterBeing(Being toRegister)
        {
            beingsAndOutlines.Add(CreateOutlineFor(toRegister));
        }

        static BeingAndOutline CreateOutlineFor (Being createFor)
        {
            LocalMap outline = Outliner.OutlineWithSize(Being.SquareWidth + 2);
            LocalMapPositioner.PositionLocalMap(outline, PointHelper.PointInDirection(createFor.map.position, Direct.Direction.DownLeft));
            return new BeingAndOutline(createFor, outline);
        }

        static void PositionBeingAndOutline(BeingAndOutline toPosition)
        {
            LocalMapPositioner.AddBeingToFullMap(toPosition.being);
            if (Config.DrawOutlines)
            {
                LocalMapPositioner.AddMapToFullMap(toPosition.outline);
            }
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
