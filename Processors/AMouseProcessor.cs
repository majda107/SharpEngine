using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Input;

namespace SharpEngine.Processors
{
    abstract class AMouseProcessor
    {
        public int x { get; protected set; }
        public int y { get; protected set; }

        public int xDev { get; protected set; }
        public int yDev { get; protected set; }

        public abstract void Update(MouseState currentState);
    }
}
