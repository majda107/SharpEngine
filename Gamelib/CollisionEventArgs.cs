using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpEngine.Solids;

namespace SharpEngine.Gamelib
{
    class CollisionEventArgs : EventArgs
    {
        public ASolid solid { get; private set; }
        public CollisionEventArgs(ASolid solid)
        {
            this.solid = solid;
        }
    }
}
