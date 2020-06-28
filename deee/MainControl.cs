
using ConnectionsSquare;
using SFML.Window;
using System;
using System.IO.MemoryMappedFiles;

namespace Connectionssquare
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
            FamilyManager.GenerateFamilies();
        }

        static void RunLoop()
        {
            while (true)
            {
                KeyboardManager.Loop();
                Config.Loop();
                CameraControl.Loop();

                FullMap.StartLoop();
                AllBeings.Loop();

                FullMap.EndLoop();

                Drawer.Loop();
            }
        }

       
    }
}
