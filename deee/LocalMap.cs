using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ConnectionsSquare
{
    /// <summary>
    /// Local map defines ways to interact with 2d arrays of points. the maps will then be drawn by other functions onto stuff
    /// </summary>
    /// 


    public class LocalMap
    {
        Dictionary<int, Dictionary<int, Tile.Type>> map = new Dictionary<int, Dictionary<int, Tile.Type>>();

        public int size;

        public List<PointTyle> pointTyles = null;


        public LocalMap(int size)
        {
            this.size = size;
            for (int i = 0; i < size; i++)
            {
                map[i] = new Dictionary<int, Tile.Type>();
            }
        }

        public Tile.Type TypeOf(Point point)
        {
            if (point.x > size || point.y > size)
            {
                Console.WriteLine("error in point find, " + point.ToString() + " too big for map size " + size);
            }
            if (map[point.x].TryGetValue(point.y, out var res))
                return res;
            else
                return Tile.Type.Empty;
        }

        public bool PointsAreSameType(Point a, Point b) => TypeOf(a) == TypeOf(b);

        void AddTileTypeAt(Point addAt, Tile.Type add)
        {
            map[addAt.x][addAt.y] = add;
        }

        public void AddEmptyAt(Point addAt) => AddTileTypeAt(addAt, Tile.Type.Empty);
        public void AddOccupiedAt(Point addAt) => AddTileTypeAt(addAt, Tile.Type.Full);
        public void AddSignalAt(Point addAt) => AddTileTypeAt(addAt, Tile.Type.Signal);

        public void Complete()
        {
            if (pointTyles != null)
            {
                Console.WriteLine("tried to finalize already finalized localmap");
            }
            else
            {
                pointTyles = AllPointsTyles();

            }
        }

        List<PointTyle> AllPointsTyles()
        {
            List<PointTyle> toReturn = new List<PointTyle>();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    toReturn.Add(new PointTyle(new Point(i, j), TypeOf(new Point(i, j))));
                }
            }
            return toReturn;
        }

        public bool PointInBounds(Point check) => check.x < size && check.y < size && check.x >= 0 && check.y >= 0;

        //Point must be within bounds
        public bool ContainsPoint(Point check) => map[check.x].ContainsKey(check.y);

        public void Print()
        {
            Console.WriteLine("");
            for(int i = size - 1; i >= 0; i--)
            {
                for(int j = 0; j < size; j++)
                {
                    if (ContainsPoint(new Point(j, i)))
                        Console.Write("1 ");
                    else
                        Console.Write("0 ");
                }
                Console.WriteLine("");
            }
        }

    }
}
