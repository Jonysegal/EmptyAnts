using System;
using System.Collections;
using System.Collections.Generic;


public static class ListHelper
{
    public static T RandomElementInList<T>(List<T> getFrom) => getFrom[StaticRandom.Next(0, getFrom.Count)];

    public static T FirstElementOf<T>(List<T> getFrom) => getFrom[0];

    public static T LastElementOf<T>(List<T> getFrom) => getFrom[getFrom.Count-1];

    /// <summary>
    /// Removes moving from from and adds it to to. if from does not contain moving notifies user of error
    /// </summary>
    public static void MoveBetween<T>(List<T> from, List<T> to, T moving)
    {
        if (!from.Contains(moving))
            Console.WriteLine("Tried to move " + moving.ToString() + " but could not find it in from");
        from.Remove(moving);
        to.Add(moving);
    }

    public static void ClearAndAddRange<T>(List<T> addTo, List<T> add)
    {
        addTo.Clear();
        addTo.AddRange(add);
    }
}
