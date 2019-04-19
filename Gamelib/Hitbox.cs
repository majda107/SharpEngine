using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace SharpEngine.Gamelib
{
    class Hitbox : AHitbox
    {
        public Hitbox(Vector3 first, Vector3 second, bool visible) : base(visible)
        {
            this.first = first;
            this.second = second;
        }
    }
}
