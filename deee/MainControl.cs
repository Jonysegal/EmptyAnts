
using System;

namespace deee
{
    class MainControl
    {
       
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Worldff!");
            RunLoop();
            
        }
        static void RunLoop()
        {
            while (true)
            {
                Drawer.Loop();
            }
        }
    }
}
