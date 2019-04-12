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
            GL.Color4(0.3, 0.3, 0.7, 0.4);

            GL.Begin(PrimitiveType.Quads);

            // front
            GL.Vertex3(first.X, second.Y, first.Z - 0.5);
            GL.Vertex3(first.X, first.Y, first.Z - 0.5);
            GL.Vertex3(second.X, first.Y, first.Z - 0.5);
            GL.Vertex3(second.X, second.Y, first.Z - 0.5);

            GL.End();
        }
        public void Collide(AHitbox hitbox)
        {
            // Basically compare first and seconds positions of both hitboxes, too much math to do at 1 AM...
            throw new NotImplementedException();
        }
    }
}
