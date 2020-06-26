
using ConnectionsSquare;
using SFML.Window;
using System;
using System.IO.MemoryMappedFiles;

namespace deee
{
    class MainControl
    {
        static void Main(string[] args)
        {
            Initialize();
            RunLoop();
            
        }

        static void Initialize()
        {
        }

        static void RunLoop()
        {
            while (true)
            {
                KeyboardManager.Loop();
                Config.Loop();
                CameraControl.Loop();

                FullMap.StartLoop();
                BeingControl.Loop();
                FullMap.EndLoop();

                Drawer.Loop();
            }
        }

       
    }
}
