using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectionsSquare
{
    public class Being
    {
        public const int SquareWidth = 8;
        public LocalMap map;
        public static readonly List<Point> pointsInBeingMap = new List<Point>();
        public Point position;

        static Being()
        {
            for(int i=0; i < SquareWidth; i++)
            {
                for(int j=0; j < SquareWidth; j++)
                {
                    pointsInBeingMap.Add(new Point(i, j));
                }
            }
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
