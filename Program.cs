using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenGLCamera.Gamelib;

namespace OpenGLCamera
{
    class Program
    {
        static void Main(string[] args)
        {
            GameWindow gw = new GameWindow(500, 500, new OpenTK.Graphics.GraphicsMode(32, 24, 0, 4), "Sharp engine");

            Game game = new Game(gw, 60);
            game.Start();
        }
    }
}
