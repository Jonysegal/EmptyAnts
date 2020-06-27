using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectionsSquare
{
    public class GenericLocalMap<T>
    {
        Dictionary<int, Dictionary<int, T>> map = new Dictionary<int, Dictionary<int, T>>();

        public T ValueAt(Point at)
        {
            if (HasValueAt(at))
                return map[at.x][at.y];
            return default;
        }

        public bool HasValueAt(Point at)
        {
            var columnOfPoint = GetColumnAt(at.x);
            if (columnOfPoint.Count == 0)
                return false;
            if (!columnOfPoint.ContainsKey(at.y))
                return false;
            return true;
        }

        public void AddAt(T toAdd, Point addAt) => GetColumnAt(addAt.x)[addAt.y] = toAdd;

        Dictionary<int, T> GetColumnAt(int x) => map.TryGetValue(x, out var column) ? column : AddColumnAt(x);

        Dictionary<int, T> AddColumnAt(int x)
        {
            map[x] = new Dictionary<int, T>();
            return map[x];
        }
    }
}
