using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace SharpEngine.Gamelib
{
    abstract class AHitbox
    {
        public bool visible { get; set; }
        public AHitbox()
        {
            this.visible = false;
        }
        /// <summary>
        /// Defines left - bottom - close coord of hitbox 
        /// </summary>
        public Vector3 first { get; protected set; }
        /// <summary>
        /// Defines right - top - distant coord of hitbox
        /// </summary>
        public Vector3 second { get; protected set; }

        public void Render()
        {
            GL.Color4(0.1, 0.8, 0.16, 0.4);

            GL.Begin(PrimitiveType.Quads);

            GL.Vertex3(first.X, second.Y, first.Z);
            GL.Vertex3(first.X, first.X, first.Z);
            GL.Vertex3(second.X, first.Y, first.Z);
            GL.Vertex3(second.X, second.Y, first.Z);

            GL.End();
        }
        public void Collide(AHitbox hitbox)
        {
            // Basically compare first and seconds positions of both hitboxes, too much math to do at 1 AM...
            throw new NotImplementedException();
        }
    }
}
