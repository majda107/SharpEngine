using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpEngine.Solids
{
    abstract class ASolid : Gamelib.AGameObject
    {
        protected int textureID;
        protected double scale;
        public ASolid()
        {
            this.scale = 1.0;
        }
        public abstract void Render();
    }
}
