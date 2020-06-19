using System;
using System.Collections;
using System.Collections.Generic;


public class CirclularList<T>
{
    public List<T> list;

    public void Add(T toAdd) => list.Add(toAdd);

    public T ClockwiseNeighborOf(T searchFor)
    {
        if (!list.Contains(searchFor))
            return default(T);
        if (IsLastElement(searchFor))
            return ListHelper.FirstElementOf(list);
        return list[list.IndexOf(searchFor) + 1];
    }
    
    public T CounterClockwiseNeighborOf(T searchFor)
    {
        if (!list.Contains(searchFor))
            return default(T);
        if (IsFirstElement(searchFor))
            return ListHelper.LastElementOf(list);
        return list[list.IndexOf(searchFor) - 1];
    }

    public T TraverseFromBy(T start, int by)
    {
        var startindex = list.IndexOf(start);
        var goalindex = startindex + by;
        if (goalindex < 0)
            return list[list.Count + goalindex];
        if (goalindex >= list.Count)
            return list[goalindex - list.Count];
        return list[goalindex];
    }

    bool IsLastElement(T check) => list.IndexOf(check) == list.Count - 1;
    bool IsFirstElement(T check) => list.IndexOf(check) == 0;

}
