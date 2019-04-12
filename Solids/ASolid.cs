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
        public bool visible { get; set; }
        public float[] color { get; set; }
        public ASolid()
        {
            this.scale = 1.0;
            this.visible = true;
        }
        public void Render()
        {
            if (visible) RenderBody();
        }
        protected abstract void RenderBody();
    }
}
