using SFML.Window;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectionsSquare
{
    public static class KeyboardManager
    {
        static List<Keyboard.Key> justDown = new List<Keyboard.Key>();

        static List<Keyboard.Key> heldDown = new List<Keyboard.Key>();

        static readonly List<Keyboard.Key> KeysToCheck = new List<Keyboard.Key>()
        {
            Keyboard.Key.W,
            Keyboard.Key.D,
            Keyboard.Key.S,
            Keyboard.Key.A,
            Keyboard.Key.P,
            Keyboard.Key.O
        };

        public static void Loop()
        {
            foreach (var key in KeysToCheck)
            {
                if (Keyboard.IsKeyPressed(key))
                {
                    if (!heldDown.Contains(key))
                    {
                        if (justDown.Contains(key))
                            ListHelper.MoveBetween(justDown, heldDown, key);
                        else
                            justDown.Add(key);
                    }
                }
                else
                {
                    justDown.Remove(key);
                    heldDown.Remove(key);
                }
            }
        }

        public static bool KeyJustPressed(Keyboard.Key key) => justDown.Contains(key);
    }
}
