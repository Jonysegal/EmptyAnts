using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectionsSquare
{
    public static class Outliner
    {
        public static LocalMap OutlineWithSize(int size)
        {
            LocalMap toReturn = new LocalMap(size);
            for(int i =0; i< size; i++)
            {
                for(int j = 0; j < size; j++)
                {
                    if(i== 0 || i == size-1 || j == 0 || j == size-1)
                        toReturn.AddSignalAt(new Point(i, j));
                }
            }
            toReturn.Complete();
            return toReturn;
        } 
    }
}
