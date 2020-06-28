using System;
using System.Collections;
using System.Collections.Generic;


public static class MathHelper
{
    public static bool RandomChance(double chance) => StaticRandom.NextDouble() <= chance;

    public static double ConvertRadiansToDegrees(double radians)
    {
        double degrees = (180 / Math.PI) * radians;
        return (degrees);
    }

    public static bool NumberInRange(double test, double min, double max) => test >= min && test <= max;

    public static bool NumberNearNumberPlusMinus(double test, double midPoint, double margin) => NumberInRange(test, midPoint - margin, midPoint + margin);

    public static bool IsEven(int check) => check % 2 == 0;
}
