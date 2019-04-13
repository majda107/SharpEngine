using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpEngine.Gamelib;
using OpenTK;

namespace SharpEngine.Solids
{
    abstract class ASolid : AGameObject
    {
        public Vector3 scale { get; set; }
        public bool visible { get; set; }
        public float[] color { get; set; }
        /// <summary>
        /// Yaw, Pitch, Roll (in degrees)
        /// </summary>
        public Vector3 angles { get; set; } 


        public AHitbox hitbox { get; set; }
        public ASolid(Vector3 pos)
        {
            this.pos = pos;
            this.hitbox = null;

            this.scale = new Vector3(1.0f, 1.0f, 1.0f);
            this.angles = new Vector3(0.0f, 0.0f, 0.0f);
            this.visible = true;

            this.color = new float[4] { 1.0f, 1.0f, 1.0f, 1.0f };
        }
        public void Render()
        {
            if (visible) RenderBody();
            if (hitbox != null && hitbox.visible) hitbox.Render();
        }
        protected abstract void RenderBody();
    }
}
