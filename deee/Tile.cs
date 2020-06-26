using SFML.Graphics;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class Tile
{
    //Bright ground is just for debugging
    public enum Type {Full, Empty, Signal};

    public Type type;

    public bool overridesColor = false;

    public Color color;

    public Tile(Type type)
    {
        this.type = type;
    }

    public void OverrideColor(Color newColor)
    {
        overridesColor = true;
        color = newColor;
    }


}


