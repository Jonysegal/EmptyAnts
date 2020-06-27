using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectionsSquare
{
    public class Being
    {
        public const int SquareWidth = 8;
        public LocalMap map;
        public Point position;

        static Being()
        {
            
        }

        public Being() : this(new Point(0, 0))
        {

        }

        public Being(Point p)
        {
            position = p;
            map = new LocalMap(SquareWidth);
        }
    }
}
