using System;

namespace MHD
{
    class MHD
    {
        static void Main(string[] args)
        {
            using (Render.Frame game = new Render.Game())
            {
                game.Run(args.Length > 0 && args[0] == "fs");
            }
        }
    }
}
