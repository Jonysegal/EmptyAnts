using System;
using System.Collections.Generic;
using System.Data;
using System.Numerics;
using System.Text;
using ConnectionsSquare;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
namespace deee
{
    public static class Drawer
    {

        /// <summary>
        /// On invokation of drawer in the game loop, drawer has two responsibilites.
        /// 1) Update the image for any sprites modified in map storer over the past frame.
        /// 2) Draw the image to the window.
        /// </summary>

        static RenderWindow window;
        static Texture texture;
        static Image image;
        static Sprite sprite;
        const int WindowSize = 1000;
        public static View view = new View(new Vector2f(200, 200), new Vector2f(400, 400));

        static readonly Dictionary<Tile.Type, Color> TypeColorMap = new Dictionary<Tile.Type, Color>()
        {
            {Tile.Type.Empty, ColorHelper.makeColor(75, 156, 211)},
            {Tile.Type.Full, Color.White },
            {Tile.Type.Signal, Color.Red }
        };

        static Drawer()
        {
            window = new RenderWindow(new VideoMode(WindowSize, WindowSize), "Window");
            window.SetView(view);
            texture = new Texture(WindowSize, WindowSize);
            image = new Image(WindowSize, WindowSize);
            sprite = new Sprite(texture);
            InitializeImage();
        }

        static void InitializeImage()
        {
            Clear();
        }

        static void Clear()
        {
            for (uint i = 0; i < WindowSize; i++)
            {
                for (uint j = 0; j < WindowSize; j++)
                {
                    image.SetPixel(i, j, TypeColorMap[Tile.Type.Empty]);
                }
            }
        }

        static void SetPixelsFromDrawController()
        {
            foreach(var v in FullMap.modifiedPoints)
            {
                image.SetPixel((uint)v.point.x, (uint)v.point.y, TypeColorMap[v.type]);
            }
        }


        public static void Loop()
        {
            SetPixelsFromDrawController();
            Draw();
        }

        static void Draw()
        {
            texture.Update(image);
            window.Draw(sprite);
            window.Display();
        }

        public static void UpdateView() => window.SetView(view);

       

      
    }
}
