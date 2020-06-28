using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectionsSquare
{
    public class Being
    {
        public const int SquareWidth = 8;
        public LocalMap map;

        static Being()
        {
            
        }

        public Being()
        {
            map = new LocalMap(SquareWidth);
        }

    }
}
