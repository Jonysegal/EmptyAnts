using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectionsSquare
{
    public static class ColorHelper
    {
        public static Color makeColor(int r, int g, int b, int a) => new Color((byte)r, (byte)g, (byte)b, (byte)a);
        public static Color makeColor(int r, int g, int b) => makeColor(r, g, b, 255);
    }
}
