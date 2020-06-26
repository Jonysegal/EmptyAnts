using SFML.Window;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectionsSquare
{
    public static class Config
    {
        public static bool DrawOutlines = false;
        public static void Loop()
        {
            CheckConfigKeyChanges();
        }

        static void CheckConfigKeyChanges()
        {
            if (KeyboardManager.KeyJustPressed(Keyboard.Key.O))
                DrawOutlines = !DrawOutlines;
        }
    }
}
