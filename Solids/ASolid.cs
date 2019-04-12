using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpEngine.Gamelib;

namespace SharpEngine.Solids
{
    abstract class ASolid : AGameObject
    {
        protected int textureID;
        protected double scale;
        public bool visible { get; set; }
        public float[] color { get; set; }

        public AHitbox hitbox { get; set; }
        public ASolid()
        {
            this.hitbox = null;
            this.scale = 1.0;
            this.visible = true;
        }
        public void Render()
        {
            if (hitbox != null && hitbox.visible) hitbox.Render();
            if (visible) RenderBody();
        }
        protected abstract void RenderBody();
    }
}
