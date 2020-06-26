using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConnectionsSquare
{
    public static class FullMap
    {
        public static List<PointTyle> modifiedPoints = new List<PointTyle>();

        static Dictionary<int, Dictionary<int, Tile.Type>> map = new Dictionary<int, Dictionary<int, Tile.Type>>();

        static Dictionary<int, Dictionary<int, Tile.Type>> oldMap = new Dictionary<int, Dictionary<int, Tile.Type>>();

        public static void AddPointTyle(PointTyle toAdd)
        {
            Tile.Type compareTo = Tile.Type.Empty; 
            //Get the current type there, default to Empty
            if (map.TryGetValue(toAdd.point.x, out var column))
            {
                if(column.TryGetValue(toAdd.point.y, out var type))
                {
                    compareTo = type;
                    
                }
            }


            //If it's not empty, add it the map
            if(toAdd.type != Tile.Type.Empty)
            {
                if (column == null)
                    map[toAdd.point.x] = new Dictionary<int, Tile.Type>();
                map[toAdd.point.x][toAdd.point.y] = toAdd.type;

            }

        }

        public static void StartLoop()
        {
            modifiedPoints.Clear();
            oldMap.Clear();
            foreach(var currentColumn in map)
            {
                if(!oldMap.TryGetValue(currentColumn.Key, out var oldColumn))
                {
                    oldMap[currentColumn.Key] = new Dictionary<int, Tile.Type>();
                }
                foreach(var currentPoint in currentColumn.Value)
                {
                    oldMap[currentColumn.Key][currentPoint.Key] = currentPoint.Value;
                }
            }
            map.Clear();
        }

        public static void EndLoop()
        {
            foreach(var oldColumn in oldMap)
            {
                foreach(var oldPoint in oldColumn.Value)
                {
                    if (!map.TryGetValue(oldColumn.Key, out _))
                        modifiedPoints.Add(new PointTyle(new Point(oldColumn.Key, oldPoint.Key), Tile.Type.Empty));
                    else if (!map[oldColumn.Key].ContainsKey(oldPoint.Key))
                        modifiedPoints.Add(new PointTyle(new Point(oldColumn.Key, oldPoint.Key), Tile.Type.Empty));
                }
            }
            foreach (var currentColumn in map)
            {
                if (!oldMap.TryGetValue(currentColumn.Key, out var oldColumn))
                {
                    
                }
                foreach (var currentPoint in currentColumn.Value)
                {
                    bool newType = false;
                    if (oldColumn == null)
                        newType = true;
                    else if (!oldColumn.ContainsKey(currentPoint.Key) || oldColumn[currentPoint.Key] != currentPoint.Value)
                        newType = true;
                    if (newType)
                        modifiedPoints.Add(new PointTyle(new Point(currentColumn.Key, currentPoint.Key), currentPoint.Value));
                }
            }
        }
    }
}
