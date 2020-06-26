using deee;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace ConnectionsSquare
{
    public static class CameraControl
    {
        const float MoveVal = .25f;

        const float ZoomVal = .001f;

        static void MoveDown() => Drawer.view.Move(new Vector2f(0, MoveVal));
        static void MoveRight() => Drawer.view.Move(new Vector2f(MoveVal, 0));
        static void MoveUp() => Drawer.view.Move(new Vector2f(0, -1 * MoveVal));
        static void MoveLeft() => Drawer.view.Move(new Vector2f(-1 * MoveVal, 0));

        static void ZoomIn() => Drawer.view.Zoom(1-ZoomVal);
        static void ZoomOut() => Drawer.view.Zoom(1+ZoomVal);

        static void GetInput()
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.W))
                MoveUp();
            if (Keyboard.IsKeyPressed(Keyboard.Key.D))
                MoveRight();
            if (Keyboard.IsKeyPressed(Keyboard.Key.S))
                MoveDown();
            if (Keyboard.IsKeyPressed(Keyboard.Key.A))
                MoveLeft(); 
            if (Keyboard.IsKeyPressed(Keyboard.Key.Q))
                ZoomIn(); 
            if (Keyboard.IsKeyPressed(Keyboard.Key.E))
                ZoomOut();
        }

        public static void Loop()
        {
            GetInput();
            Drawer.UpdateView();
        }
    }
}
