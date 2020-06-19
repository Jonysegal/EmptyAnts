﻿using System;
using System.Collections;
using System.Collections.Generic;


public static class RiverMaker
{

    static Direct.Direction currentDirection;

    static Point last;

    public static void MakeRiver(Point start)
    {
        //decide one main start direction (startDir)
        //each point in start trail gets to add one point to the start trail in either startDir or either of startDir's neighbors
        //each point also has a slowly increasing chance to modify startDir to one of startDir's neighbors

        currentDirection = Direct.RandomFullDirection();
        Console.WriteLine("making river start dir " + currentDirection);
        last = start;
        maxLengthForRiver = maxLength;
        AddPointToStartFrom(0);


    }

    const int maxLength = 500;
    static int maxLengthForRiver;
    const double changeDirectionModifier = .0005;
    const double chanceToVaryFromDirection = .6;

    static void AddPointToStartFrom(double startDirectionChangeChance)
    {
        maxLengthForRiver--;
        if (maxLengthForRiver <= 0)
            return;
        var chosenDirection = currentDirection;
        List<Direct.Direction> directionPossibilities;

        if (MathHelper.RandomChance(chanceToVaryFromDirection))
        {

            directionPossibilities = Direct.FullNeighborsOfWithout(currentDirection);
            chosenDirection = ListHelper.RandomElementInList(directionPossibilities);
        }
        last = PointHelper.PointInDirection(last, chosenDirection);
        
        foreach(var p in PointHelper.PointsInDistanceAround(last, 4))
        {
            Map.AddWaterAt(p);
        }


        if (MathHelper.RandomChance(startDirectionChangeChance))
        {

            directionPossibilities = Direct.FullNeighborsOfWithout(currentDirection);
            currentDirection = ListHelper.RandomElementInList(directionPossibilities);
            startDirectionChangeChance = changeDirectionModifier * -1 * 15;

        }

        startDirectionChangeChance += changeDirectionModifier;

        AddPointToStartFrom(startDirectionChangeChance);


    }





}
